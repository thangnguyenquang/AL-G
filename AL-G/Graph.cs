using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_G
{
    class Node
    {
        public int Vertex;
        public Node Next;

        public Node(int vertex)
        {
            this.Vertex = vertex;
            this.Next = null;
        }
    }

    class Graph
    {
    }
}
