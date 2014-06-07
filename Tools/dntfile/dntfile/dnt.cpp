#include"stdafx.h"
bool  RowData::Equal(const RowData &d)
{
	if (d.dbFieldType != dbFieldType)
		return false;

	switch (dbFieldType)
	{
	case FieldTypeWord:
		return strcmp(szText, d.szText) == 0;

		break;
	case FieldTypeBool:
		return boolvalue == d.boolvalue;
		break;
	case FieldTypeInt:
		return intvalue == d.intvalue;
		break;
	case FieldTypePercent:
		return percentvalue == d.percentvalue;
		break;
	case FieldTypeFloat:
		return floatvalue == d.floatvalue;
		break;
	}
	return false;
}

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

void RowData::WriteToFile(ofstream &f)
{
	switch (this->dbFieldType)
	{
	case FieldTypeWord:
		if (wLen>0)
		f<<szText;
		else
		{
			f << " ";
		}
		break;
	case FieldTypeBool:
		f << boolvalue;
		break;
	case FieldTypeInt:
		f << intvalue;
		break;
	case FieldTypePercent:
		f << percentvalue;
		break;
	case FieldTypeFloat:
		f << floatvalue;
		break;
	}
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

void field::WriteToFile(ofstream &f)
{
	switch (this->dbFieldType)
	{
	case FieldTypeWord:

			f << "(String) ";

		break;
	case FieldTypeBool:
		f << "(Bool) ";
		break;
	case FieldTypeInt:
		f << "(Int) ";
		break;
	case FieldTypePercent:
		f << "(Percent) ";
		break;
	case FieldTypeFloat:
		f << "(Float) ";
		break;
	}
	f << this->szText;
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
	int index_of_search = -1;
	for (int i = 0; i < colNum; i++)
	{
		index += fields[i].GetField(buf + index);
		/*if (strcmp(fields[i].szText, "_OverlapCount") == 0)
		{
			index_of_search = i;
		}*/
	}
	for (int i = 0; i < rowNum; i++)
	{
		memcpy(&_RowID[i], buf + index, 4);
		index += 4;
		for (int j = 0; j < colNum; j++)
		{
			 
			index += data[i][j].GetValue(buf + index, fields[j].dbFieldType);
			/*if (index_of_search>=0&&j == index_of_search)
			{
				if (data[i][j].intvalue == 500)
				{
					data[i][j].intvalue = 10000;
					printf("%d\n", data[i][j].intvalue);
				}
				
			}*/
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

void DNTFile::Search(field title, RowData data, int &row, int &col, int startrow)
{
	col = row = -1;
	for (int i = 0; i < colNum; i++)
	{
		if (strcmp(fields[i].szText, title.szText) == 0)
		{
			col = i;
			break;
		}
	}
	if (col < 0)
	{
		return;
	}
	
	for (int i = startrow; i < rowNum; i++)
	{
		if (this->data[i][col].Equal(data))
		{
			row = i;
			return;
		}
	}
	return;

}
void DNTFile::WriteToTextFile(char *filename)
{
	ofstream outfile(filename);
	for (int i = 0; i < colNum; i++)
	{
		this->fields[i].WriteToFile(outfile);
		outfile << " ";
	}
	outfile << endl;
	for (int i = 0; i < rowNum; i++)
	{
		for (int j = 0; j < colNum; j++)
		{
			//printf("%d,%d\n", i, j);		
			this->data[i][j].WriteToFile(outfile);
			outfile << " ";
		}
		outfile << endl;
	}
	outfile.close();

}
void DNTFile::Replace(field title, RowData data, int &row, int &col, int startrow)
{
	col = -1;
	for (int i = 0; i < colNum; i++)
	{
		if (strcmp(fields[i].szText, title.szText) == 0)
		{
			col = i;
			break;
		}
	}
	if (col < 0)
	{
		return;
	}
	if (this->data[row][col].dbFieldType==(data.dbFieldType))
	{
		switch (data.dbFieldType)
		{
		case FieldTypeWord:
			memcpy(this->data[row][col].szText, data.szText, data.wLen);
			this->data[row][col].wLen = data.wLen;

			break;
		case FieldTypeBool:
			this->data[row][col].boolvalue = data.boolvalue;
			break;
		case FieldTypeInt:
			this->data[row][col].intvalue = data.intvalue;
			break;
		case FieldTypePercent:
			this->data[row][col].percentvalue = data.percentvalue;
			break;
		case FieldTypeFloat:
			this->data[row][col].floatvalue = data.floatvalue;
			break;
		}
		return;
	}
}