using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL
{
    public class BaseDAL
    {
        protected void Save(string filename, String line)
        {
            StreamWriter sw = new StreamWriter(filename, append: true);
            sw.WriteLine(line);
            sw.Close();

        }

        protected List<String> Read(String filename)
        {
            StreamReader sr = new StreamReader(filename);
            List<String> list = new List<string>();

            for (string i = sr.ReadLine(); i != null;)          //i = sr.ReadLine();  while(i!=null)
            {
                list.Add(i);
                i = sr.ReadLine(); 
            }
            sr.Close();
            return list;
        }
    }
}
