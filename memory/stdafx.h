// stdafx.h : 标准系统包含文件的包含文件，
// 或是经常使用但不常更改的
// 特定于项目的包含文件
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             //  从 Windows 头文件中排除极少使用的信息
// Windows 头文件:
#include <windows.h>

#include <iostream>
#include <tlhelp32.h>
using namespace std;
int   GetPID(char *ProcessName);
long   FindNext(HANDLE lProcHand,long lFindAdd);
bool   FindInit(long lFindNum ,long lLen,bool lPrivate,bool lImage,bool lMapped);
long   GetErr();
void WriteDn();

// TODO: 在此处引用程序需要的其他头文件
