using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantsVsZombiesTool;
using System.Runtime.InteropServices;
namespace readname
{
   public class BaseFind
    {
        //00596028    85C0            TEST EAX,EAX
        //0059602A    0F84 0C0A0000   JE DragonNe.00596A3C
        //00596030    8B0D E074CB00   MOV ECX,DWORD PTR DS:[CB74E0]
        //00596036    50              PUSH EAX
        //00596037    A1 E474CB00     MOV EAX,DWORD PTR DS:[CB74E4]
        //0059603C    50              PUSH EAX
        //0059603D    51              PUSH ECX
        //0059603E    E8 3DC3E6FF     CALL DragonNe.00402380
        //00596043    83C4 0C         ADD ESP,0C
        //00596046    84C0            TEST AL,AL
        //00596048    0F84 EE090000   JE DragonNe.00596A3C
        //0059604E    833D E874CB00 0>CMP DWORD PTR DS:[CB74E8],0
        //00596055    0F84 E1090000   JE DragonNe.00596A3C
        //0059605B    8BCE            MOV ECX,ESI
        //0059605D    E8 8E34EEFF     CALL DragonNe.004794F0
        //00596062    83F8 01         CMP EAX,1
        //00596065    898424 D0000000 MOV DWORD PTR SS:[ESP+D0],EAX
        //0059606C    0F8E CA090000   JLE DragonNe.00596A3C
        //00596072    33C9            XOR ECX,ECX
        //00596074    85C0            TEST EAX,EAX
        //00596076    894C24 78       MOV DWORD PTR SS:[ESP+78],ECX
        //0059607A    0F8E BC090000   JLE DragonNe.00596A3C
        //00596080    EB 07           JMP SHORT DragonNe.00596089
        //00596082    8BB424 A8000000 MOV ESI,DWORD PTR SS:[ESP+A8]
        //00596089    8BC6            MOV EAX,ESI
        //0059608B    E8 C035EEFF     CALL DragonNe.00479650
        //00596090    8BF8            MOV EDI,EAX
        //00596092    85FF            TEST EDI,EDI
        //00596094    897C24 44       MOV DWORD PTR SS:[ESP+44],EDI
        //00596098    0F84 86090000   JE DragonNe.00596A24
        //0059609E    807F 76 00      CMP BYTE PTR DS:[EDI+76],0
        //005960A2    0F85 7C090000   JNZ DragonNe.00596A24

