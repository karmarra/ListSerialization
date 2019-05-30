using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceList = new ListRand();
            var targetList = new ListRand();

            sourceList.Add("первый элемент");
            sourceList.Add("второй элемент");
            sourceList.Add("третий элемент");
            sourceList.Add("четвёртый элемент");
            sourceList.Add("пятый элемент");
            sourceList.Add("шестой элемент");

            sourceList.SetRand();

            try
            {
                var fs = new FileStream("data.txt", FileMode.OpenOrCreate);
                sourceList.Serialize(fs);
                fs.Close();

                fs = new FileStream("data.txt", FileMode.Open);
                targetList = ListRand.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key..");
                Console.Read();
                Environment.Exit(0);
            }

            Console.WriteLine("Mission finished!");
            Console.Read();
        }
    }
}
