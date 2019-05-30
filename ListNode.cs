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
            for (int i = 0; i < _nodeCollection.Count; i++)
                _nodeCollection[i].Rand = _nodeCollection[random.Next(Count)];
        }

        public void Serialize(FileStream s)
        {
        }

        public void Deserialize(FileStream s)
        {
        }

        public ListNode this[int index] //индексатор
        {
            get => _nodeCollection[index];
            set => _nodeCollection[index] = value;
        }
    }
}

