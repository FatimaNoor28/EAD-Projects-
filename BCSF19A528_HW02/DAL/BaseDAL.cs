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
        protected void Save(String filename, String data)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.Flush();
            sw.Write(data);
            sw.Close();
        }

        protected String Read(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            String data;
            if ((data = sr.ReadLine()) == null)
            {
                sr.Close(); 
                return null;

            }
            sr.Close();
            return data;
        }
    }
}
