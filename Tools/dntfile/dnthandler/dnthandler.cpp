// dnthandler.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "dnthandler.h"

DNTFile myfile;

 

DNTHANDLER_API void LoadDntFile(char *filename)
{
	myfile.ReadFromFile(filename);
}
DNTHANDLER_API void SaveDntFile(char *filename)
{
	myfile.WriteToFile(filename);
}
DNTHANDLER_API int GetRow()
{
	return myfile.rowNum;
}
DNTHANDLER_API int GetCol()
{
	return myfile.colNum;
}
DNTHANDLER_API char *GetTitle(int col)
{
	return myfile.fields[col].szText;
}
DNTHANDLER_API char *GetValue(int row, int col)
{
	char *value=new char[100];
	switch (myfile.fields[col].dbFieldType)
	{
	case FieldTypeWord:
		if (myfile.data[row][col].wLen == 0)
			return 0;
		else
		{
			return myfile.data[row][col].szText;
		}
		

		break;
	case FieldTypeBool:
		sprintf_s(value,100, "%d", myfile.data[row][col].boolvalue);
		break;
	case FieldTypeInt:
		sprintf_s(value, 100, "%d", myfile.data[row][col].intvalue);
		break;
	case FieldTypePercent:
		sprintf_s(value, 100, "%f", myfile.data[row][col].percentvalue);
		break;
	case FieldTypeFloat:
		sprintf_s(value, 100, "%f", myfile.data[row][col].floatvalue);
		break;
	}
	return value;
}
DNTHANDLER_API void SetValue(int row, int col, char *value)
{
	switch (myfile.fields[col].dbFieldType)
	{
	case FieldTypeWord:
		myfile.data[row][col].wLen=strlen(value);
		myfile.data[row][col].szText = new char[myfile.data[row][col].wLen+1];
		memcpy(myfile.data[row][col].szText, value, myfile.data[row][col].wLen);
		myfile.data[row][col].szText[myfile.data[row][col].wLen] = '0';
		break;
	case FieldTypeBool:
		myfile.data[row][col].boolvalue = atoi(value);
		break;
	case FieldTypeInt:
		myfile.data[row][col].intvalue=atoi(value);
		break;
	case FieldTypePercent:
		myfile.data[row][col].percentvalue = atof(value);// sprintf(value, "%f", myfile.data[row][col].percentvalue);
		break;
	case FieldTypeFloat:
		myfile.data[row][col].floatvalue = atof(value);
		break;
	}
}
