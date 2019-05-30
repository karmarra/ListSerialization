using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSerialization
{
    class ListNode
    {
        public ListNode Prev;
        public ListNode Next;
        public ListNode Rand; // произвольный элемент внутри списка
        public string Data;

        public ListNode(string data)
        {
            Data = data;
        }
    }


    class ListRand
    {
        private List<ListNode> _nodeCollection = new List<ListNode>();

        public ListNode Head;
        public ListNode Tail;
        public int Count;


        public void Add(string data)
        {
            var node = new ListNode(data);
            Add(node);
        }

        public void Add(ListNode node)
        {
            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            Count++;
            _nodeCollection.Add(node);
        }

        public void SetRand() // проставляем ссылки на случайные элементы в уже заполненном списке
        {
            var random = new Random();
            foreach(var node in _nodeCollection)
                node.Rand = _nodeCollection[random.Next(Count)];
        }

        public void Serialize(FileStream s)
        {
            Console.WriteLine("Serialization...");
            Console.WriteLine();

            using (var w = new StreamWriter(s))
                foreach (var node in _nodeCollection)
                {
                    var line = node.Data + ":" + _nodeCollection.IndexOf(node.Rand);
                    w.WriteLine(line);
                    Console.WriteLine(line);
                }
            Console.WriteLine("Serialization complete!");
            Console.WriteLine();
        }

        public static ListRand Deserialize(FileStream s)
        {
            var linkList = new List<int>(); // временный список позиций случайных элементов
            var target = new ListRand();

            using (var sr = new StreamReader(s))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        var arr = line.Split(':');
                        target.Add(arr[0]);
                        linkList.Add(Convert.ToInt32(arr[1]));
                    }
                }
            }

            for (int i = 0; i < target.Count; i++)
                target[i].Rand = target[linkList[i]];

            Console.WriteLine("Deserialization complete!");
            Console.WriteLine();

            return target;
        }

        public ListNode this[int index] //индексатор
        {
            get => _nodeCollection[index];
            set => _nodeCollection[index] = value;
        }
    }
}

