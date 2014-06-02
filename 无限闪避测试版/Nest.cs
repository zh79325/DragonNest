using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
namespace 无限闪避
{
    public class Nest
    {
        public Nest(string name, int num)
        {
            nestname = name;
            movepointnum = num;
            movepointname = new string[num];
            movex = new short[num];
            movey = new short[num];
        }
        public Nest(Nest nst)
        {
            int n = nst.movepointnum;
            nestname = nst.nestname;
            movepointname = new string[n];
            movex = new short[n];
            movey = new short[n];
            for (int i = 0; i < n; i++)
            {
                movex[i] = nst.movex[i];
                movey[i] = nst.movey[i];
                movepointname[i] = nst.movepointname[i];
            }
            movepointnum = n;
        }
        public void Resize(int n)
        {
            if (movepointnum > 0)
            {
                movepointname = null;
                movex = null;
                movey = null;
            }
                movepointname = new string[n];
                movex = new short[n];
                movey = new short[n];
                movepointnum = n;
            
        }
        public void Reset(DataTable ds)
        {
            int n = ds.Rows.Count;
            Resize(n);
            for (int i = 0; i < movepointnum; i++)
            {
                movepointname[i] =(string)ds.Rows[i][0];
                movex[i]=(short)ds.Rows[i][1];
                movey[i] = (short)ds.Rows[i][2];
            }
        }
        public int ReadNest(string filename)
        {
            StreamReader read = new StreamReader(filename, Encoding.GetEncoding("gb2312"));
            string tempstring ="";
            while (!read.EndOfStream)
            {
                tempstring= read.ReadLine();
                if (tempstring.Substring(1) == nestname)
                {
                    for (int j = 0; j < movepointnum; j++)
                    {
                        movepointname[j] = read.ReadLine();
                        string xlocate = read.ReadLine();
                        string ylocate = read.ReadLine();
                        xlocate = xlocate.Substring(xlocate.IndexOf("=") + 1);
                        ylocate = ylocate.Substring(ylocate.IndexOf("=") + 1);
                        movex[j] = Convert.ToInt16(xlocate);
                        movey[j] = Convert.ToInt16(ylocate);
                    }
                    break;
                }
               
            }
            read.Close();
           
            return -1;

        }
        public int movepointnum;
        public string nestname;
        public string[] movepointname;
        public short[] movex;
        public short[] movey;
    }
}
