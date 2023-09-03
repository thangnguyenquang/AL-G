using AL_G;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThi graph = new DoThi(5);

            // Thêm các cạnh
            graph.ThemCanh(0, new Node(1));
            graph.ThemCanh(0, new Node(2));
            graph.ThemCanh(1, new Node(2));
            graph.ThemCanh(2, new Node(3));
            graph.ThemCanh(3, new Node(4));

            // In đồ thị
            graph.InDoThi();
        }
    }
}
