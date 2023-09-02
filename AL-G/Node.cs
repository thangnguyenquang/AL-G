using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AL_G
{
    public partial class Node : UserControl
    {
        public Node()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            Rectangle rec = new Rectangle(this.Location, this.Size);
            path.AddArc(rec, 0, 360);
            Ten.Location = new Point(Tam.X - 10, Tam.Y - 10);
            Ten.Font = new Font(this.Font, FontStyle.Bold);
            Ten.ForeColor = Color.Black;
            Ten.Enabled = false;

            this.Controls.Add(Ten);
            this.Region = new Region(path);
        }

        private int iD;
        public int ID { get => iD; set => iD = value; }

        Point tam;
        public Point Tam
        {
            get { return new Point((this.Width / 2) + this.Location.X, this.Location.Y + (this.Height / 2)); }
        }

        Label ten = new Label();
        public Label Ten
        {
            get { return ten; }
            set { ten = value; }
        }
    }
}
