using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Node
{
    public int data;
    public Node next;
};

class LinkedList
{
    Node head;

    public LinkedList()
    {
        head = null;
    }

    public void them_cuoi(int newElement)
    {
        Node newNode = new Node();
        newNode.data = newElement;
        newNode.next = null;
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = new Node();
            temp = head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = newNode;
        }
    }

    public void them_dau(int newElement)
    {
        Node newNode = new Node();
        newNode.data = newElement;
        newNode.next = head;
        head = newNode;
    }

    public void xoa_dau()
    {
        if (this.head != null)
        {
            Node temp = this.head;
            this.head = this.head.next;
            temp = null;
        }
    }

    public void xoa_cuoi()
    {
        if (this.head != null)
        {
            if (this.head.next == null)
            {
                this.head = null;
            }
            else
            {
                Node temp = new Node();
                temp = this.head;
                while (temp.next.next != null)
                    temp = temp.next;
                Node lastNode = temp.next;
                temp.next = null;
                lastNode = null;
            }
        }
    }
    public int demNode()
    {
        Node temp = new Node();
        temp = this.head;
        int i = 0;
        while (temp != null)
        {
            i++;
            temp = temp.next;
        }
        return i;
    }
}
