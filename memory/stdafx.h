// stdafx.h : ��׼ϵͳ�����ļ��İ����ļ���
// ���Ǿ���ʹ�õ��������ĵ�
// �ض�����Ŀ�İ����ļ�
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             //  �� Windows ͷ�ļ����ų�����ʹ�õ���Ϣ
// Windows ͷ�ļ�:
#include <windows.h>

#include <iostream>
#include <tlhelp32.h>
using namespace std;
int   GetPID(char *ProcessName);
long   FindNext(HANDLE lProcHand,long lFindAdd);
bool   FindInit(long lFindNum ,long lLen,bool lPrivate,bool lImage,bool lMapped);
long   GetErr();
void WriteDn();

// TODO: �ڴ˴����ó�����Ҫ������ͷ�ļ�
