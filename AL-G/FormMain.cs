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
    public partial class FormMain : Form
    {
        List<Dinh> dinh = new List<Dinh>();
        Graphics g;
        Random random = new Random();
        public FormMain()
        {
            InitializeComponent();
        }
        int soDinh;
        public List<int> listDinhKe = new List<int>();
        public List<List<int>> listDinh = new List<List<int>>();
        public List<int[]> listDinhKeTrongSo = new List<int[]>();
        public List<List<int[]>> listDinhTrongSo = new List<List<int[]>>();

        public bool coHuong = false;
        public bool coTrongSo = false;

        private void btnNhapDinh_Click(object sender, EventArgs e)
        {
            soDinh = int.Parse(txtSlDinh.Text);

            if (soDinh <= 1)
            {
                MessageBox.Show("Số đỉnh phải lớn hơn 1");
                return;
            }

            else
            {
                dgvDsk.Visible = true;
            }
            dgvDsk.ColumnCount = soDinh;
            dgvDsk.RowCount = soDinh;

            for (int i = 0; i < soDinh; i++)
            {
                dgvDsk.Rows[i].HeaderCell.Value = "" + i + "";
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
        }
        private void TaoDinh()
        {
            dinh = new List<Dinh>();
            for (int i = 0; i < soDinh; i++)
            {
                Dinh d = new Dinh();
                d.Location = new Point(random.Next(5, 610), random.Next(5, 510));
                d.Location = listPoint[i];
                d.ID = (i);
                d.Ten.Text = (i).ToString();
                //n.MouseDown += new MouseEventHandler(Node_MouseDown);
                //n.MouseUp += new MouseEventHandler(Node_MouseUp);
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
        private void NoiDinh()
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
                if (coTrongSo && listDinhTrongSo.Count > 0)
                {
                    for (int j = 0; j < listDinhTrongSo[i].Count - 1; j++)
                    {
                        int k = listDinhTrongSo[i][j][0];
                        if (k < 0) continue;
                        int trongso = listDinhTrongSo[i][j][1];
                        int x = Math.Abs(dinh[i].Tam.X + dinh[k].Tam.X);
                        x = x / 2;
                        int y = Math.Abs(dinh[i].Tam.Y + dinh[k].Tam.Y);
                        y = y / 2;

                        Point trungdiem = new Point(x, y);

                        g.DrawLine(p, dinh[i].Tam, trungdiem);
                        g.DrawLine(p, trungdiem, dinh[k].Tam);

                        g.DrawString(trongso.ToString(), this.Font, Brushes.Black, x + 6, y + 6);
                    }
                }
                else if (listDinh[i].Count > 0)
                {
                    for (int j = 0; j < listDinh[i].Count -1; j++)
                    {
                        int k = listDinh[i][j];
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
        public void VeDoThi()
        {
            TinhToanToaDo(soDinh);
            TaoDinh();
            HienDinh();
            NoiDinh();
            Clear();
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

        private bool KiemTraTrungDinhTrongSo(int dinhKe, List<int[]> listDinhke)// Check nếu đỉnh đã tồn tại trong ds thì k add nó
        {
            for (int i = 0; i < listDinhke.Count -1; i++)
            {
                if (dinhKe == listDinhke[i][0])
                {
                    return true;
                }
            }
            return false;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (!string.IsNullOrEmpty(txtSlDinh.Text))
            {
                soDinh = int.Parse(txtSlDinh.Text);
            }
            else
            {
                soDinh = random.Next(2, 12);
            }
            if (soDinh <= 1)
            {
                MessageBox.Show("Số đỉnh phải lớn hơn 1");
                return;
            }
            int soDinhKe;
            if (coTrongSo)
            {
                int dinhKe;
                int trongSo;
                for (int i = 0; i < soDinh; i++)
                {
                    soDinhKe = soDinh / random.Next(1, 5);
                    for (int j = 0; j < soDinhKe; j++)
                    {
                        dinhKe = random.Next(1, soDinh);
                        trongSo = random.Next(1, 10);
                        if (dinhKe == i)
                            continue;
                        else if (!KiemTraTrungDinhTrongSo(dinhKe, listDinhKeTrongSo))
                        {
                            listDinhKeTrongSo.Add(new int[] { dinhKe, trongSo });
                        }
                    }
                    listDinhTrongSo.Add(listDinhKeTrongSo);
                }
                HienDanhSachKe();
                VeDoThi();
            }
            else
            {
                int dinhKe;
                for (int i = 0; i < soDinh; i++)
                {
                    soDinhKe = soDinh / random.Next(1, 5);
                    for (int j = 0; j < soDinhKe; j++)
                    {
                        dinhKe = random.Next(1, soDinh);
                        if (!listDinhKe.Contains(dinhKe))
                        {
                            listDinhKe.Add(dinhKe);
                        }
                    }
                    listDinh.Add(listDinhKe);
                }
                HienDanhSachKe();
                VeDoThi();
            }
            //if (dske.isDiGraph)
            //{
            //    RandomGraph = true;
            //    ValidateDirectGraph();
            //}
            //else
            //{
            //    ValidateUndirectedGraph();
            //}
        }

        private void HienDanhSachKe()
        {
            dgvDsk.Visible = true;
            dgvDsk.ColumnCount = listDinh.Count;
            dgvDsk.RowCount = listDinh.Count;
            dgvDsk.ReadOnly = true;
            for (int i = 0; i < listDinh.Count - 1; i++)
            {
                dgvDsk.Rows[i].HeaderCell.Value = "Đỉnh " + i + "";

                for (int j = 0; j < listDinh[i].Count - 1; j++)
                {
                    dgvDsk.Rows[i].Cells[j].Value = listDinh[i][j].ToString();
                }
            }
        }

        private void Clear()
        {

            soDinh = 0;
            listDinh.Clear();
            listDinhKe.Clear();
            listDinhKeTrongSo.Clear();
            listDinhTrongSo.Clear();
        }
    }
}