        public static int FindBaseAddr()
        {
            int findresult = 0;
            int StartAddr = 0x0041A300;// 0x500000; //这里定义一个边界。只搜索这一部分的内存 {uckYx-A  
            int StopAddr = 0x650000; //如果超过了，那肯定就不是我们需要的了。 Ppx*  
            int curaddr = StartAddr;
            byte[] data110 = { 0x85, 0xc0, 0x0f, 0x84 };
            byte[] data111 = { 0x50, 0xa1 };
            byte[] data112 = { 0x50, 0x51, 0xe8 };
            byte[] data113 = { 0x83, 0xc4, 0x0c, 0x84, 0xc0, 0x0f, 0x84 };
            byte[] data114 = { 0x83, 0x3d };
            byte[] data115 = { 0x0f, 0x84 };
            byte[] data116 = { 0x8b, 0xce, 0xe8 };
            byte[] data117 = { 0x83, 0xf8,0x01, 0x89, 0x84, 0x24 };
            byte[] data118 = { 0x0f, 0x8e };
            byte[] data119 = { 0x33, 0xc9, 0x85, 0xc0, 0x89, 0x4C, 0x24 };
            byte[] data1110 = { 0x0F, 0x8E };
            byte[] data1111 = { 0xEB };
            byte[] data1112 = { 0x8B, 0xB4, 0x24 };
            byte[] data1113 = { 0x8B, 0xC6, 0xE8 };
            byte[] data1114 = { 0x8B, 0xF8, 0x85, 0xFF, 0x89, 0x7C, 0x24 };
            byte[] data1115 = { 0x0F, 0x84 };
            byte[] data1116 = { 0x80, 0x7F };
            byte[] data1117 = { 0x0F, 0x85 };
            byte[][] data = new byte[18][];
            data[0] = new byte[4];
            data[1] = new byte[2];
            data[2] = new byte[3];
            data[3] = new byte[7];
            data[4] = new byte[2];
            data[5] = new byte[2];
            data[6] = new byte[3];
            data[7] = new byte[6];
            data[8] = new byte[2];
            data[9] = new byte[7];
            data[10] = new byte[2];
            data[11] = new byte[1];
            data[12] = new byte[3];
            data[13] = new byte[3];
            data[14] = new byte[7];
            data[15] = new byte[2];
            data[16] = new byte[2];
            data[17] = new byte[2];
            IntPtr hProcess = Helper.OpenProcess(0x1F0FFF, false, Helper.GetPidByProcessName("dragonnest"));
            while (curaddr < StopAddr)
            {
                try
                {

                    Helper.ReadMemoryValue(curaddr + 0x6, ref  data[0], hProcess);
                    if (BitConverter.ToString(data[0]) == BitConverter.ToString(data110))
                    {
                        Helper.ReadMemoryValue(curaddr + 0x14, ref data[1], hProcess);
                        if (BitConverter.ToString(data[1]) == BitConverter.ToString(data111))
                        {
                            Helper.ReadMemoryValue(curaddr + 0x1a, ref data[2], hProcess);
                            if (BitConverter.ToString(data[2]) == BitConverter.ToString(data112))
                            {
                                Helper.ReadMemoryValue(curaddr + 0x21, ref data[3], hProcess);
                                if (BitConverter.ToString(data[3]) == BitConverter.ToString(data113))
                                {
                                    Helper.ReadMemoryValue(curaddr + 0x2c, ref data[4], hProcess);
                                    if (BitConverter.ToString(data[4]) == BitConverter.ToString(data114))
                                    {
                                        Helper.ReadMemoryValue(curaddr + 0x33, ref data[5], hProcess);
                                        if (BitConverter.ToString(data[5]) == BitConverter.ToString(data115))
                                        {
                                            Helper.ReadMemoryValue(curaddr + 0x39, ref data[6], hProcess);
                                            if (BitConverter.ToString(data[6]) == BitConverter.ToString(data116))
                                            {
                                                Helper.ReadMemoryValue(curaddr + 0x40, ref data[7], hProcess);
                                                if (BitConverter.ToString(data[7]) == BitConverter.ToString(data117))
                                                {
                                                    Helper.ReadMemoryValue(curaddr + 0x4a, ref data[8], hProcess);
                                                    if (BitConverter.ToString(data[8]) == BitConverter.ToString(data118))
                                                    {
                                                        Helper.ReadMemoryValue(curaddr + 0x50, ref data[9], hProcess);
                                                        if (BitConverter.ToString(data[9]) == BitConverter.ToString(data119))
                                                        {
                                                            Helper.ReadMemoryValue(curaddr + 0x58, ref data[10], hProcess);
                                                            if (BitConverter.ToString(data[10]) == BitConverter.ToString(data1110))
                                                            {
                                                                Helper.ReadMemoryValue(curaddr + 0x5e, ref data[11], hProcess);
                                                                if (BitConverter.ToString(data[11]) == BitConverter.ToString(data1111))
                                                                {
                                                                    Helper.ReadMemoryValue(curaddr + 0x60, ref data[12], hProcess);
                                                                    if (BitConverter.ToString(data[12]) == BitConverter.ToString(data1112))
                                                                    {
                                                                        Helper.ReadMemoryValue(curaddr + 0x67, ref data[13], hProcess);
                                                                        if (BitConverter.ToString(data[13]) == BitConverter.ToString(data1113))
                                                                        {
                                                                            Helper.ReadMemoryValue(curaddr + 0x6e, ref data[14], hProcess);
                                                                            if (BitConverter.ToString(data[14]) == BitConverter.ToString(data1114))
                                                                            {
                                                                                Helper.ReadMemoryValue(curaddr + 0x76, ref data[15], hProcess);
                                                                                if (BitConverter.ToString(data[15]) == BitConverter.ToString(data1115))
                                                                                {
                                                                                    Helper.ReadMemoryValue(curaddr + 0x7c, ref data[16], hProcess);
                                                                                    if (BitConverter.ToString(data[16]) == BitConverter.ToString(data1116))
                                                                                    {
                                                                                        Helper.ReadMemoryValue(curaddr + 0x80, ref data[17], hProcess);
                                                                                        if (BitConverter.ToString(data[17]) == BitConverter.ToString(data1117))
                                                                                        {
                                                                                            findresult = curaddr;
                                                                                            byte[] result = new byte[4];
                                                                                            Helper.ReadMemoryValue(curaddr + 0x2, ref  result, "dragonnest");
                                                                                            findresult = BitConverter.ToInt32(result, 0);
                                                                                            Helper.CloseHandle(hProcess);
                                                                                            return findresult;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                                                                                                                                                                                              
                }
                catch (Exception)
                {
                    ;
                }
                Console.WriteLine(curaddr.ToString("X"));
                curaddr++;
            }
            Helper.CloseHandle(hProcess);
            return findresult;
        }
    }
}
