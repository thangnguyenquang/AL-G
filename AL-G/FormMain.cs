using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AL_G
{
    public partial class FormMain : Form
    {
        List<Dinh> dinh = new List<Dinh>();
        Graphics g;
        Random random = new Random();
        Dinh selectNode = new Dinh();

        public FormMain()
        {
            InitializeComponent();
        }

        int soDinh;
        DoThi doThi;
        public bool coHuong = false;
        public bool coTrongSo = false;

        public bool linkedList = false;
        public bool stack = false;

        private void btnNhapDinh_Click(object sender, EventArgs e)
        {
            dgvDsk.Rows.Clear();
            dgvDsk.ReadOnly = false;

            soDinh = int.Parse(txtSlDinh.Text);

            if (soDinh <= 1)
            {
                MessageBox.Show("Số đỉnh phải lớn hơn 1");
                return;
            }
            dgvDsk.ColumnCount = soDinh;
            dgvDsk.RowCount = soDinh;

            for (int i = 0; i < soDinh; i++)
            {
                dgvDsk.Rows[i].HeaderCell.Value = "Đỉnh " + i + "";
                dgvDsk.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        List<Point> listPoint = new List<Point>();

        private void TinhToanToaDo(int soDinh)
        {
            listPoint.Clear();
            double angle = 0;
            int x, y;
            for (int i = 0; i < soDinh; i++)
            {
                if (i != 0)
                    angle += (double)((2 * Math.PI) / soDinh);
                x = (int)((100 - 325) * Math.Cos(angle) - (275 - 275) * Math.Sin(angle) + 325);
                y = (int)((100 - 325) * Math.Sin(angle) + (275 - 275) * Math.Cos(angle) + 275);

                listPoint.Add(new Point(x, y));
            }
            //if (coTrongSo)
            //{
            //    ToaDoCoTrongSo(listPoint);
            //}
        }

        //private void ToaDoCoTrongSo(List<Point> listPoint)
        //{
        //    for (int i = 0; i < soDinh; i++)
        //    {
        //        Node node = doThi.Lists[i];
        //        while (node != null)
        //        {
        //            int x2 = listPoint[node.Dinh].X;
        //            int y2 = listPoint[node.Dinh].Y;
        //            int x1 = listPoint[i].X;
        //            int y1 = listPoint[i].Y;
        //            int khoangCach = (int)Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2);

        //            if (khoangCach == node.TrongSo)
        //            {
        //                node = node.Next;
        //            }
        //            else
        //            {
        //                //double angle = Math.Atan2(y2 - y1, x2 - x1);
        //                double angle = 0;
        //                if (i != 0)
        //                {
        //                    angle += (double)((2 * Math.PI) / soDinh);
        //                }
        //                int x = (int)(x1 + node.TrongSo * Math.Cos(angle));
        //                int y = (int)(y1 + node.TrongSo * Math.Sin(angle));
        //                listPoint[node.Dinh] = new Point(x + (int)((100 - 325) * Math.Cos(angle) - (275 - 275) * Math.Sin(angle) + 325), y + (int)((100 - 325) * Math.Sin(angle) + (275 - 275) * Math.Cos(angle) + 275));
        //                node = node.Next;
        //            }
        //        }
        //    }
        //}

        private void TaoDinh()
        {
            dinh = new List<Dinh>();
            for (int i = 0; i < soDinh; i++)
            {
                Dinh d = new Dinh();
                //d.Location = new Point(random.Next(5, 1100), random.Next(5, 800));
                d.Location = listPoint[i];
                d.ID = (i);
                d.Ten.Text = (i).ToString();
                d.MouseDown += new MouseEventHandler(Node_MouseDown);
                d.MouseUp += new MouseEventHandler(Node_MouseUp);
                dinh.Add(d);
            }
        }

        private void HienDinh()
        {
            pbDoThi.Controls.Clear();
            for (int i = 0; i < dinh.Count; i++)
                if (dinh[i].ID != -1)
                    pbDoThi.Controls.Add(dinh[i]);
        }

        void Node_MouseDown(object sender, MouseEventArgs e)
        {
            selectNode = (Dinh)sender;
            selectNode.Enabled = false;
        }

        void Node_MouseUp(object sender, MouseEventArgs e)
        {
            selectNode = (Dinh)sender;
            if (selectNode != null)
            {
                selectNode.Enabled = true;
            }
            NoiDinh(doThi);
        }

        private void NoiDinh(DoThi doThi)
        {
            g.Clear(pbDoThi.BackColor);
            Pen p = new Pen(Color.Black, 1);
            if (coHuong)
            {
                //p.EndCap = LineCap.ArrowAnchor;
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                p.CustomEndCap = bigArrow;
            }
            else
            {
                p.EndCap = LineCap.NoAnchor;
            }

            for (int i = 0; i < soDinh; i++)
            {
                if (coTrongSo)
                {
                    Node node = doThi.Lists[i];

                    while (node != null)
                    {
                        int k = node.Dinh;
                        if (k < 0) continue;
                        int x = Math.Abs(dinh[i].Tam.X + dinh[k].Tam.X);
                        x = x / 2;
                        int y = Math.Abs(dinh[i].Tam.Y + dinh[k].Tam.Y);
                        y = y / 2;

                        Point trungdiem = new Point(x, y);

                        g.DrawLine(p, dinh[i].Tam, trungdiem);
                        g.DrawLine(p, trungdiem, dinh[k].Tam);
                        g.DrawString(node.TrongSo.ToString(), this.Font, Brushes.Black, x + 6, y + 6);

                        node = node.Next;
                    }
                }
                else
                {
                    Node node = doThi.Lists[i];

                    while (node != null)
                    {
                        int k = node.Dinh;
                        if (k < 0) continue;
                        int x = Math.Abs(dinh[i].Tam.X + dinh[k].Tam.X);
                        x = x / 2;
                        int y = Math.Abs(dinh[i].Tam.Y + dinh[k].Tam.Y);
                        y = y / 2;

                        Point trungdiem = new Point(x, y);

                        g.DrawLine(p, dinh[i].Tam, trungdiem);
                        g.DrawLine(p, trungdiem, dinh[k].Tam);

                        node = node.Next;
                    }
                }
            }
        }

        private void NoiDinhStack(DoThiStack doThi)
        {
            g.Clear(pbDoThi.BackColor); //set màu cho BackGround
            Pen p = new Pen(Color.Black, 1);
            if (coHuong)
            {
                //p.EndCap = LineCap.ArrowAnchor;
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5);
                p.CustomEndCap = bigArrow;
            }
            else
            {
                p.EndCap = LineCap.NoAnchor;
            }

            for (int i = 0; i < soDinh; i++)
            {

                Node[] node = doThi.Lists[i];
                doThi.top = node.Count(x => x != null) - 1;
                while (!doThi.IsEmpty() && node != null)
                {
                    Node data = doThi.LayCanh(i);
                    if (coTrongSo)
                    {
                        int k = data.Dinh;
                        if (k < 0) continue;
                        int x = Math.Abs(dinh[i].Tam.X + dinh[k].Tam.X);
                        x = x / 2;
                        int y = Math.Abs(dinh[i].Tam.Y + dinh[k].Tam.Y);
                        y = y / 2;

                        Point trungdiem = new Point(x, y);

                        g.DrawLine(p, dinh[i].Tam, trungdiem);
                        g.DrawLine(p, trungdiem, dinh[k].Tam);
                        g.DrawString(data.TrongSo.ToString(), this.Font, Brushes.Black, x + 6, y + 6);
                    }
                    else
                    {
                        int k = data.Dinh;
                        if (k < 0) continue;
                        int x = Math.Abs(dinh[i].Tam.X + dinh[k].Tam.X);
                        x = x / 2;
                        int y = Math.Abs(dinh[i].Tam.Y + dinh[k].Tam.Y);
                        y = y / 2;

                        Point trungdiem = new Point(x, y);

                        g.DrawLine(p, dinh[i].Tam, trungdiem);
                        g.DrawLine(p, trungdiem, dinh[k].Tam);

                    }
                }
            }
        }

        private void VeDoThi(DoThi doThi)
        {
            TinhToanToaDo(soDinh);
            TaoDinh();
            HienDinh();
            NoiDinh(doThi);
        }

        private void VeDoThiStack(DoThiStack doThi)
        {
            TinhToanToaDo(soDinh);
            TaoDinh();
            HienDinh();
            NoiDinhStack(doThi);
        }


        private void pbDoThi_Paint(object sender, PaintEventArgs e)
        {
            g = pbDoThi.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void chkbCoHuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbCoHuong.Checked == true)
            {
                coHuong = true;
            }
            else
            {
                coHuong = false;
            }
        }

        private void chkbCoTrongSo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbCoTrongSo.Checked == true)
            {
                coTrongSo = true;
            }
            else
            {
                coTrongSo = false;
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Timming timming = new Timming();
            timming.Start();

            if (!linkedList && !stack)
            {
                cbxCTDL.SelectedIndex = 0;
            }

            dgvDsk.Rows.Clear();
            Random random = new Random();
            if (!string.IsNullOrEmpty(txtSlDinh.Text))
            {
                soDinh = int.Parse(txtSlDinh.Text);
            }
            else
            {
                soDinh = random.Next(3, 13);
            }
            if (soDinh <= 2)
            {
                MessageBox.Show("Số đỉnh phải lớn hơn 2");
                return;
            }
            if (linkedList)
            {
                doThi = new DoThi(soDinh);
                int soDinhKe;
                if (coTrongSo)
                {
                    int dinhKe;
                    int trongSo;
                    for (int i = 0; i < soDinh; i++)
                    {
                        soDinhKe = random.Next(1, soDinh - 1);
                        for (int j = 0; j < soDinhKe; j++)
                        {
                            dinhKe = random.Next(0, soDinh);
                            while (dinhKe == i || doThi.Contains(i, dinhKe))
                            {
                                dinhKe = random.Next(0, soDinh);
                            }
                            trongSo = random.Next(1, 10);
                            doThi.ThemCanh(i, dinhKe, trongSo);
                        }
                    }
                }
                else
                {
                    int dinhKe;
                    for (int i = 0; i < soDinh; i++)
                    {
                        soDinhKe = random.Next(1, soDinh - 1);
                        for (int j = 0; j < soDinhKe; j++)
                        {
                            dinhKe = random.Next(0, soDinh);
                            while (dinhKe == i || doThi.Contains(i, dinhKe))
                            {
                                dinhKe = random.Next(0, soDinh);
                            }
                            doThi.ThemCanh(i, dinhKe);
                        }
                    }
                }
                if (coHuong)
                {
                    DoThiCoHuong(doThi);
                }
                else
                {
                    DoThiVoHuong(doThi);
                    if (coTrongSo)
                    {
                        DoThiCoTrongSo(doThi);
                    }
                }

                HienDanhSachKe(doThi);
                VeDoThi(doThi);
            }

            if (stack)
            {
                DoThiStack doThi = new DoThiStack(soDinh);
                int soDinhKe;
                if (coTrongSo)
                {
                    int dinhKe;
                    int trongSo;
                    for (int i = 0; i < soDinh; i++)
                    {
                        doThi.top = -1;
                        soDinhKe = random.Next(1, soDinh - 1);
                        for (int j = 0; j < soDinhKe; j++)
                        {
                            dinhKe = random.Next(0, soDinh);
                            while (dinhKe == i || doThi.Contains(i, dinhKe))
                            {
                                dinhKe = random.Next(0, soDinh);
                            }
                            trongSo = random.Next(1, 10);
                            doThi.ThemCanh(i, dinhKe, trongSo);
                        }
                    }
                }
                else
                {
                    int dinhKe;
                    for (int i = 0; i < soDinh; i++)
                    {
                        doThi.top = -1;
                        soDinhKe = random.Next(1, soDinh - 1);
                        for (int j = 0; j < soDinhKe; j++)
                        {
                            dinhKe = random.Next(0, soDinh);
                            while (dinhKe == i || doThi.Contains(i, dinhKe))
                            {
                                dinhKe = random.Next(0, soDinh);
                            }
                            doThi.ThemCanh(i, dinhKe);
                        }
                    }
                }
                //if (coHuong)
                //{
                //    DoThiCoHuongStack(doThi);
                //}
                //else
                //{
                //    DoThiVoHuongStack(doThi);
                //}
                HienDanhSachKeStack(doThi);
                VeDoThiStack(doThi);
            }

            timming.Stop();
            txtTimming.Text = $"{timming.Time()} (ms)";
        }

        private void DoThiVoHuong(DoThi doThi)
        {
            for (int i = 0; i < soDinh; i++)
            {
                Node node = doThi.Lists[i];
                while (node != null)
                {
                    if (!doThi.Contains(node.Dinh, i))
                    {
                        if (coTrongSo)
                        {
                            doThi.ThemCanh(node.Dinh, i, node.TrongSo);
                        }
                        else
                        {
                            doThi.ThemCanh(node.Dinh, i);
                        }
                    }
                    node = node.Next;
                }
            }
        }

        private void DoThiCoHuong(DoThi doThi)
        {
            for (int i = 0; i < soDinh; i++)
            {
                Node node = doThi.Lists[i];
                while (node != null)
                {
                    if (doThi.Contains(node.Dinh, i))
                    {
                        doThi.XoaCanh(node.Dinh, i);
                    }
                    node = node.Next;
                }
            }
        }

        private void DoThiCoTrongSo(DoThi doThi)
        {
            for (int i = 0; i < soDinh; i++)
            {
                Node node = doThi.Lists[i];
                while (node != null)
                {
                    if (doThi.Contains(node.Dinh, i))
                    {
                        if (node.TrongSo != doThi.TrongSoCanh(node.Dinh, i))
                        {
                            node.TrongSo = doThi.TrongSoCanh(node.Dinh, i);
                        }
                    }
                    node = node.Next;
                }
            }
        }

        private void DoThiVoHuongStack(DoThiStack doThi)
        {
            for (int i = 0; i < soDinh; i++)
            {
                Node[] listNode = doThi.Lists[i];
                doThi.top = listNode.Count(x => x != null) - 1;
                while (!doThi.IsEmpty() && listNode != null)
                {
                    Node data = doThi.LayCanh(i);
                    Node[] listNodeKe = doThi.Lists[data.Dinh];
                    doThi.top = listNodeKe.Count(x => x != null) - 1;
                    if (!doThi.Contains(data.Dinh, i))
                    {
                        if (coTrongSo)
                        {
                            doThi.ThemCanh(data.Dinh, i, data.TrongSo);
                        }
                        else
                        {
                            doThi.ThemCanh(data.Dinh, i);
                        }
                    }
                    else
                    {
                        if (coTrongSo)
                        {
                            if (data.TrongSo != doThi.TrongSoCanh(i, data.Dinh))
                            {
                                data.TrongSo = doThi.TrongSoCanh(i, data.Dinh);
                            }
                        }
                    }
                }

            }
        }

        private void DoThiCoHuongStack(DoThiStack doThi)
        {
            for (int i = 0; i < soDinh; i++)
            {
                Node[] node = doThi.Lists[i];
                doThi.top = node.Count(x => x != null) - 1;
                while (!doThi.IsEmpty() && node != null)
                {
                    Node data = doThi.LayCanh(i);
                    if (doThi.Contains(data.Dinh, i))
                    {
                        doThi.XoaCanh(data.Dinh, i);
                    }
                }
            }
        }

        private void HienDanhSachKeStack(DoThiStack doThi)
        {
            dgvDsk.Rows.Clear();
            dgvDsk.ColumnCount = soDinh;
            dgvDsk.RowCount = soDinh;
            dgvDsk.ReadOnly = true;

            for (int i = 0; i < soDinh; i++)
            {
                dgvDsk.Rows[i].HeaderCell.Value = "Đỉnh " + i + "";
                Node[] node = doThi.Lists[i];
                doThi.top = node.Count(x => x != null) - 1;
                int j = 0;
                while (!doThi.IsEmpty() && node != null)
                {
                    Node data = doThi.LayCanh(i);
                    if (coTrongSo)
                    {
                        dgvDsk.Rows[i].Cells[j].Value = data.Dinh + "-" + data.TrongSo;
                    }
                    else
                    {
                        dgvDsk.Rows[i].Cells[j].Value = data.Dinh;
                    }
                    j++;
                }
            }
        }

        private void HienDanhSachKe(DoThi doThi)
        {
            dgvDsk.Rows.Clear();
            dgvDsk.ColumnCount = soDinh;
            dgvDsk.RowCount = soDinh;
            dgvDsk.ReadOnly = true;

            for (int i = 0; i < soDinh; i++)
            {
                dgvDsk.Rows[i].HeaderCell.Value = "Đỉnh " + i + "";
                Node node = doThi.Lists[i];
                int j = 0;
                while (node != null)
                {
                    if (coTrongSo)
                    {
                        dgvDsk.Rows[i].Cells[j].Value = node.Dinh + "-" + node.TrongSo;
                    }
                    else
                    {
                        dgvDsk.Rows[i].Cells[j].Value = node.Dinh;
                    }
                    node = node.Next;
                    j++;
                }
            }
        }

        private void btnVeDoThi_Click(object sender, EventArgs e)
        {
            DoThi doThi = new DoThi(soDinh);
            for (int i = 0; i < dgvDsk.Rows.Count; i++)
            {
                int j = 0;
                while (dgvDsk.Rows[i].Cells[j].Value != null)
                {
                    if (!string.IsNullOrEmpty(dgvDsk.Rows[i].Cells[j].Value.ToString()))
                    {
                        int dinhKe = int.Parse(dgvDsk.Rows[i].Cells[j].Value.ToString());
                        doThi.ThemCanh(i, dinhKe);
                        j++;
                    }
                }
            }
            HienDanhSachKe(doThi);
            VeDoThi(doThi);
        }

        private void btnLuuDT_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = ".txt|*.txt";

            if (soDinh != 0)
            {
                DialogResult result = saveFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                    sWriter.Write(soDinh);
                    sWriter.WriteLine();
                    if (coTrongSo)
                    {
                        for (int i = 0; i < dgvDsk.Rows.Count; i++)
                        {
                            int j = 0;
                            if (dgvDsk.Rows[i].Cells[j].Value == null)
                            {
                                sWriter.WriteLine();
                            }
                            while (dgvDsk.Rows[i].Cells[j].Value != null)
                            {
                                if (!string.IsNullOrEmpty(dgvDsk.Rows[i].Cells[j].Value.ToString()))
                                {
                                    if (dgvDsk.Rows[i].Cells[j + 1].Value == null)
                                    {
                                        sWriter.Write(dgvDsk.Rows[i].Cells[j].Value.ToString());
                                        sWriter.WriteLine();
                                    }
                                    else
                                    {
                                        sWriter.Write(dgvDsk.Rows[i].Cells[j].Value.ToString() + " ");
                                    }
                                }
                                j++;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dgvDsk.Rows.Count; i++)
                        {
                            int j = 0;
                            if (dgvDsk.Rows[i].Cells[j].Value == null)
                            {
                                sWriter.WriteLine();
                            }
                            while (dgvDsk.Rows[i].Cells[j].Value != null)
                            {
                                if (!string.IsNullOrEmpty(dgvDsk.Rows[i].Cells[j].Value.ToString()))
                                {
                                    if (dgvDsk.Rows[i].Cells[j + 1].Value == null)
                                    {
                                        sWriter.Write(dgvDsk.Rows[i].Cells[j].Value.ToString());
                                        sWriter.WriteLine();
                                    }
                                    else
                                    {
                                        sWriter.Write(dgvDsk.Rows[i].Cells[j].Value.ToString() + " ");
                                    }
                                }
                                j++;
                            }
                        }
                    }
                    sWriter.Flush();
                    fs.Close();
                    MessageBox.Show("Lưu File thành công");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đồ thị?");
            }
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            Timming timming = new Timming();
            timming.Start();
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = ".txt|*.txt";
                DialogResult tl = open.ShowDialog();
                using (FileStream fs = new FileStream(open.FileName, FileMode.Open))
                {
                    string data;
                    using (StreamReader doc = new StreamReader(fs))
                    {
                        data = doc.ReadLine();
                        soDinh = int.Parse(data);
                        DoThi doThi = new DoThi(soDinh);
                        int dinh = 0;
                        while (doc.Peek() > -1)
                        {
                            data = doc.ReadLine();
                            if (!string.IsNullOrEmpty(data))
                            {
                                if (data.Contains("-"))
                                {
                                    coTrongSo = true;
                                    chkbCoTrongSo.Checked = true;
                                    string[] dinhKe = data.Split(' ');
                                    for (int i = 0; i < dinhKe.Count(); i++)
                                    {
                                        if (!String.IsNullOrEmpty(dinhKe[i]))
                                        {
                                            string[] dinhVaTrongSo = dinhKe[i].Split('-');
                                            doThi.ThemCanh(dinh, int.Parse(dinhVaTrongSo[0]), int.Parse(dinhVaTrongSo[1]));
                                            if (doThi.Contains(int.Parse(dinhVaTrongSo[0]), dinh))
                                            {
                                                coHuong = false;
                                                chkbCoHuong.Checked = false;
                                            }
                                            else
                                            {
                                                coHuong = true;
                                                chkbCoHuong.Checked = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    coTrongSo = false;
                                    chkbCoTrongSo.Checked = false;
                                    string[] dinhKe = data.Split(' ');
                                    for (int i = 0; i < dinhKe.Count(); i++)
                                    {
                                        if (!String.IsNullOrEmpty(dinhKe[i]))
                                        {
                                            doThi.ThemCanh(dinh, int.Parse(dinhKe[i]));
                                            if (doThi.Contains(int.Parse(dinhKe[i]), dinh))
                                            {
                                                coHuong = false;
                                                chkbCoHuong.Checked = false;
                                            }
                                            else
                                            {
                                                coHuong = true;
                                                chkbCoHuong.Checked = true;
                                            }
                                        }
                                    }
                                }
                            }
                            dinh++;
                        }
                        HienDanhSachKe(doThi);
                        VeDoThi(doThi);
                    }
                }
                if (tl == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
            timming.Stop();
            txtTimming.Text = $"{timming.Time()} (ms)";
        }

        private void cbxCTDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCTDL.SelectedIndex == 0)
            {
                linkedList = true;
                stack = false;
            }
            else
            {
                linkedList = false;
                stack = true;
            }
        }

        private void pbDoThi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectNode.Location = e.Location;
                NoiDinh(doThi);
            }
        }

        private void pbDoThi_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectNode != null)
            {
                selectNode.Enabled = true;
            }
            NoiDinh(doThi);
        }
    }
}
