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
        public FormMain()
        {
            InitializeComponent();
        }

        int soDinh;
        public bool coHuong = false;
        public bool coTrongSo = false;


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
        private void NoiDinh(DoThi doThi)
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
        private void VeDoThi(DoThi doThi)
        {
            TinhToanToaDo(soDinh);
            TaoDinh();
            HienDinh();
            NoiDinh(doThi);
            //Clear();
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
            dgvDsk.Rows.Clear();
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
            DoThi doThi = new DoThi(soDinh);
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
                        while (dinhKe == i || doThi.KiemTraDinh(i, dinhKe))
                        {
                            dinhKe = random.Next(0, soDinh);
                        }
                        trongSo = random.Next(1, 10);
                        doThi.ThemCanh(i, dinhKe, trongSo);
                    }
                }
                HienDanhSachKe(doThi);
                VeDoThi(doThi);
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
                        while (dinhKe == i || doThi.KiemTraDinh(i, dinhKe))
                        {
                            dinhKe = random.Next(0, soDinh);
                        }

                        doThi.ThemCanh(i, dinhKe);
                    }
                }
                HienDanhSachKe(doThi);
                VeDoThi(doThi);

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
            timming.Stop();
            txtTimming.Text = $"{timming.Time()} (ms)";
        }

        private void DTVoHuong(DoThi doThi)
        {
            //if (coTrongSo)
            //{
            //    for (int i = 0; i < soDinh; i++)
            //    {
            //        Node node = doThi.Lists[i];
            //        while (node != null)
            //        {
            //            while (dinhKe == i || doThi.KiemTraDinh(i, dinhKe))
            //            {
            //                dinhKe = random.Next(0, soDinh);
            //            }
            //            trongSo = random.Next(1, 10);
            //            doThi.ThemCanh(i, dinhKe, trongSo);
            //        }
            //    }
            //    HienDanhSachKe(doThi);
            //    VeDoThi(doThi);
            //}
            //else
            //{
            //    int dinhKe;
            //    for (int i = 0; i < soDinh; i++)
            //    {
            //        soDinhKe = random.Next(1, soDinh - 1);
            //        for (int j = 0; j < soDinhKe; j++)
            //        {
            //            dinhKe = random.Next(0, soDinh);
            //            while (dinhKe == i || doThi.KiemTraDinh(i, dinhKe))
            //            {
            //                dinhKe = random.Next(0, soDinh);
            //            }

            //            doThi.ThemCanh(i, dinhKe);
            //        }
            //    }
            //}
        }

        private void HienDanhSachKe(DoThi doThi)
        {
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
                        dgvDsk.Rows[i].Cells[j].Value = node.Dinh + "(" + node.TrongSo + ")";
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
                            while (dgvDsk.Rows[i].Cells[j].Value != null)
                            {
                                if (!string.IsNullOrEmpty(dgvDsk.Rows[i].Cells[j].Value.ToString()))
                                {
                                    if (dgvDsk.Rows[i].Cells[j+1].Value == null)
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
            //// Tạo chuỗi input
            //string input = "4(5) 3(7) 1(3) 7(9) 6(5)";

            //// Tạo một biến để lưu trữ kết quả
            //List<int> results = new List<int>();

            //// Lặp qua từng ký tự trong chuỗi input
            //for (int i = 0; i < input.Length; i++)
            //{
            //    // Kiểm tra xem ký tự hiện tại là dấu ngoặc mở hay không
            //    if (input[i] == '(')
            //    {
            //        // Tìm kiếm dấu ngoặc đóng tiếp theo
            //        int indexClose = input.IndexOf(')', i + 1);

            //        // Nếu tìm thấy dấu ngoặc đóng
            //        if (indexClose > 0)
            //        {
            //            // Lấy giá trị của số
            //            string number = input.Substring(i + 1, indexClose - i - 1);

            //            // Thêm số vào danh sách kết quả
            //            results.Add(int.Parse(number));
            //        }
            //    }
            //}

            //// In ra kết quả
            //foreach (int result in results)
            //{
            //    Console.WriteLine(result);
            //}
            //try
            //{
            //    OpenFileDialog open = new OpenFileDialog();
            //    open.Filter = ".txt|*.txt";
            //    DialogResult tl = open.ShowDialog();
            //    FileStream fs = new FileStream(open.FileName, FileMode.Open);
            //    StreamReader doc = new StreamReader(fs);
            //    string data;
            //    soDinh = 0;
            //    while (doc.Peek() > -1)
            //    {
            //        data = doc.ReadLine();
            //        if (!string.IsNullOrEmpty(data))
            //        {
            //            if (data.Contains("("))
            //            {
            //                coTrongSo = true;
            //                chkbCoTrongSo.Checked = true;
            //                string[] dinhKe = data.Split(' ');
            //                for (int i = 0; i < dinhKe.Count(); i++)
            //                {
            //                    if (String.Compare(dinhKe.GetValue(i).ToString(), @"-1") == 0)// "-1 là đỉnh đó k có đỉnh kề"
            //                    {
            //                        lsDinhKeCoTrongSo.Add(new int[] { -1, 0 });
            //                    }
            //                    else
            //                    {
            //                        string[] dinhVaTrongSo = dinhKe.GetValue(i).ToString().Split('|');
            //                        lsDinhKeCoTrongSo.Add(new int[] { int.Parse(dinhVaTrongSo[0].ToString()), int.Parse(dinhVaTrongSo[1].ToString()) });
            //                    }
            //                }
            //                lsDinhTrongSo.Add(lsDinhKeCoTrongSo);
            //            }
            //            else
            //            {
            //                isWeightedGraph = false;
            //                string[] dinhKe = s.Split(' '); 
            //                for (int i = 0; i < dinhKe.Count(); i++)
            //                {
            //                    if (String.Compare(dinhKe.GetValue(i).ToString(), @"-1") == 0)// 
            //                    {
            //                        lsDinhKe.Add(-1);

            //                    }
            //                    else
            //                    {
            //                        int a = int.Parse(dinhKe.GetValue(i).ToString());
            //                        lsDinhKe.Add(a);
            //                    }
            //                }
            //                lsDinh.Add(lsDinhKe);
            //            }
            //        }
            //        SoDinh += 1;
            //    }
            //    doc.Dispose();
            //    fs.Dispose();
            //    if (tl == DialogResult.OK)
            //    {

            //    }
            //    LoadDoThi();
            //}
            //catch
            //{
            //    MessageBox.Show("Vui lòng kiểm tra File đầu vào");
            //}
        }
    }
}
