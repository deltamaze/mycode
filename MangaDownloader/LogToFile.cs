using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader
{
    public static class LogToFile
    {
        public static void Write(string message)
        {
            string logPath = "log.txt";
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMddhhmmss"));
            sb.Append(" : ");
            sb.Append(message);

            //create logfile if it does not exist
            if (!File.Exists(logPath))
            {
                File.Create(logPath);
            }
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(sb.ToString());
            }


        }
    }
}
