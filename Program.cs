using System;
using System.Collections.Generic;
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
        }
    }
}
