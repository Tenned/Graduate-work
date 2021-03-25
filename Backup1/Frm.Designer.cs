namespace Телефоны
{
    partial class Frm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.Pn0 = new System.Windows.Forms.Panel();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.dgPh = new System.Windows.Forms.DataGridView();
            this.dgCr = new System.Windows.Forms.DataGridView();
            this.Pn1 = new System.Windows.Forms.Panel();
            this.pnCr = new System.Windows.Forms.Panel();
            this.btProf = new System.Windows.Forms.Button();
            this.Pn4 = new System.Windows.Forms.Panel();
            this.dgMatrix = new System.Windows.Forms.DataGridView();
            this.Pn5 = new System.Windows.Forms.Panel();
            this.btShort = new System.Windows.Forms.Button();
            this.tbReport = new System.Windows.Forms.RichTextBox();
            this.btReport = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.Pn2 = new System.Windows.Forms.Panel();
            this.lbSum = new System.Windows.Forms.Label();
            this.btNorm = new System.Windows.Forms.Button();
            this.Pn3 = new System.Windows.Forms.Panel();
            this.pnPhone = new System.Windows.Forms.Panel();
            this.lbStep0 = new System.Windows.Forms.Label();
            this.lbStep1 = new System.Windows.Forms.Label();
            this.lbStep2 = new System.Windows.Forms.Label();
            this.lbStep3 = new System.Windows.Forms.Label();
            this.lbCmp = new System.Windows.Forms.Label();
            this.Pn0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCr)).BeginInit();
            this.Pn1.SuspendLayout();
            this.Pn4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatrix)).BeginInit();
            this.Pn5.SuspendLayout();
            this.Pn2.SuspendLayout();
            this.Pn3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pn0
            // 
            this.Pn0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pn0.Controls.Add(this.btDelete);
            this.Pn0.Controls.Add(this.btAdd);
            this.Pn0.Controls.Add(this.dgPh);
            this.Pn0.Location = new System.Drawing.Point(2, 25);
            this.Pn0.Name = "Pn0";
            this.Pn0.Size = new System.Drawing.Size(1002, 545);
            this.Pn0.TabIndex = 1;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(215, 6);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(85, 23);
            this.btDelete.TabIndex = 7;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            this.btDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(8, 6);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(85, 23);
            this.btAdd.TabIndex = 6;
            this.btAdd.Text = "Добавить(Ins)";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            this.btAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // dgPh
            // 
            this.dgPh.AllowUserToAddRows = false;
            this.dgPh.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgPh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPh.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgPh.Location = new System.Drawing.Point(8, 32);
            this.dgPh.Name = "dgPh";
            this.dgPh.RowHeadersVisible = false;
            this.dgPh.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgPh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgPh.Size = new System.Drawing.Size(292, 229);
            this.dgPh.TabIndex = 5;
            this.dgPh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // dgCr
            // 
            this.dgCr.AllowUserToAddRows = false;
            this.dgCr.AllowUserToDeleteRows = false;
            this.dgCr.AllowUserToResizeColumns = false;
            this.dgCr.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgCr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCr.ColumnHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCr.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgCr.Location = new System.Drawing.Point(2, 6);
            this.dgCr.MultiSelect = false;
            this.dgCr.Name = "dgCr";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCr.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgCr.RowHeadersWidth = 225;
            this.dgCr.RowTemplate.Height = 28;
            this.dgCr.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgCr.Size = new System.Drawing.Size(327, 229);
            this.dgCr.TabIndex = 8;
            this.dgCr.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCr_CellEndEdit);
            this.dgCr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // Pn1
            // 
            this.Pn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pn1.BackColor = System.Drawing.SystemColors.Control;
            this.Pn1.Controls.Add(this.pnCr);
            this.Pn1.Location = new System.Drawing.Point(2, 46);
            this.Pn1.Name = "Pn1";
            this.Pn1.Size = new System.Drawing.Size(1002, 524);
            this.Pn1.TabIndex = 8;
            // 
            // pnCr
            // 
            this.pnCr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnCr.BackColor = System.Drawing.SystemColors.Control;
            this.pnCr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCr.Location = new System.Drawing.Point(2, 2);
            this.pnCr.Name = "pnCr";
            this.pnCr.Size = new System.Drawing.Size(1000, 425);
            this.pnCr.TabIndex = 2;
            // 
            // btProf
            // 
            this.btProf.Location = new System.Drawing.Point(789, 24);
            this.btProf.Name = "btProf";
            this.btProf.Size = new System.Drawing.Size(147, 23);
            this.btProf.TabIndex = 8;
            this.btProf.Text = "Профессиональный ввод";
            this.btProf.UseVisualStyleBackColor = true;
            this.btProf.Click += new System.EventHandler(this.btProfNorm_Click);
            this.btProf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // Pn4
            // 
            this.Pn4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pn4.BackColor = System.Drawing.SystemColors.Control;
            this.Pn4.Controls.Add(this.dgMatrix);
            this.Pn4.Location = new System.Drawing.Point(2, 46);
            this.Pn4.Name = "Pn4";
            this.Pn4.Size = new System.Drawing.Size(1000, 524);
            this.Pn4.TabIndex = 11;
            // 
            // dgMatrix
            // 
            this.dgMatrix.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMatrix.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgMatrix.Location = new System.Drawing.Point(3, 5);
            this.dgMatrix.Name = "dgMatrix";
            this.dgMatrix.ReadOnly = true;
            this.dgMatrix.RowHeadersVisible = false;
            this.dgMatrix.Size = new System.Drawing.Size(933, 420);
            this.dgMatrix.TabIndex = 3;
            this.dgMatrix.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMatrix_CellDoubleClick);
            this.dgMatrix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.dgMatrix.SelectionChanged += new System.EventHandler(this.dgMatrix_SelectionChanged);
            // 
            // Pn5
            // 
            this.Pn5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pn5.BackColor = System.Drawing.SystemColors.Control;
            this.Pn5.Controls.Add(this.btShort);
            this.Pn5.Controls.Add(this.tbReport);
            this.Pn5.Controls.Add(this.btReport);
            this.Pn5.Location = new System.Drawing.Point(2, 25);
            this.Pn5.Name = "Pn5";
            this.Pn5.Size = new System.Drawing.Size(1002, 545);
            this.Pn5.TabIndex = 20;
            // 
            // btShort
            // 
            this.btShort.Location = new System.Drawing.Point(7, 2);
            this.btShort.Name = "btShort";
            this.btShort.Size = new System.Drawing.Size(101, 23);
            this.btShort.TabIndex = 2;
            this.btShort.Text = "Краткий вывод";
            this.btShort.UseVisualStyleBackColor = true;
            this.btShort.Click += new System.EventHandler(this.btShort_Click);
            this.btShort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // tbReport
            // 
            this.tbReport.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbReport.Location = new System.Drawing.Point(6, 26);
            this.tbReport.Name = "tbReport";
            this.tbReport.ReadOnly = true;
            this.tbReport.Size = new System.Drawing.Size(612, 516);
            this.tbReport.TabIndex = 1;
            this.tbReport.Text = "";
            this.tbReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // btReport
            // 
            this.btReport.Location = new System.Drawing.Point(515, 2);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(101, 23);
            this.btReport.TabIndex = 0;
            this.btReport.Text = "Полный отчет";
            this.btReport.UseVisualStyleBackColor = true;
            this.btReport.Click += new System.EventHandler(this.btReport_Click);
            this.btReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(356, 573);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "Выход";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            this.btExit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // btBack
            // 
            this.btBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btBack.Location = new System.Drawing.Point(275, 573);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btNextBack_Click);
            this.btBack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNext.Location = new System.Drawing.Point(356, 573);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 3;
            this.btNext.Text = "Далее";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNextBack_Click);
            this.btNext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // Pn2
            // 
            this.Pn2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pn2.Controls.Add(this.lbSum);
            this.Pn2.Controls.Add(this.dgCr);
            this.Pn2.Location = new System.Drawing.Point(2, 46);
            this.Pn2.Name = "Pn2";
            this.Pn2.Size = new System.Drawing.Size(1002, 524);
            this.Pn2.TabIndex = 4;
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSum.Location = new System.Drawing.Point(1, 238);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(68, 18);
            this.lbSum.TabIndex = 9;
            this.lbSum.Text = "Сумма:";
            // 
            // btNorm
            // 
            this.btNorm.Location = new System.Drawing.Point(800, 24);
            this.btNorm.Name = "btNorm";
            this.btNorm.Size = new System.Drawing.Size(96, 23);
            this.btNorm.TabIndex = 8;
            this.btNorm.Text = "Обычный ввод";
            this.btNorm.UseVisualStyleBackColor = true;
            this.btNorm.Click += new System.EventHandler(this.btProfNorm_Click);
            this.btNorm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            // 
            // Pn3
            // 
            this.Pn3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pn3.BackColor = System.Drawing.SystemColors.Control;
            this.Pn3.Controls.Add(this.pnPhone);
            this.Pn3.Location = new System.Drawing.Point(2, 46);
            this.Pn3.Name = "Pn3";
            this.Pn3.Size = new System.Drawing.Size(1002, 524);
            this.Pn3.TabIndex = 9;
            // 
            // pnPhone
            // 
            this.pnPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPhone.Location = new System.Drawing.Point(2, 2);
            this.pnPhone.Name = "pnPhone";
            this.pnPhone.Size = new System.Drawing.Size(1000, 500);
            this.pnPhone.TabIndex = 1;
            // 
            // lbStep0
            // 
            this.lbStep0.BackColor = System.Drawing.Color.White;
            this.lbStep0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStep0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStep0.Location = new System.Drawing.Point(9, 1);
            this.lbStep0.Name = "lbStep0";
            this.lbStep0.Size = new System.Drawing.Size(122, 17);
            this.lbStep0.TabIndex = 12;
            this.lbStep0.Text = "Ввод альтернатив";
            this.lbStep0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStep1
            // 
            this.lbStep1.BackColor = System.Drawing.Color.Gainsboro;
            this.lbStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStep1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStep1.Location = new System.Drawing.Point(134, 1);
            this.lbStep1.Name = "lbStep1";
            this.lbStep1.Size = new System.Drawing.Size(145, 17);
            this.lbStep1.TabIndex = 13;
            this.lbStep1.Text = "Приоритет критериев";
            this.lbStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStep2
            // 
            this.lbStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStep2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStep2.Location = new System.Drawing.Point(282, 1);
            this.lbStep2.Name = "lbStep2";
            this.lbStep2.Size = new System.Drawing.Size(195, 17);
            this.lbStep2.TabIndex = 14;
            this.lbStep2.Text = "Сравнение альтернатив";
            this.lbStep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStep3
            // 
            this.lbStep3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStep3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStep3.Location = new System.Drawing.Point(480, 1);
            this.lbStep3.Name = "lbStep3";
            this.lbStep3.Size = new System.Drawing.Size(91, 17);
            this.lbStep3.TabIndex = 15;
            this.lbStep3.Text = "Вывод";
            this.lbStep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCmp
            // 
            this.lbCmp.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCmp.Location = new System.Drawing.Point(282, 28);
            this.lbCmp.Name = "lbCmp";
            this.lbCmp.Size = new System.Drawing.Size(165, 17);
            this.lbCmp.TabIndex = 21;
            this.lbCmp.Text = "Сравнение альтернатив";
            this.lbCmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 623);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.lbStep3);
            this.Controls.Add(this.lbStep2);
            this.Controls.Add(this.lbStep1);
            this.Controls.Add(this.lbStep0);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.Pn5);
            this.Controls.Add(this.Pn0);
            this.Controls.Add(this.Pn1);
            this.Controls.Add(this.Pn3);
            this.Controls.Add(this.Pn2);
            this.Controls.Add(this.Pn4);
            this.Controls.Add(this.lbCmp);
            this.Controls.Add(this.btProf);
            this.Controls.Add(this.btNorm);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1017, 650);
            this.MinimumSize = new System.Drawing.Size(1017, 650);
            this.Name = "Frm";
            this.Text = "Телефоны";
            this.Shown += new System.EventHandler(this.Frm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.Pn0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCr)).EndInit();
            this.Pn1.ResumeLayout(false);
            this.Pn4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMatrix)).EndInit();
            this.Pn5.ResumeLayout(false);
            this.Pn2.ResumeLayout(false);
            this.Pn2.PerformLayout();
            this.Pn3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.Panel Pn0;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridView dgPh;
        private System.Windows.Forms.Panel Pn1;
        private System.Windows.Forms.Panel pnCr;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Panel Pn2;
        private System.Windows.Forms.DataGridView dgCr;
        private System.Windows.Forms.Panel Pn3;
        private System.Windows.Forms.Panel pnPhone;
        private System.Windows.Forms.Panel Pn4;
        private System.Windows.Forms.Panel Pn5;
        private System.Windows.Forms.DataGridView dgMatrix;
        private System.Windows.Forms.Label lbStep0;
        private System.Windows.Forms.Label lbStep1;
        private System.Windows.Forms.Label lbStep2;
        private System.Windows.Forms.Label lbStep3;
        private System.Windows.Forms.Button btProf;
        private System.Windows.Forms.Button btNorm;
        private System.Windows.Forms.Label lbCmp;
        private System.Windows.Forms.Button btReport;
        private System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.RichTextBox tbReport;
        private System.Windows.Forms.Button btShort;
    }
}

