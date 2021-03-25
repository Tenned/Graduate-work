using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Телефоны
{
    public partial class Frm : Form
    {
        struct Phone
        {
            public string Name;
        };
        struct Comp
        {
            public bool was;
            public int[,] aMatrix;
        };
        Label[] aLb = null;
        Label lbSelected = null;
        int xSelected, ySelected;
        int[,] aTb;
        List<Phone> lPh = new List<Phone>();
        double[] aCr = new double[8];
        Panel[] arrPn = new Panel[6];
        Label[] arrLb = new Label[4];
        int idxPn, idxCmp = -1;
        bool ProfNorm = false;
        Comp[] aComp;
        bool needClose = false;
        public Frm()
        {
            InitializeComponent();
        }
        ~Frm()
        {
            if (aLb != null)
                for (int i = 0; i < aLb.Length; i++) aLb[i].Dispose();
        }

        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (MessageBox.Show("Закрыть программу?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    needClose = true;
                    Close();
                }
            if (idxPn == 0 && e.KeyCode == Keys.Insert)
                btAdd_Click(btAdd, new EventArgs());
        }

        private void lbPhone_MouseDown(object sender, MouseEventArgs e)
        {
            Label lb = (sender as Label);
            lbSelected = lb;
            xSelected = e.X;
            ySelected = e.Y;
            lb.BringToFront();
        }

        void SetPos(Label lb, int x, int l, int y, int t)
        {
            lb.Left = l;
            lb.Top = t;
            lb.Tag = y * 100 + x;
        }

        private void lbPhone_MouseUp(object sender, MouseEventArgs e)
        {
            Label lb = lbSelected;
            int px = (int)lb.Tag % 100;
            int py = (int)lb.Tag / 100;
            int d = 3;
            int l=lb.Left - d;
            int w = lb.Width + d;
            int x = l / w +l % w / (w / 2);
            l = lb.Top - d;
            int h = lb.Height + d;
            int y = l / h +l % h / (h / 2);
            int idx = aTb[py, px];
            //если не на пустое место, y - x - новые координаты
            if (aTb[y, x] != -1 && aTb[y, x] != aTb[py, px])
            {
                aTb[py, px] = -1;
                int i;
                for (i = y + 1; i < aLb.Length; i++)
                    if (aTb[i, x] == -1 || aTb[i, x] == aTb[py, px]) break;
                if (i < aLb.Length)
                {
                    for (; i > y; i--)
                    {
                        aTb[i, x] = aTb[i - 1, x];
                        SetPos(aLb[aTb[i, x]], x, d + x * w, i, d + i * h);
                    }
                }
                else
                {
                    for (i = y; i > 0; i--)
                        if (aTb[i, x] == -1) break;
                    for (; i < y; i++)
                    {
                        aTb[i, x] = aTb[i + 1, x];
                        SetPos(aLb[aTb[i, x]], x, d + x * w, i, d + i * h);
                    }
                }
            }
            else aTb[py, px] = -1;
            aTb[y, x] = idx;
            SetPos(lb, x, d + x * w, y, d + y * h);
            lbSelected = null;
            //сжатие в верх
            if (py< aLb.Length - 1 && aTb[py, px] == -1 && aTb[py + 1, px] != -1)
                for (int i = py; i < aLb.Length - 1; i++)
                    if (aTb[i + 1, px] != -1)
                    {
                        aTb[i, px] = aTb[i + 1, px];
                        aTb[i + 1, px] = -1;
                        SetPos(aLb[aTb[i, px]], px, d + px * w, i, d + i * h);
                    }
                    else break;
        }

        private void lbPhone_MouseMove(object sender, MouseEventArgs e)
        {
            Label lb = (sender as Label);
            int x = (int)lb.Tag % 100;
            int y = (int)lb.Tag / 100;
            tTip.Show("" + (1 + aTb[y, x]), lb, e.X + 10, e.Y + 20);
            if (lbSelected != null)
            {
                int d = 3;
                x = lb.Left + e.X - xSelected;
                y = lb.Top + e.Y - ySelected;
                if (x < d) x = d;
                if (y < d) y = d;
                int r = x + lb.Width - 1;
                int b = y + lb.Height - 1;
                if (r >= pnPhone.ClientSize.Width - d) x = pnPhone.ClientSize.Width - d - lb.Width;
                if (b >= pnPhone.ClientSize.Height - d) y = pnPhone.ClientSize.Height - d - lb.Height;
                lb.Left = x;
                lb.Top = y;
            }
        }

        private void lbPhone_MouseEnter(object sender, EventArgs e)
        {
        }
        private void lbPhone_MouseLeave(object sender, EventArgs e)
        {
            tTip.Hide(sender as Label);
        }
        //
        private void Start()
        {
            int nPh = dgPh.Rows[0].Cells[0].Value != null ? dgPh.Rows.Count : 0;
            aComp = new Comp[aCr.Length];
            for (int i = 0; i < aComp.Length; i++) 
            {
                aComp[i].was = false;
                aComp[i].aMatrix = new int[nPh, nPh];
            }
        }
        //
        private void Frm_Shown(object sender, EventArgs e)
        {
            dgPh.RowCount = 1;
            dgPh.ColumnCount = 1;
            dgPh.Columns[0].Width = dgPh.ClientSize.Width;
            dgPh.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPh.Columns[0].HeaderText= "Телефон";
            dgPh.Rows[0].Cells[0].ReadOnly = true;
            //
            string[] sCr = 
            { "Стоимость", "Диагональ", "Камeра", "Корпус", "Процессор", "Аккумулятор", "Память", "Увел. памяти" };
            dgCr.RowCount = aCr.Length;
            dgPh.ColumnCount = 2;
            for (int i = 0; i < aCr.Length; i++)
            {
                aCr[i] = 0;
                dgCr.Rows[i].HeaderCell.Value = sCr[i];
                dgCr.Rows[i].Cells[0].Value = aCr[i].ToString();
            }
            //
            arrPn[0] = Pn0;
            arrPn[1] = Pn1;
            arrPn[2] = Pn2;
            arrPn[3] = Pn3;
            arrPn[4] = Pn4;
            arrPn[5] = Pn5;
            arrLb[0] = lbStep0;
            arrLb[1] = lbStep1;
            arrLb[2] = lbStep2;
            arrLb[3] = lbStep3;
            idxPn = 1;
            btNextBack_Click(btBack, new EventArgs());
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (dgPh.RowCount == 1 && dgPh.Rows[0].Cells[0].Value == null && lPh.Count==0)
            {
                dgPh.Rows[0].Cells[0].ReadOnly = false;
                dgPh.CurrentCell = dgPh.Rows[0].Cells[0];
            }
            else
            {
                dgPh.Rows[dgPh.RowCount - 1].Cells[0].ReadOnly = true;
                dgPh.RowCount++;
                dgPh.Rows[dgPh.RowCount - 1].Cells[0].ReadOnly = false;
                dgPh.CurrentCell = dgPh.Rows[dgPh.RowCount - 1].Cells[0];
            }
            dgPh.BeginEdit(false);
            lPh.Add(new Phone());
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int rw = dgPh.CurrentCell.RowIndex;
            if (dgPh.RowCount > 1)
                dgPh.Rows.RemoveAt(rw);
            else
            if(dgPh.Rows[0].Cells[0].Value != null)
            {
                dgPh.Rows[0].Cells[0].Value = null;
                dgPh.Rows[0].Cells[0].ReadOnly = true;
            }
            if(lPh.Count>0) lPh.RemoveAt(rw);
        }

        private void dgPh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPh.Rows[e.RowIndex].Cells[0].Value != null)
            {
                Phone ph;
                ph.Name = dgPh.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                dgPh.Rows[e.RowIndex].Cells[0].ReadOnly = true;
            }
            else
            {
                if (e.RowIndex <= lPh.Count && lPh.Count > 0)
                    lPh.RemoveAt(e.RowIndex);
                if (dgPh.RowCount > 1)
                    dgPh.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgCr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double old = aCr[e.RowIndex];
            string s = dgCr.Rows[e.RowIndex].Cells[0].Value.ToString().Replace('.', ',');
            if (!double.TryParse(s, out aCr[e.RowIndex]))
            {
                MessageBox.Show(dgCr.Rows[e.RowIndex].HeaderCell.Value + " неверное значение!");
                aCr[e.RowIndex] = old;
                dgCr.Rows[e.RowIndex].Cells[0].Value = aCr[e.RowIndex].ToString();
            }
            lbSum.Text = "Сумма: " + GetSum();
        }
        //
        double GetSum()
        {
            double sm = 0;
            int nCr = aCr.Length;
            for (int i = 0; i < nCr; i++)
                sm += aCr[i];
            return sm;
        }
        //
        private void FillCr()
        {
            int nCr = aCr.Length;
            for (int i = nCr - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if ((int)aLb[j].Tag / 100 > (int)aLb[i].Tag / 100)
                    {
                        Label l = aLb[j];
                        aLb[j] = aLb[i];
                        aLb[i] = l;
                    }
            double cf = 0.027, dcf = 0.027;
            int max = (int)aLb[nCr - 1].Tag / 100;
            for (int i = nCr - 1; i >= 0; i--)
            {
                int y = (int)aLb[i].Tag / 100;
                if (y < max)
                {
                    max = y;
                    cf += dcf;
                }
                aCr[i] = cf;
            }
            double sm = GetSum();
            double db = 1 - sm;
            for (int i = 0; i < nCr; i++)
                aCr[i] = Math.Round(aCr[i] + db * aCr[i] / sm, 3);
        }
        //
        private void btNextBack_Click(object sender, EventArgs e)
        {
            Button bt = (sender as Button);
            int Old = idxPn;
            if (idxPn == 1 && bt == btNext && !ProfNorm) FillCr();
            if (idxPn == 3 && bt == btNext && !ProfNorm) FillMatrix();
            if (bt == btBack)
            {
                if (idxPn > 0 && idxPn < 3)
                {
                    idxPn--;
                    if (idxPn == 1 && !ProfNorm) idxPn = 0;
                }
                else
                    if (idxPn == 5)
                    {
                        idxPn = 3;
                        idxCmp = 8;
                    }
                    else
                        if (!ProfNorm)
                        {
                            if (idxCmp == 0) idxPn = 1;
                        }
                        else idxPn = 3;
                //
                if (idxPn > 2 && idxPn < 5)
                {
                    if (!ProfNorm)
                    {
                        idxCmp--;
                        idxPn = 3;
                    }
                }
                else idxCmp = -1;
            }
            else
            {
                if (idxPn < 3)
                {
                    idxPn++;
                    if (idxPn == 2 && !ProfNorm) idxPn = 3;
                }
                else
                    if (!ProfNorm)
                    {
                        if (idxCmp == 7) idxPn = 5;
                    }
                    else idxPn = 4;
                //
                if (idxPn > 2 && idxPn < 5)
                {
                    if (!ProfNorm)
                    {
                        idxCmp++;
                        idxPn = 3;
                    }
                }
                else idxCmp = -1;
            }
            if (idxPn == 3 && Old == 2 && GetSum() != 1)
            {
                idxCmp = -1;
                idxPn = 2;
                MessageBox.Show("Неверная сумма коэффициентов!");
                return;
            }
            btBack.Visible = idxPn > 0;
            btNext.Visible = idxPn < arrPn.Length - 1;
            for (int i = 0; i < arrPn.Length; i++)
                arrPn[i].Visible = i == idxPn;
            for (int i = 0; i < arrLb.Length; i++)
                if (idxPn == 0 && i == 0) arrLb[i].BackColor = Color.Gainsboro;
                else
                    if ((idxPn == 1 || idxPn == 2) && i == 1) arrLb[i].BackColor = Color.Gainsboro;
                    else
                        if ((idxPn == 3 || idxPn == 4) && i == 2) arrLb[i].BackColor = Color.Gainsboro;
                        else
                            if (idxPn == 5 && i == 3) arrLb[i].BackColor = Color.Gainsboro;
                            else arrLb[i].BackColor = Color.White;
            lbCmp.Visible = idxPn > 2 && idxPn < 5;
            lbStep2.Text = "Сравнение альтернатив";
            if(lbCmp.Visible)
            {
                lbCmp.Text = dgCr.Rows[idxCmp].HeaderCell.Value.ToString();
                lbStep2.Text += "(" + (idxCmp + 1) + "/8)";
            }
            if (idxPn > 0 && idxPn < 5)
            {
                btProf.Visible = idxPn % 2 == 1;
                btNorm.Visible = !btProf.Visible;
            }
            if (idxPn == 1 && Old == 0) Start();
            if (idxPn == 2)
            {
                int nCr = aCr.Length;
                for (int i = 0; i < nCr; i++)
                    dgCr.Rows[i].Cells[0].Value = aCr[i].ToString();
                lbSum.Text = "Сумма: " + GetSum();
            }
            int nPh = dgPh.Rows[0].Cells[0].Value != null ? dgPh.Rows.Count : 0;
            btExit.Visible = idxPn == arrPn.Length - 1;
            if (idxPn == 1 || idxPn == 3)
            {
                int nRows = idxPn == 3 ? nPh : dgCr.Rows.Count;
                if (aLb != null)
                    for (int i = 0; i < aLb.Length; i++) aLb[i].Dispose();
                if (nRows > 0)
                {
                    System.Drawing.Font Fnt = new System.Drawing.Font("Courier New", 9.75F,
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    int d = 3;
                    aLb = new Label[nRows];
                    Panel Pn = idxPn == 3 ? pnPhone : pnCr;
                    int hLb = 25;
                    Pn.Height = nRows * (d + hLb) + d + 2;
                    int wLb = (Pn.ClientSize.Width - d * (nRows + 1)) / nRows;
                    for (int i = 0; i < nRows; i++)
                    {
                        Label lb = new Label();
                        lb.Tag = i * 100;
                        lb.BackColor = System.Drawing.Color.Gainsboro;
                        lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        lb.Font = Fnt;
                        lb.Location = new System.Drawing.Point(d, d + i * (d + hLb));
                        lb.Name = "_" + i;
                        lb.Size = new System.Drawing.Size(wLb, hLb);
                        lb.Text = (idxPn == 3 ? dgPh.Rows[i].Cells[0].Value : dgCr.Rows[i].HeaderCell.Value).ToString();
                        lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        lb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbPhone_MouseMove);
                        lb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPhone_MouseDown);
                        lb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbPhone_MouseUp);
                        //lb.MouseEnter += new System.EventHandler(this.lbPhone_MouseEnter);
                        lb.MouseLeave += new System.EventHandler(this.lbPhone_MouseLeave);
                        Pn.Controls.Add(lb);
                        aLb[i] = lb;
                    }
                    Fnt.Dispose();
                    aTb = new int[nRows, nRows];
                    for (int i = 0; i < nRows; i++)
                        for (int j = 0; j < nRows; j++) aTb[i, j] = j == 0 ? i : -1;
                }
            }
            else
                if (idxPn == 4 && nPh > 0) SetMatrix(nPh);
        }

        private void btProfNorm_Click(object sender, EventArgs e)
        {
            ProfNorm = true;
            if (idxPn % 2 == 1) btNextBack_Click(btNext, new EventArgs());
            else btNextBack_Click(btBack, new EventArgs());
            ProfNorm = false;
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            Report(true);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Закрыть программу?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                needClose = true;
                Close();
            }
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (needClose || MessageBox.Show("Закрыть программу?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //needClose = true;
                //Close();
            }
        }

        private void btShort_Click(object sender, EventArgs e)
        {
            Report(false);
        }
    }
}
