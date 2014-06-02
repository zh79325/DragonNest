// dntfile.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	DNTFile df;
	df.ReadFromFile("itemtable_favor.dnt");
	df.WriteToFile("2.dnt");
	return 0;
}

