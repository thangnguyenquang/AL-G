﻿using System;
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

        public Node()
        {

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

        //Thêm cuối
        //public void ThemCanh(int src, int des, int trongSo)
        //{
        //    Node newNode = new Node(des, trongSo);
        //    if (this.Lists[src] == null)
        //    {
        //        this.Lists[src] = newNode;
        //    }
        //    else
        //    {
        //        Node currentNode = this.Lists[src];
        //        while (currentNode.Next != null)
        //        {
        //            currentNode = currentNode.Next;
        //        }
        //        currentNode.Next = newNode;
        //    }
        //}

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

        //public void ThemCanh(int src, int des)
        //{
        //    Node newNode = new Node(des);
        //    if (this.Lists[src] == null)
        //    {
        //        this.Lists[src] = newNode;
        //    }
        //    else
        //    {
        //        Node currentNode = this.Lists[src];
        //        while (currentNode.Next != null)
        //        {
        //            currentNode = currentNode.Next;
        //        }
        //        currentNode.Next = newNode;
        //    }
        //}

        public int TrongSoCanh(int src, int des)
        {
            int trongSo = 0;
            Node node = this.Lists[src];
            while (node != null)
            {
                if (node.Dinh == des)
                {
                    trongSo = node.TrongSo;
                    break;
                }
                node = node.Next;
            }
            return trongSo;
        }

        public void XoaCanh(int src, int des)
        {
            if (!Contains(src, des))
            {
                return;
            }
            Node node = this.Lists[src];
            Node prevNode = null;
            while (node != null && node.Dinh != des)
            {
                if (node.Dinh == des)
                {
                    prevNode = node;
                }
                node = node.Next;
            }
            if (prevNode == null)
            {
                this.Lists[src] = node.Next;
            }
            else
            {
                prevNode.Next = node.Next;
            }
        }


        public bool Contains(int src, int des)
        {
            bool tonTai = false;
            Node node = this.Lists[src];
            while (node != null)
            {
                if (node.Dinh == des)
                {
                    tonTai = true;
                    break;
                }
                node = node.Next;
            }
            return tonTai;
        }
    }

    class DoThiStack
    {
        public int top;
        public int soDinh;
        public Node[][] Lists;

        public DoThiStack(int soDinh)
        {
            this.top = -1;
            this.soDinh = soDinh;
            this.Lists = new Node[soDinh][];
            for (int i = 0; i < soDinh; i++)
            {
                this.Lists[i] = new Node[soDinh];
                for (int j = 0; j < soDinh; j++)
                {
                    this.Lists[i][j] = null;
                }
            }
        }

        public bool IsEmpty()
        {
            return this.top == -1;
        }

        public bool IsFull()
        {
            return this.top == this.soDinh - 1;
        }
        public int Count()
        {
            return this.top + 1;
        }

        //push
        public void ThemCanh(int src, int des, int trongSo)
        {
            Node newNode = new Node(des, trongSo);
            if (!IsFull())
            {
                top = top + 1;
                this.Lists[src][top] = newNode;
            }
        }

        public void ThemCanh(int src, int des)
        {
            Node newNode = new Node(des);
            if (!IsFull())
            {
                top = top + 1;
                this.Lists[src][top] = newNode;
            }
        }

        //public void ThemCanh(int src, int des)
        //{
        //    Node newNode = new Node(des);
        //    if (this.Lists[src] == null)
        //    {
        //        this.Lists[src] = newNode;
        //    }
        //    else
        //    {
        //        Node currentNode = this.Lists[src];
        //        while (currentNode.Next != null)
        //        {
        //            currentNode = currentNode.Next;
        //        }
        //        currentNode.Next = newNode;
        //    }
        //}

        //Pop
        public Node LayCanh(int src)
        {
            Node node;
            if (!IsEmpty())
            {
                node = this.Lists[src][top];
                top = top - 1;
                return node;
            }
            else
            {
                return null;
            }
        }

        public void XoaCanh(int src, int des)
        {
            if (!Contains(src, des))
            {
                return;
            }
            Node[] node = this.Lists[src];
            for (int i = 0; i < node.Count(x => x != null); i++)
            {
                if (node[i]?.Dinh == des)
                {
                    node[i] = null;
                    node[i] = node[i + 1];
                    node[i + 1] = null;
                    break;
                }
            }
        }


        public bool Contains(int src, int des)
        {
            bool tonTai = false;
            Node[] node = this.Lists[src];
            if (node?.Count() > 0)
            {
                for (int i = 0; i < node.Count(x => x != null); i++)
                {
                    if (node[i]?.Dinh == des)
                    {
                        tonTai = true;
                        break;
                    }
                }
            }
            return tonTai;
        }

        public int TrongSoCanh(int src, int des)
        {
            int trongSo = 0;
            Node[] node = this.Lists[src];
            if (node?.Count() > 0)
            {
                for (int i = 0; i < node.Count(x => x != null); i++)
                {
                    if (node[i]?.Dinh == des)
                    {
                        trongSo = (int)(node[i]?.TrongSo);
                        break;
                    }
                }
            }
            return trongSo;
        }
    }
}
