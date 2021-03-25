using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Телефоны
{
    public partial class Frm : Form
    {
        void FillMatrix()
        {
            int nPh = aComp[idxCmp].aMatrix.GetLength(0); ;
            aComp[idxCmp].was = true;
            for (int i = 0; i < nPh; i++)
                    for (int j = 0; j < nPh; j++)
                        aComp[idxCmp].aMatrix[i, j] = 1;
            for (int i = 0; i < nPh; i++)
            {
                int yi = (int)aLb[i].Tag / 100;
                for (int j = 0; j < nPh; j++)
                    if (i != j)
                    {
                        int yj = (int)aLb[j].Tag / 100;
                        if (yj < yi) aComp[idxCmp].aMatrix[i, j] = 0;
                    }
            }
        }
        //
        void SetMatrix(int nPh)
        {
            //if (nPh > 0)
            {
                dgMatrix.RowCount = nPh;
                dgMatrix.ColumnCount = nPh + 2;
                dgMatrix.Columns[0].Width = dgPh.ClientSize.Width;
                dgMatrix.Columns[0].HeaderText = "Телефон";
                int w = (dgMatrix.ClientSize.Width - dgMatrix.Columns[0].Width) / (nPh + 1);
                for (int i = 0; i < dgMatrix.ColumnCount; i++)
                {
                    dgMatrix.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i > 1) dgMatrix.Columns[i].HeaderText = (i - 1).ToString();
                    if (i > 0) dgMatrix.Columns[i].Width = w;
                }
                for (int i = 0; i < nPh; i++)
                {
                    dgMatrix.Rows[i].Cells[0].Style.BackColor =
                    dgMatrix.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                    dgMatrix.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgMatrix.Rows[i].Cells[0].Value = dgPh.Rows[i].Cells[0].Value;
                    dgMatrix.Rows[i].Cells[1].Value = (i + 1).ToString();
                    dgMatrix.Rows[i].Cells[2].Selected = false;
                }
                if (nPh > 0) dgMatrix.Rows[0].Cells[2].Selected = true;
                if (!aComp[idxCmp].was) FillMatrix();
                for (int i = 0; i < nPh; i++)
                    for (int j = 0; j < nPh; j++)
                        dgMatrix.Rows[i].Cells[j + 2].Value = aComp[idxCmp].aMatrix[i, j].ToString();
            }
        }
        //
        private void dgMatrix_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dg.CurrentCell != null)
            {
                int nPh = dgPh.Rows[0].Cells[0].Value != null ? dgPh.Rows.Count : 0;
                if (dg.CurrentCell.ColumnIndex < 2)
                {
                    dg.Rows[dg.CurrentCell.RowIndex].Cells[dg.CurrentCell.ColumnIndex].Selected = false;
                    if (dg.ColumnCount > 2) dg.Rows[0].Cells[2].Selected = true;
                }
            }
        }
        //
        private void dgMatrix_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            if (dg.CurrentCell.ColumnIndex > 1) 
            {
                int r = dg.CurrentCell.RowIndex;
                int c = dg.CurrentCell.ColumnIndex;
                if (r != c - 2)
                {
                    aComp[idxCmp].aMatrix[r, c - 2] = 1 - aComp[idxCmp].aMatrix[r, c - 2];
                    dgMatrix.Rows[r].Cells[c].Value = aComp[idxCmp].aMatrix[r, c - 2].ToString();
                }
            }
        }
    }
}