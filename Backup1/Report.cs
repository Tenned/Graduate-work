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
    struct Phn 
    { 
        public int n, nn;
        public int[] Cr;
        public double dCr;
        public int[] pos;
        public Int64 ps;
        public int[] p;
    };
    public partial class Frm : Form
    {
        Excel.Application XLS; //открыть эксель
        Excel.Workbook WB;
        Excel.Worksheet Sh;
        Excel.Range Rng;
        Excel.XlBordersIndex[] aBr = { 
                                        Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop,  
                                        Excel.XlBordersIndex.xlEdgeBottom, Excel.XlBordersIndex.xlEdgeRight };
        Excel.XlHAlign[] aHAl = { Excel.XlHAlign.xlHAlignLeft, Excel.XlHAlign.xlHAlignCenter, Excel.XlHAlign.xlHAlignRight };
        Phn[] aPh;
        bool Show;
        //
        private void Method2(int nCr, int nPh, ref int r)
        {
            r++;
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Механизм доминирования:");
            if (Show) Rng.Font.Bold = true;
            else tbReport.Text += "Механизм доминирования:\n";
            r++;
            string[] Cr = new string[nCr];
            Phn[] Ph = new Phn[nPh];
            for (int i = 0; i < nPh; i++)
            {
                Ph[i].n = i;
                Ph[i].nn = 0;
            }
            for (int i = 0; i < nCr; i++)
            {
                Cr[i] = "";
                for (int j = 0; j < nPh; j++)
                {
                    int n = 0;
                    for (int k = 0; k < nPh; k++)
                        if (aComp[i].aMatrix[k, j] == 0) n++;
                    if (n == nPh - 1) 
                    {
                        Cr[i] += (Cr[i] == "" ? "" : ", ") + (j + 1);
                        Ph[j].nn++;
                    }
                }
            }
            for (int i = 0; i < nCr; i++)
                if (Cr[i] != "")
                {
                    SetRange("A" + r, "H" + r, Excel.XlHAlign.xlHAlignCenter, dgCr.Rows[i].HeaderCell.Value.ToString());
                    Border();
                    SetRange("I" + r, "P" + r, Excel.XlHAlign.xlHAlignCenter, Cr[i]);
                    Border();
                    r++;
                }
            for (int i = nPh - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (Ph[j].nn < Ph[i].nn)
                    {
                        Phn p = Ph[j];
                        Ph[j] = Ph[i];
                        Ph[i] = p;
                    }
            if (nPh > 0) 
            {
                int nn = 0;
                int ps = 1;
                string s = "";
                for (int i = 0; i < nPh; i++)
                {
                    if (nn != Ph[i].nn)
                    {
                        if (nn > 0)
                        {
                            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps + "-е место " + s);
                            if (!Show) tbReport.Text += "" + ps + "-е место " + s + "\n";
                            ps++;
                            r++;
                        }
                        //if (Ph[i].nn == 0) break;
                        aPh[Ph[i].n].pos[1] = ps;
                        nn = Ph[i].nn;
                        s = dgPh.Rows[Ph[i].n].Cells[0].Value.ToString();
                    }
                    else
                    {
                        aPh[Ph[i].n].pos[1] = ps;
                        s += ", " + dgPh.Rows[Ph[i].n].Cells[0].Value.ToString();
                    }
                    if (i == nPh - 1)
                    {
                        SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps + "-е место " + s);
                        if (!Show) tbReport.Text += "" + ps + "-е место " + s + "\n\n";
                        r++;
                    }
                }
            }
        }
        //
        private void Method1(int nCr, int nPh, ref int r)
        {
            r++;
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Механизм блокировки:");
            if (Show) Rng.Font.Bold = true;
            else tbReport.Text += "Механизм блокировки:\n";
            r++;
            string[] Cr = new string[nCr];
            Phn[] Ph = new Phn[nPh];
            for (int i = 0; i < nPh; i++)
            {
                Ph[i].n = i;
                Ph[i].nn = 0;
            }
            for (int i = 0; i < nCr; i++)
            {
                Cr[i] = "";
                for (int j = 0; j < nPh; j++)
                {
                    int n = 0;
                    for (int k = 0; k < nPh; k++)
                        if (aComp[i].aMatrix[j, k] == 1) n++;
                    if (n == nPh)
                    {
                        Cr[i] += (Cr[i] == "" ? "" : ", ") + (j + 1);
                        Ph[j].nn++;
                    }
                }
            }
            for (int i = 0; i < nCr; i++)
                if (Cr[i] != "") 
                {
                    SetRange("A" + r, "H" + r, Excel.XlHAlign.xlHAlignCenter, dgCr.Rows[i].HeaderCell.Value.ToString());
                    Border();
                    SetRange("I" + r, "P" + r, Excel.XlHAlign.xlHAlignCenter, Cr[i]);
                    Border();
                    r++;
                }
            for (int i = nPh - 1; i > 0; i--)
                for (int j = 0; j < i; j++) 
                    if (Ph[j].nn < Ph[i].nn)
                    {
                        Phn p = Ph[j];
                        Ph[j] = Ph[i];
                        Ph[i] = p;
                    }
            if (nPh > 0) 
            {
                int nn = 0;
                int ps = 1;
                string s = "";
                for (int i = 0; i < nPh; i++)
                {
                    if (nn != Ph[i].nn)
                    {
                        if (nn > 0)
                        {
                            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps + "-е место " + s);
                            if (!Show) tbReport.Text += "" + ps + "-е место " + s + "\n";
                            ps++;
                            r++;
                        }
                        //if (Ph[i].nn == 0) break;
                        aPh[Ph[i].n].pos[0] = ps;
                        nn = Ph[i].nn;
                        s = dgPh.Rows[Ph[i].n].Cells[0].Value.ToString();
                    }
                    else
                    {
                        aPh[Ph[i].n].pos[0] = ps;
                        s += ", " + dgPh.Rows[Ph[i].n].Cells[0].Value.ToString();
                    }
                    if (i == nPh - 1)
                    {
                        SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps + "-е место " + s);
                        if (!Show) tbReport.Text += "" + ps + "-е место " + s + "\n\n";
                        r++;
                    }
                }
            }
        }
        //
        private void Method3(int nCr, int nPh, ref int r)
        {
            r++;
            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "Турнирный механизм:");
            if (Show) Rng.Font.Bold = true;
            else tbReport.Text += "Турнирный механизм:\n";
            r++;
            Phn[] Ph = new Phn[nPh];
            for (int i = 0; i < nPh; i++)
            {
                Ph[i].n = i;
                Ph[i].Cr = new int[nCr];
                for (int j = 0; j < nCr; j++) Ph[i].Cr[j] = 0;
                Ph[i].dCr = 0;
            }
            for (int i = 0; i < nCr; i++)
                for (int j = 0; j < nPh; j++)
                    for (int k = 0; k < nPh; k++)
                        if (aComp[i].aMatrix[j, k] == 1) Ph[j].Cr[i]++;
            //
            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "Сумма элементов по каждому предпочтению для каждой альтернативы:");
            r++;
            int w = 3;
            string lf, rg;
            for (int i = -1; i < nPh; i++, r++) 
            {
                SetRange("A" + r, "H" + r, aHAl[0], i < 0 ? "" : ("" + dgPh.Rows[i].Cells[0].Value));
                Border();
                for (int j = 0; j < nCr; j++)
                {
                    int n = 'I' + j * w;
                    lf = "" + (n <= 'Z' ? "" + (char)n : "A" + (char)(n - 26)) + r;
                    n = 'I' + j * w + w - 1;
                    rg = "" + (n <= 'Z' ? "" + (char)n : "A" + (char)(n - 26)) + r;
                    SetRange(lf, rg, aHAl[1], i < 0 ? "K" + (j + 1) : ("" + Ph[i].Cr[j]));
                    Border();
                    if (i < 0 && Show) Rng.Font.Bold = true;
                }
            }
            r++;
            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "Сумма элементов учитывая весовой коэффициент:");
            r++;
            for (int i = -2; i < nPh; i++, r++)
            {
                string txt = i == -2 ? "Коэффициенты" : i == -1 ? "" : "" + dgPh.Rows[i].Cells[0].Value;
                SetRange("A" + r, "H" + r, aHAl[0], txt);
                Border();
                if (i < 0 && Show) Rng.Font.Bold = true;
                for (int j = 0; j < nCr; j++)
                {
                    int n = 'I' + j * w;
                    lf = "" + (n <= 'Z' ? "" + (char)n : "A" + (char)(n - 26)) + r;
                    n = 'I' + j * w + w - 1;
                    rg = "" + (n <= 'Z' ? "" + (char)n : "A" + (char)(n - 26)) + r;
                    txt = i == -2 ? "" + aCr[j] : i == -1 ? "K" + (j + 1) + "*Σ" : "" + Ph[i].Cr[j] * aCr[j];
                    SetRange(lf, rg, aHAl[1], txt);
                    Border();
                    if (i < 0 && Show) Rng.Font.Bold = true;
                }
            }
            r++;
            //
            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "Итоговый результат турнирного механизма:");
            r++;
            for (int i = 0; i < nPh; i++)
            {
                for (int j = 0; j < nCr; j++) Ph[i].dCr += Ph[i].Cr[j] * aCr[j];
                Ph[i].dCr = Math.Round(Ph[i].dCr, 4);
            }
            for (int i = 0; i < nPh; i++, r++)
            {
                SetRange("A" + r, "H" + r, aHAl[0], "" + dgPh.Rows[i].Cells[0].Value);
                Border();
                SetRange("I" + r, "M" + r, aHAl[2], "" + Ph[i].dCr);
                Border();
            }
            for (int i = nPh - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (Ph[j].dCr < Ph[i].dCr)
                    {
                        Phn p = Ph[j];
                        Ph[j] = Ph[i];
                        Ph[i] = p;
                    }
            r++;
            int ps = 1;
            for (int i = 0; i < nPh; i++, r++)
            {
                if (i > 0 && Ph[i].dCr != Ph[i - 1].dCr) ps++;
                aPh[Ph[i].n].pos[2] = ps;
                string txt = "" + ps + "-е место " + dgPh.Rows[Ph[i].n].Cells[0].Value + " со значением";
                SetRange("A" + r, "M" + r, aHAl[0], txt);
                if (!Show) tbReport.Text += "" + ps + "-е место " + dgPh.Rows[Ph[i].n].Cells[0].Value + " со значением ";
                SetRange("N" + r, "R" + r, aHAl[0], "" + Ph[i].dCr);
                if (!Show) tbReport.Text += "" + +Ph[i].dCr + "\n";
            }
            if (!Show) tbReport.Text += "\n";
        }
        //
        private void Method4(int nCr, int nPh, ref int r)
        {
            r++;
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Метод k-максимальных коэффициентов:");
            if (Show) Rng.Font.Bold = true;
            else tbReport.Text += "Метод k-максимальных коэффициентов:\n"; 
            r++;
            int hr, er, nr;
            int[,] max = new int[nPh, 4];
            Phn[] Ph = new Phn[nPh];
            Phn[] aPs = new Phn[nPh];
            for (int i = 0; i < nPh; i++)
            {
                Ph[i].pos = new int[nPh];
                aPs[i].n = i;
                aPs[i].pos = new int[nPh];
                for (int j = 0; j < nPh; j++)
                    aPs[i].pos[j] = Ph[i].pos[j] = 0;
            }
            for (int i = 0; i < nCr; i++, r++)
            {
                for (int j = 0; j < nPh; j++)
                {
                    Ph[j].n = j;
                    Ph[j].nn = 0;
                    hr = er = nr = 0;
                    for (int k = 0; k < nPh; k++)
                        if (j != k)
                        {
                            if (aComp[i].aMatrix[j, k] == 1 && aComp[i].aMatrix[k, j] == 0) hr++;
                            if (aComp[i].aMatrix[j, k] == 1 && aComp[i].aMatrix[k, j] == 1) er++;
                            if (aComp[i].aMatrix[j, k] == 0 && aComp[i].aMatrix[k, j] == 1) nr++;
                        }
                    max[j, 0] = hr + er + nr;
                    max[j, 1] = hr + nr;
                    max[j, 2] = hr + er;
                    max[j, 3] = hr;
                    for (int k = 0; k < 4; k++) Ph[j].nn += max[j, k];

                }
                SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, dgCr.Rows[i].HeaderCell.Value.ToString());
                r++;
                for (int j = -1; j < nPh; j++, r++)
                {
                    SetRange("A" + r, "H" + r, aHAl[0], j < 0 ? "" : "" + dgPh.Rows[j].Cells[0].Value);
                    Border();
                    for (int k = 0; k < 4; k++)
                    {
                        string txt = j < 0 ? (k + 1).ToString() + "-max" : max[j, k].ToString();
                        SetRange("" + (char)('I' + k * 3) + r, "" + (char)('K' + k * 3) + r, aHAl[1], txt);
                        Border();
                    }
                }
                for (int j = nPh - 1; j > 0; j--)
                    for (int k = 0; k < j; k++)
                    if (Ph[k].nn < Ph[j].nn) 
                    {
                        Phn p = Ph[k];
                        Ph[k] = Ph[j];
                        Ph[j] = p;
                    }
                int nn = -1;
                int ps = 1;
                string s = "";
                for (int j = 0; j < nPh; j++)
                {
                    if (nn != Ph[j].nn)
                    {
                        if (nn > -1)
                        {
                            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps++ + "-е место " + s);
                            r++;
                        }
                        //Ph[j].pos[ps - 1]++;
                        aPs[Ph[j].n].pos[ps - 1]++;
                        nn = Ph[j].nn;
                        s = dgPh.Rows[Ph[j].n].Cells[0].Value.ToString();
                    }
                    else
                    {
                        //Ph[j].pos[ps - 1]++;
                        aPs[Ph[j].n].pos[ps - 1]++;
                        s += ", " + dgPh.Rows[Ph[j].n].Cells[0].Value.ToString();
                    }
                    if (j == nPh - 1)
                    {
                        SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps++ + "-е место " + s);
                        r++;
                    }
                }
            }
            if (nPh > 0)
            {
                //r++;
                //for (int i = 0; i < nPh; i++, r++)
                //{
                //    SetRange("A" + r, "H" + r, aHAl[0], "" + dgPh.Rows[i].Cells[0].Value);
                //    Border();
                //    for (int j = 0; j < nPh; j++)
                //    {
                //        SetRange("" + (char)('I' + j * 3) + r, "" + (char)('K' + j * 3) + r, aHAl[1], "" + aPs[i].pos[j]);
                //        Border();
                //    }
                //}
                SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "результат метода k-максимальных коэффициентов:");
                if(!Show) tbReport.Text += "результат метода k-максимальных коэффициентов:\n";
                r++;
                Int64 cf;
                for (int i = 0; i < nPh; i++)
                {
                    aPs[i].ps = 0;
                    cf = 1;
                    for (int j = nPh - 1; j >= 0; j--, cf *= 10)
                        aPs[i].ps += aPs[i].pos[j] * cf;
                    //MessageBox.Show("" + aPs[i].ps);
                }
                for (int i = nPh - 1; i > 0; i--)
                    for (int k = 0; k < i; k++)
                        if (aPs[k].ps < aPs[i].ps)
                        {
                            Phn p = aPs[k];
                            aPs[k] = aPs[i];
                            aPs[i] = p;
                        }
                cf = -1;
                int ps = 1;
                string s = "";
                for (int j = 0; j < nPh; j++)
                {
                    if (cf != aPs[j].ps)
                    {
                        if (cf > -1)
                        {
                            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps + "-е место " + s);
                            if (!Show) tbReport.Text += "" + ps + "-е место " + s + "\n";
                            ps++;
                            r++;
                        }
                        aPh[aPs[j].n].pos[3] = ps;
                        cf = aPs[j].ps;
                        s = dgPh.Rows[aPs[j].n].Cells[0].Value.ToString();
                    }
                    else
                    {
                        aPh[aPs[j].n].pos[3] = ps;
                        s += ", " + dgPh.Rows[aPs[j].n].Cells[0].Value.ToString();
                    }
                    if (j == nPh - 1)
                    {
                        SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "" + ps + "-е место " + s);
                        if (!Show) tbReport.Text += "" + ps + "-е место " + s + "\n";
                        r++;
                    }
                }
            }
        }
        //
        private void Report(bool showXLS)
        {
            Show = showXLS;
            if (Show)
            {
                XLS = new Excel.Application(); //открыть эксель
                XLS.Visible = false;
                //XLS.DisplayAlerts = false;
                WB = XLS.Workbooks.Add(System.Reflection.Missing.Value);//создаем новую книгу
                Sh = (Excel.Worksheet)WB.Sheets[1];//выбираем 1 лист
            }

            int nPh = dgPh.Rows[0].Cells[0].Value != null ? dgPh.Rows.Count : 0;
            aPh = new Phn[nPh];
            for (int i = 0; i < nPh; i++)
            {
                aPh[i].n = i;
                aPh[i].pos = new int[4];
                aPh[i].p = new int[nPh];
                for (int j = 0; j < nPh; j++) aPh[i].p[j] = 0;
            }
            if(Show)
            for (int i = 1; i <= 52; i++)
            {
                Rng = (Excel.Range)Sh.Columns[i, Type.Missing];
                Rng.ColumnWidth = 2.5;
                Rng.Font.Name = "Courier New";
            }
            int r = 1;
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Сравниваемые альтернативы:");
            r++;
            for (int i = 0; i < nPh; i++, r++)
                SetRange("A" + r, "W" + r, aHAl[0], "" + (i + 1) + "." + dgPh.Rows[i].Cells[0].Value);
            r++;
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Весовые коэффициенты критериев:");
            r++;
            int nCr = aCr.Length;
            for (int i = 0; i < nCr; i++, r++)
                SetRange("A" + r, "W" + r, aHAl[0], "" + dgCr.Rows[i].HeaderCell.Value + " - " + aCr[i]);
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Сумма:" + GetSum());
            r += 2;
            SetRange("A" + r, "W" + r, Excel.XlHAlign.xlHAlignLeft, "Матрицы отношений:");
            int w = nPh < 8 ? 8 : nPh;
            r++;
            for (int i = 0; i < nCr; i += 2) 
            {
                string sr = ((char)('A' + w - 1)).ToString() + r;
                SetRange("A" + r, sr, Excel.XlHAlign.xlHAlignLeft, dgCr.Rows[i].HeaderCell.Value.ToString());
                if (i + 1 < nCr)
                {
                    sr = ((char)('A' + 2 * w)).ToString() + r;
                    SetRange(((char)('A' + w + 1)).ToString() + r, sr, aHAl[0], dgCr.Rows[i + 1].HeaderCell.Value.ToString());
                }
                r++;
                for (int j = 0; j < nPh; j++, r++)
                    for (int k = 0; k < nPh; k++)
                    {
                        sr = ((char)('A' + k)).ToString() + r;
                        SetRange(sr, sr, Excel.XlHAlign.xlHAlignCenter, aComp[i].aMatrix[j, k].ToString());
                        Border();
                        if (i + 1 < nCr)
                        {
                            sr = ((char)('A' + w + 1 + k)).ToString() + r;
                            SetRange(sr, sr, Excel.XlHAlign.xlHAlignCenter, aComp[i + 1].aMatrix[j, k].ToString());
                            Border();
                        }
                    }
            }
            if(!Show) tbReport.Text = "";
            Method1(nCr, nPh, ref r);
            Method2(nCr, nPh, ref r);
            Method3(nCr, nPh, ref r);
            Method4(nCr, nPh, ref r);
            r++;
            SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "В результате работы СППР мы смогли выделить наилучший вариант для покупки:");
            if (Show) Rng.Font.Bold = true;
            else tbReport.Text += "\nВ результате работы СППР мы смогли выделить наилучший вариант для покупки:\n";
            r++;
            for (int i = 0; i < nPh; i++)
                for (int j = 0; j < 4; j++)
                {
                    //Text += "-" + aPh[i].pos[j];
                    //if (aPh[i].pos[j] > 0) 
                        aPh[i].p[aPh[i].pos[j] - 1]++;
                }
            for (int j = nPh - 1; j > 0; j--)
                for (int k = 0; k < j; k++)
                    for (int z = 0; z < nPh; z++)
                    {
                        if (aPh[k].p[z] < aPh[j].p[z])
                        {
                            Phn ph = aPh[k];
                            aPh[k] = aPh[j];
                            aPh[j] = ph;
                            break;
                        }
                        if (aPh[k].p[z] > aPh[j].p[z]) break;
                    }
            //for (int i = 0; i < nPh; i++)
            //    Text += "-" + aPh[i].n;
            string s = "";
            int n = 0;
            int[] p = new int[nPh];
            for (int j = 0; j < nPh; j++)
            {
                int z = 0;
                if (j > 0)
                    for (; z < nPh; z++)
                        if (p[z] != aPh[j].p[z]) break;
                if (j == 0 || z < nPh) 
                {
                    if (j > 0 && z < nPh) 
                    {
                        SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, s);
                        if (!Show) tbReport.Text += s + "\n";
                        r++;
                        break;
                    }
                    n = 1;
                    aPh[j].p.CopyTo(p, 0);
                    s = dgPh.Rows[aPh[j].n].Cells[0].Value.ToString();
                }
                else
                {
                    n++;
                    s += ", " + dgPh.Rows[aPh[j].n].Cells[0].Value.ToString();
                }
                if (j == nPh - 1)
                {
                    SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, s);
                    if (!Show) tbReport.Text += s + "\n";
                    r++;
                }
            }
            string[] aM = { "Метод блокировки: ", "Метод доминирования: ", "Турнирный механизм: ", "Метод k-максимальных критериев: " };
            for (int i = 0; i < n; i++)
            {
                if (n > 1)
                {
                    SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, dgPh.Rows[aPh[i].n].Cells[0].Value.ToString());
                    if (Show) Rng.Font.Bold = true;
                    else tbReport.Text += dgPh.Rows[aPh[i].n].Cells[0].Value.ToString() + "\n";
                    r++;
                }
                SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, "С результатами:");
                if (!Show) tbReport.Text += "С результатами:\n";
                r++;
                for (int j = 0; j < 4; j++, r++)
                {
                    SetRange("A" + r, "AZ" + r, Excel.XlHAlign.xlHAlignLeft, aM[j] + aPh[i].pos[j] + "-е место");
                    if (!Show) tbReport.Text += aM[j] + aPh[i].pos[j] + "-е место\n";
                }
            }
            if (Show) XLS.Visible = true;
        }
        //
        private void SetRange(string l, string r, Excel.XlHAlign ha, string txt)
        {
            if (Show)
            {
                Rng = Sh.get_Range(l, r);
                Rng.Merge(Type.Missing);
                Rng.NumberFormat = "@";
                Rng.HorizontalAlignment = ha;
                Rng.Cells[1, "A"] = txt;
            }
        }
        //
        private void Border()
        {
            if(Show)
            for (int br = 0; br < 4; br++)
                Rng.Borders[aBr[br]].LineStyle = Excel.XlLineStyle.xlContinuous;
        }
    }
}