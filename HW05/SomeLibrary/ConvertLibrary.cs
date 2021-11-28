using System.IO;

namespace MyLibrary
{
    public class ConvertLibrary : IObserver
    {
        private readonly string fileNameAsJpg = "new_scan.jpg";
        private readonly string fileNameAsBmp = "new_scan.bmp";
        private readonly string logFilePath = "log.txt";
        public void Update(IScanner subject)
        {
            var cpu = (subject as Scanner).LoadCPU;
            var ram = (subject as Scanner).LoadRAM;
            if (cpu > 50 && cpu < 80)
            {
                WriteLog($"Внимание!!! Загрузка процессора: {cpu}%");
            }
            if (ram > 60 && ram < 90)
            {
                WriteLog($"Внимание!!! Объём свободной оперативной памяти: {100-ram}%");
            }
            if (cpu > 80)
            {
                WriteLog($"Критическая загрузка процессора: {cpu}%");
            }
            if (ram > 90)
            {
                WriteLog($"Критический объём свободной оперативной памяти: {100 - ram}%");
            }
            
        }
        private void WriteLog(string info)
        {
            using(StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine(info);
            }
        }
        public void SaveAsJpg(byte[] bytes)
        {
            File.WriteAllBytes(fileNameAsJpg, bytes);
            WriteLog($"File save as: {fileNameAsJpg}");
        }
        public void SaveAsBmp(byte[] bytes)
        {
            File.WriteAllBytes(fileNameAsBmp, bytes);
            WriteLog($"File save as: {fileNameAsBmp}");
        }
    }
}
