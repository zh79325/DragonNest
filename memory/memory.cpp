// memory.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"


#include<iostream>
#include<fstream>
using namespace std;

int  Base =0x00A8E200,Zhan= 0x1e04 , Gong =0x1e14 , Fa= 0x1e2c , Mu= 0x1dfc,Sec=0x8,xp=0x826,yp=0x82e;
int dest=255,data=0;
int tmp;
short tmp1,tmp2;
DWORD dwNumberOfBytesRead;
short  x=100,y=-100;
int geted=0,moved=0;
int   GetPID(char *ProcessName)
{
	HANDLE hSnapshot = CreateToolhelp32Snapshot (TH32CS_SNAPPROCESS, 0);
	if (!hSnapshot)
	{
		cout<<"CreateToolhelp32Snapshot ERROR!"<<endl;
		return 1;
	}
	PROCESSENTRY32 pe32;
	pe32.dwSize = sizeof(PROCESSENTRY32 );
	
	if (!Process32First (hSnapshot, &pe32))
	{
		cout<<"Process32First ERROR!"<<endl;
	}
	do
	{
		if(!strcmp(pe32.szExeFile,ProcessName))
		{
			return pe32.th32ProcessID;// <<"--"<<pe32.szExeFile<<endl;
		}

	}

	while(Process32Next (hSnapshot, &pe32));

	return -1;
}

extern "C" __declspec(dllexport) void Move()
{
	
	
	HWND hwnd=FindWindow(NULL,"dragonnest.exe");
	long pHandle=(long)OpenProcess(PROCESS_ALL_ACCESS,0,GetPID("dragonnest.exe"));
	ReadProcessMemory((HANDLE)pHandle,(int*)(Base),&tmp,4,0);



	if(geted==1&&moved==0)
	{
		ReadProcessMemory((HANDLE)pHandle,(int*)(tmp+xp),&x,2,0);
		ReadProcessMemory((HANDLE)pHandle,(int*)(tmp+yp),&y,2,0);
		moved=1;
		WriteProcessMemory((HANDLE)pHandle,(int*)(tmp+xp),&tmp1,2,0);
		WriteProcessMemory((HANDLE)pHandle,(int*)(tmp+yp),&tmp2,2,0);
	}
	else if(geted==1&&moved==1)
	{
		moved=0;
		WriteProcessMemory((HANDLE)pHandle,(int*)(tmp+xp),&x,2,0);
		WriteProcessMemory((HANDLE)pHandle,(int*)(tmp+yp),&y,2,0);
	}

	CloseHandle((HANDLE)pHandle);
	

}

extern "C" __declspec(dllexport) void Move1()
{
	ofstream outfile("error.txt");
	int i=0;
	outfile<<++i<<endl;
	HWND hwnd=FindWindow(NULL,"dragonnest.exe");
	outfile<<++i<<endl;
	long pHandle=(long)OpenProcess(PROCESS_ALL_ACCESS,0,GetPID("dragonnest.exe"));
	outfile<<++i<<endl;
	ReadProcessMemory((HANDLE)pHandle,(int*)(Base),&tmp,4,0);

	outfile<<++i<<endl;
	ReadProcessMemory((HANDLE)pHandle,(int*)(tmp+xp),&tmp1,2,0);
	outfile<<++i<<endl;
	ReadProcessMemory((HANDLE)pHandle,(int*)(tmp+yp),&tmp2,2,0);
	outfile<<++i<<endl;
	geted=1;
	moved=0;
	outfile<<++i<<endl;
	CloseHandle((HANDLE)pHandle);
	outfile.close();
}