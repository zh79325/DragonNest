#include"stdafx.h"


int RowData::GetValue(char *byte, BYTE valuetype)
{
	this->dbFieldType = valuetype;
	int index = 0;
	switch (valuetype)
	{
	case FieldTypeWord:
		memcpy(&wLen, byte + index, sizeof(WORD));
		index += sizeof(WORD);
		szText = new char[wLen+1];
		memcpy(szText, byte + index, wLen);
		index += wLen;
		szText[wLen] = '\0';
		break;
	case FieldTypeBool:
		memcpy(&boolvalue, byte + index, sizeof(DWORD));
		index += sizeof(DWORD);
		break;
	case FieldTypeInt:
		memcpy(&intvalue, byte + index, sizeof(DWORD));
		index += sizeof(DWORD);
		break;
	case FieldTypePercent:
		memcpy(&percentvalue, byte + index, sizeof(float));
		index += sizeof(float);
		break;
	case FieldTypeFloat:
		memcpy(&floatvalue, byte + index, sizeof(float));
		index += sizeof(float);
		break;
	}
	return index;
}

void RowData::WriteValue(char byte[], int &len)
{
	int index = 0;
	switch (this->dbFieldType)
	{
	case FieldTypeWord:
		memcpy(byte + index, &wLen, sizeof(WORD));
		index += sizeof(WORD);
		memcpy(byte + index, szText, wLen);
		index += wLen;
		break;
	case FieldTypeBool:
		memcpy(byte + index, &boolvalue, sizeof(DWORD));
		index += sizeof(DWORD);
		break;
	case FieldTypeInt:
		memcpy(byte + index, &intvalue, sizeof(DWORD));
		index += sizeof(DWORD);
		break;
	case FieldTypePercent:
		memcpy(byte + index, &percentvalue, sizeof(float));
		index += sizeof(float);
		break;
	case FieldTypeFloat:
		memcpy(byte + index, &floatvalue, sizeof(float));
		index += sizeof(float);
		break;
	}
	len = index;
}

int field::GetField(char *data)
{
	int index = 0;
	memcpy(&wTextLen, data + index, sizeof(WORD));
	index += sizeof(WORD);
	szText = new char[wTextLen+1];
	szText[wTextLen] = '\0';
	memcpy(szText, data + index, wTextLen);
	index += wTextLen;
	memcpy(&dbFieldType, data + index, sizeof(BYTE));
	index += sizeof(BYTE);
	return  index;
}

void field::WriteField(char data[], int &len)
{
	int index = 0;
	memcpy(data + index, &wTextLen, sizeof(WORD));
	index += sizeof(WORD);
	memcpy(data + index, szText, wTextLen);
	index += wTextLen;
	memcpy(data + index, &dbFieldType, sizeof(BYTE));
	index += sizeof(BYTE);
	len = index;
}

void DNTFile::ReadFromFile(char *filename)
{
	ifstream infile2(filename);
	ifstream infile;
	infile.open(filename, ios::binary);
	infile2.seekg(0, ios::end);
	//streamsize = infile.tellg()
	int len = infile2.tellg();
	infile2.close();

	char *buf = new char[len];
	infile.read(buf, len);

	infile.close();


	int index = 0;
	memcpy(&this->dwNull, buf + index, 4);
	index += 4;
	memcpy(&this->colNum, buf + index, 2);
	index += 2;
	memcpy(&this->rowNum, buf + index, 4);
	index += 4;

	this->fields = new field[colNum];

	data = new RowData*[rowNum];
	_RowID = new DWORD[rowNum];
	for (int i = 0; i < rowNum; i++)
	{
		data[i] = new  RowData[colNum];
	}
	for (int i = 0; i < colNum; i++)
	{
		index += fields[i].GetField(buf + index);
	}
	for (int i = 0; i < rowNum; i++)
	{
		memcpy(&_RowID[i], buf + index, 4);
		index += 4;
		for (int j = 0; j < colNum; j++)
		{
			index += data[i][j].GetValue(buf + index, fields[j].dbFieldType);
		}
	}

	delete[]buf;
}

void DNTFile::WriteToFile(char *filename)
{
	ofstream outfile;
	outfile.open(filename, ios::binary);
	int index = 0;
	char buf[4];
	memcpy(buf, &this->dwNull, 4);
	outfile.write(buf, 4);
	index += 4;
	outfile.seekp(index);
	

	memcpy(buf, &this->colNum, 2);
	outfile.write(buf, 2);
	index += 2;
	outfile.seekp(index);


	memcpy(buf, &this->rowNum, 4);
	outfile.write(buf, 4);
	index += 4;
	outfile.seekp(index);

	 
	char fieldbuf[65536];
	int fieldlen = 0;
	for (int i = 0; i < colNum; i++)
	{
		
		
		fields[i].WriteField(fieldbuf, fieldlen);
		outfile.write(fieldbuf, fieldlen);
		index += fieldlen;
		outfile.seekp(index);
	}
	for (int i = 0; i < rowNum; i++)
	{
		memcpy(buf, &_RowID[i], 4);
		outfile.write(buf, 4);
		index += 4;
		outfile.seekp(index);

	 
		for (int j = 0; j < colNum; j++)
		{
			data[i][j].WriteValue(fieldbuf, fieldlen);
			outfile.write(fieldbuf, fieldlen);
			index += fieldlen;
			outfile.seekp(index);
		}
	}
	outfile.seekp(0, ios::end);
	char endbuf[] = {0x05,0x54,0x48,0x45,0x4e,0x44};
	outfile.write(endbuf, 6);
	outfile.close();
}