using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.santehsvit.ua
{
    class CsvWriter
    {
        public static void CreateCsv(string filePath, string Columns)
        {
            FileStream fileStream = null;
            if (!File.Exists(filePath)) //Проверяем есть ли файл
                fileStream = File.Create(filePath); // создаем файл, если его нет
            else
                fileStream = File.Open(filePath, FileMode.Append);  //если есть то записиваем данные в конец
            StreamWriter output = new StreamWriter(fileStream);
            output.Write(Columns);
            output.Close();
        }
    }
}
