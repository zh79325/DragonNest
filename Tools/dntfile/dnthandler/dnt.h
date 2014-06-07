#ifndef _DNT_H
#define _DNT_H
#pragma once
#include<Windows.h>
#include<iostream>
#include<fstream>
using namespace std;

#define FieldTypeWord 1//���ֶ�����Ϊ��ͨ�䳤�ı�
#define FieldTypeBool 2//���ֶ�����Ϊ�����ͣ���32λ���ʹ�ţ�
#define FieldTypeInt 3//���ֶ�����Ϊ32λ����
#define FieldTypePercent 4//���ֶ����Ͱٷֱȣ����ֶ�Ϊ�����ȸ����ͣ���Ҫ����100��
#define FieldTypeFloat 5//���ֶ����͵����ȸ�����
//����	7	error C4996 : 'strcpy' : This function or variable may be unsafe.Consider using strcpy_s instead.To disable deprecation, use _CRT_SECURE_NO_WARNINGS.See online help for details.d : \admin\desktop\dragonnest\tools\dntfile\dntfile\dnt.cpp	275	1	dntfile

struct field{
	WORD wTextLen;//�ֶ����Ƶĳ��ȣ�ռ2�ֽ�
	char *szText;//�ֶ����ƣ�ռwTextLen�ֽ�
	BYTE dbFieldType;//�ֶ����ͣ�ռ1�ֽڣ��京�����£�
	field()
	{
		wTextLen = 0;
		szText = 0;
	}
	~field()
	{
		if (szText != 0)
		{
			//delete szText;
		}
	}
	int GetField(char *data);
	void WriteToFile(ofstream &f);
	void WriteField(char data[], int &len);
};

struct RowData
{
	RowData()
	{
		szText = 0;
	}
	~RowData()
	{
		if (szText != 0)
		{
			delete[]szText;
			szText = 0;
		}
		
	}
	bool Equal(const RowData &d);
	BYTE dbFieldType;

	WORD wLen;//�ı��ĳ��ȣ�ռ2�ֽ�
	char *szText;//�ı���ռwLen�ֽ�
	void WriteToFile(ofstream &f);
	int boolvalue;
	int intvalue;

	float percentvalue;

	float floatvalue;
	int GetValue(char *byte, BYTE valuetype);
	void WriteValue(char data[], int &len);
};
struct  DNTFile
{
	DNTFile()
	{
		colNum = 0;
		rowNum = 0;
		fields = 0;
		data = 0;
	}
	~DNTFile()
	{
		if (fields != 0)
		{
			delete[]fields;
			fields = 0;
		}
			
		if (data != 0)
		{
			for (int i = 0; i < rowNum; i++)
			{
				delete[]data[i];
			}
			delete[]data;
			delete[]_RowID;
			_RowID = 0;
			data = 0;
		}
	}
	void Search(field title,RowData data, int &row, int &col,int startrow=0);
	void Replace(field title, RowData data, int &row, int &col, int startrow = 0);
	DWORD dwNull;
	WORD colNum;//�ֶθ�������������ռ2�ֽ�
	DWORD rowNum;//���ݸ�������������ռ4�ֽ�
	field *fields;
	DWORD *_RowID;
	RowData **data;
	void WriteToFile(char *filename);
	void WriteToTextFile(char *f);
	void ReadFromFile(char *filename);
};
#endif