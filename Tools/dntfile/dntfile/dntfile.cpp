// dntfile.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	DNTFile df;
	df.ReadFromFile("itemtable_favor.dnt");
	df.WriteToFile("2.dnt");
	return 0;
}

