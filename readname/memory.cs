using System;
using System.Text;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PlantsVsZombiesTool
{

    public abstract class Helper
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                IntPtr lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesRead
            );

        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern void CloseHandle
            (
                IntPtr hObject
            );

        //写内存
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                int[] lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesWritten
            );

        //获取窗体的进程标识ID
        public static int GetPid(string windowTitle)
        {
            int rs = 0;
            Process[] arrayProcess = Process.GetProcesses();
            foreach (Process p in arrayProcess)
            {
                if (p.MainWindowTitle.IndexOf(windowTitle) != -1)
                {
                    rs = p.Id;
                    break;
                }
            }

            return rs;
        }

        //根据进程名获取PID
        public static int GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);

            foreach (Process p in arrayProcess)
            {
                return p.Id;
            }
            return 0;
        }

        //根据窗体标题查找窗口句柄（支持模糊匹配）
        public static IntPtr FindWindow(string title)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.IndexOf(title) != -1)
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        //读取内存中的值
        public static int ReadMemoryValue32(int baseAddress, string processName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName));
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }


        public static short ReadMemoryValue16(int baseAddress, string processName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName));
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 2, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt16(byteAddress);
            }
            catch
            {
                return 0;
            }
        }


        public static int ReadMemoryValue32(int baseAddress, int processName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processName);
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        public static float ReadMemoryFloat16(int baseAddress, int processName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processName);
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                byte[] folatdata = new byte[4];
                Marshal.Copy(byteAddress, folatdata, 0, 4);
                return BitConverter.ToSingle(folatdata, 0);
            }
            catch
            {
                return 0;
            }
        }
        public static short ReadMemoryValue16(int baseAddress, int processName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processName);
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 2, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt16(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        //将值写入指定内存地址中
        public static void WriteMemoryValue32(int baseAddress, string processName, int value)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName)); //0x1F0FFF 最高权限
            WriteProcessMemory(hProcess, (IntPtr)baseAddress, new int[] { value }, 4, IntPtr.Zero);
            CloseHandle(hProcess);
        }

        public static void WriteMemoryValue16(int baseAddress, string processName, short value)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName)); //0x1F0FFF 最高权限
            WriteProcessMemory(hProcess, (IntPtr)baseAddress, new int[] { value }, 2, IntPtr.Zero);
            CloseHandle(hProcess);
        }

        public static bool ReadMemoryValue(int baseAddress, ref byte []buffer ,string processName)
        {
            try
            {
               
            
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName));
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress,buffer.Length, IntPtr.Zero); //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ReadMemoryValue(int baseAddress, ref byte[] buffer, IntPtr hProcess)
        {
            try
            {


               IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
             //   IntPtr hProcess = OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName));
                ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, buffer.Length, IntPtr.Zero); //将制定内存中的值读入缓冲区
             //   CloseHandle(hProcess);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

