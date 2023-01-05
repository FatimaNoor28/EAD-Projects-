using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL
    {
        protected void Save(string fileName, string data)
        {
            StreamWriter sw = new StreamWriter(fileName, append: true);
            sw.Write(data);
            sw.Close();
        }

        protected List<String> Read(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            List<String> list = new List<String>();
            for(String s = sr.ReadLine(); s != null;)
            {
                list.Add(s);
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
    }
}
