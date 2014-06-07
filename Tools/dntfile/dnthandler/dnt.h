#ifndef _DNT_H
#define _DNT_H
#pragma once
#include<Windows.h>
#include<iostream>
#include<fstream>
using namespace std;

#define FieldTypeWord 1//：字段类型为普通变长文本
#define FieldTypeBool 2//：字段类型为布尔型（以32位整型存放）
#define FieldTypeInt 3//：字段类型为32位整型
#define FieldTypePercent 4//：字段类型百分比（该字段为单精度浮点型，但要除以100）
#define FieldTypeFloat 5//：字段类型单精度浮点型
//错误	7	error C4996 : 'strcpy' : This function or variable may be unsafe.Consider using strcpy_s instead.To disable deprecation, use _CRT_SECURE_NO_WARNINGS.See online help for details.d : \admin\desktop\dragonnest\tools\dntfile\dntfile\dnt.cpp	275	1	dntfile

struct field{
	WORD wTextLen;//字段名称的长度，占2字节
	char *szText;//字段名称，占wTextLen字节
	BYTE dbFieldType;//字段类型，占1字节，其含义如下：
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

	WORD wLen;//文本的长度，占2字节
	char *szText;//文本，占wLen字节
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
	WORD colNum;//字段个数（列数），占2字节
	DWORD rowNum;//数据个数（行数），占4字节
	field *fields;
	DWORD *_RowID;
	RowData **data;
	void WriteToFile(char *filename);
	void WriteToTextFile(char *f);
	void ReadFromFile(char *filename);
};
#endif