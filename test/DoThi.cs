using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_G
{
    class Node
    {
        public int Dinh;
        public int TrongSo;
        public Node Next;

        public Node(int dinh, int trongSo)
        {
            this.TrongSo = trongSo;
            this.Dinh = dinh;
            this.Next = null;
        }
        public Node(int dinh)
        {
            this.Dinh = dinh;
            this.Next = null;
        }
    }

    class DoThi
    {
        public int soDinh;
        public Node[] Lists;

        public DoThi(int soDinh)
        {
            this.soDinh = soDinh;
            this.Lists = new Node[soDinh];
            for (int i = 0; i < soDinh; i++)
            {
                this.Lists[i] = null;
            }
        }

        public void ThemCanh(int src, Node node)
        {
            node.Next = this.Lists[src];
            this.Lists[src] = node;
        }

        public void InDoThi()
        {
            for (int i = 0; i < this.soDinh; i++)
            {
                Console.WriteLine("Đỉnh {0}:", i);
                Node node = this.Lists[i];
                while (node != null)
                {
                    Console.WriteLine(" -> {0}, ({1})", node.Dinh, node.TrongSo);
                    node = node.Next;
                }
            }
        }

    }
}
