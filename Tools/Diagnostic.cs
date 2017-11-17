using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.Tools
{
    public static class Diagnostic
    {
        private static System.IO.StreamWriter LogFile;

        public static void WriteMessage(string message)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("HH.mm.ss") + "]" + message);
            LogFile.WriteLine("[" + DateTime.Now.ToString("HH.mm.ss") + "]" + message);
            LogFile.Flush();
        }

        static Diagnostic()
        {
            try
            {
                if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Logs"))
                {
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Logs");
                }
                LogFile = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\log" + DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss") + ".txt");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
