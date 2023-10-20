using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_G
{
    class Node
    {
        public int Dinh { get; set; }
        public int TrongSo { get; set; }
        public Node Next { get; set; }

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

        public void ThemCanh(int src, int des, int trongSo)
        {
            Node newNode = new Node(des, trongSo);
            newNode.Next = this.Lists[src];
            this.Lists[src] = newNode;
        }

        public void ThemCanh(int src, int des)
        {
            Node newNode = new Node(des);
            newNode.Next = this.Lists[src];
            this.Lists[src] = newNode;
        }

        // Kiểm tra đỉnh kề thêm vào đã tồn tại chưa
        public bool KiemTraDinh(int src, int dinh)
        {
            bool tonTai = false;
            Node node = this.Lists[src];
            while (node != null)
            {
                if (node.Dinh == dinh)
                {
                    // Đỉnh kề tồn tại
                    tonTai = true;
                    break;
                }
                node = node.Next;
            }
            return tonTai;
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
