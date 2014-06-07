// dntfile.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	
	char *filename = "1/cashcommodity_org.dnt";
	DNTFile df;
	df.ReadFromFile(filename);
	df.WriteToTextFile("1/cashcommodity_org.txt");
	RowData d;
	d.boolvalue = 1;
	d.dbFieldType = FieldTypeBool;
	field replacetitle;
	replacetitle.szText = "_OnSale";


	RowData searchtarget;
	searchtarget.dbFieldType = FieldTypeBool;

	searchtarget.boolvalue = 0;

	field searchtitle;
	searchtitle.szText = "_OnSale";

	int row =0, col = 0;
	while (row < df.rowNum&&row >= 0)
	{
		df.Search(replacetitle, searchtarget, row, col, row + 1);
		if (row >= 0 && col >= 0)
		{
			cout << filename << " => " << row << " " << col << endl;
			df.Replace(replacetitle, d, row, col);
		}
	}
	
	RowData Price;
	Price.intvalue = 1;
	Price.dbFieldType = FieldTypeInt;
	field replacetitlePrice;
	replacetitlePrice.szText = "_Count";
	row = 0;
	col = 0;
	df.Search(replacetitlePrice, Price, row, col);
	Price.intvalue = 10000;
	for (int i = 0; i < df.rowNum; i++)
	{
		df.Replace(replacetitlePrice, Price, i, col);
	}
	replacetitlePrice.szText = "_Price";
	Price.intvalue = 0;
	row = 0;
	col = 0;
	df.Search(replacetitlePrice, Price, row, col);
	Price.intvalue = 0;
	for (int i = 0; i < df.rowNum; i++)
	{
		df.Replace(replacetitlePrice, Price, i, col);
	}

	df.WriteToFile("2.dnt");
	return 0;
}

