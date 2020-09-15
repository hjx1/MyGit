using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exobject
{
    class Program
    {
        static void Main(string[] args)
        {
            // int U = 78;
            // string i = U.CastTo<string>();
            Console.WriteLine(DateTime.Now.Day);
            RWF("XX");
            RWF("XX");
            RWF("XX");
            RWF("XX");
            RWF("XX");
            Console.ReadLine();        
        }

        public static void RWF(string path)
        {
            int count = 0;
            string fullpath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, path);
            FileStream fs = new FileStream(fullpath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
            //FileStream fss = new FileStream(fullpath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding(936));
            string str = "";
            string[] xu = new String[2];
            str = sr.ReadLine();
           
            if (str == null)
            {
                count = 1;
                fs.Seek(0, SeekOrigin.Begin);
                fs.SetLength(0);
                sw.Write(DateTime.Now.ToString("yyyy-MM-dd") + ":" + count);

            }
            else
            {
                xu = str.Split(':');
                if (xu[0] == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    xu[1] = (xu[1].CastTo<int>() + 1).ToString();
                    count = xu[1].CastTo<int>();
                    fs.Seek(0, SeekOrigin.Begin);   //清空文本文件原有内容
                    fs.SetLength(0);     //清空文本文件原有内容
                    sw.Write(xu[0] + ":" + xu[1]);
                  //  sw.WriteLine();
                }
                else
                {
                    count = 1;
                    fs.Seek(0, SeekOrigin.Begin);
                    fs.SetLength(0);
                    sw.Write(DateTime.Now.ToString("yyyy-MM-dd") + ":" + count);
                }

            }
            sw.Close();
            sr.Close();
        }

    }
}
