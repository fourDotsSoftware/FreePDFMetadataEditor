namespace FreePDFMetadataEditor
{
    partial class frmSpecialItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkFind = new System.Windows.Forms.CheckBox();
            this.chkSpecialItem = new System.Windows.Forms.CheckBox();
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.chkWildcards = new System.Windows.Forms.CheckBox();
            this.chkRegExp = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReplaceMatchGroup = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgSpecialItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSpecialItem)).BeginInit();
            this.SuspendLayout();
            // 
            // chkFind
            // 
            resources.ApplyResources(this.chkFind, "chkFind");
            this.chkFind.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkFind.Name = "chkFind";
            this.chkFind.UseVisualStyleBackColor = true;
            this.chkFind.CheckedChanged += new System.EventHandler(this.chkFind_CheckedChanged);
            // 
            // chkSpecialItem
            // 
            resources.ApplyResources(this.chkSpecialItem, "chkSpecialItem");
            this.chkSpecialItem.Checked = true;
            this.chkSpecialItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpecialItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkSpecialItem.Name = "chkSpecialItem";
            this.chkSpecialItem.UseVisualStyleBackColor = true;
            this.chkSpecialItem.CheckedChanged += new System.EventHandler(this.chkSpecialItem_CheckedChanged);
            // 
            // grpFind
            // 
            this.grpFind.BackColor = System.Drawing.Color.Transparent;
            this.grpFind.Controls.Add(this.chkWildcards);
            this.grpFind.Controls.Add(this.chkRegExp);
            this.grpFind.Controls.Add(this.label3);
            this.grpFind.Controls.Add(this.btnInsert);
            this.grpFind.Controls.Add(this.label2);
            this.grpFind.Controls.Add(this.txtReplaceMatchGroup);
            this.grpFind.Controls.Add(this.txtReplace);
            this.grpFind.Controls.Add(this.txtFind);
            this.grpFind.Controls.Add(this.label1);
            resources.ApplyResources(this.grpFind, "grpFind");
            this.grpFind.Name = "grpFind";
            this.grpFind.TabStop = false;
            // 
            // chkWildcards
            // 
            resources.ApplyResources(this.chkWildcards, "chkWildcards");
            this.chkWildcards.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkWildcards.Name = "chkWildcards";
            this.chkWildcards.UseVisualStyleBackColor = true;
            this.chkWildcards.CheckedChanged += new System.EventHandler(this.chkWildcards_CheckedChanged);
            // 
            // chkRegExp
            // 
            resources.ApplyResources(this.chkRegExp, "chkRegExp");
            this.chkRegExp.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkRegExp.Name = "chkRegExp";
            this.chkRegExp.UseVisualStyleBackColor = true;
            this.chkRegExp.CheckedChanged += new System.EventHandler(this.chkRegExp_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // btnInsert
            // 
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // txtReplaceMatchGroup
            // 
            resources.ApplyResources(this.txtReplaceMatchGroup, "txtReplaceMatchGroup");
            this.txtReplaceMatchGroup.Name = "txtReplaceMatchGroup";
            // 
            // txtReplace
            // 
            resources.ApplyResources(this.txtReplace, "txtReplace");
            this.txtReplace.Name = "txtReplace";
            // 
            // txtFind
            // 
            resources.ApplyResources(this.txtFind, "txtFind");
            this.txtFind.Name = "txtFind";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::FreePDFMetadataEditor.Properties.Resources.check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgSpecialItem
            // 
            this.dgSpecialItem.AllowDrop = true;
            this.dgSpecialItem.AllowUserToAddRows = false;
            this.dgSpecialItem.AllowUserToDeleteRows = false;
            this.dgSpecialItem.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgSpecialItem, "dgSpecialItem");
            this.dgSpecialItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSpecialItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgSpecialItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colSpecialValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSpecialItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgSpecialItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgSpecialItem.GridColor = System.Drawing.Color.Black;
            this.dgSpecialItem.Name = "dgSpecialItem";
            this.dgSpecialItem.RowHeadersVisible = false;
            this.dgSpecialItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSpecialItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSpecialItem_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "specialitem";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // colSpecialValue
            // 
            this.colSpecialValue.DataPropertyName = "specialvalue";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSpecialValue.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colSpecialValue, "colSpecialValue");
            this.colSpecialValue.Name = "colSpecialValue";
            this.colSpecialValue.ReadOnly = true;
            // 
            // frmSpecialItem
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkFind);
            this.Controls.Add(this.chkSpecialItem);
            this.Controls.Add(this.grpFind);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgSpecialItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpecialItem";
            this.Load += new System.EventHandler(this.frmSpecialItem_Load);
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSpecialItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSpecialItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialValue;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.GroupBox grpFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReplaceMatchGroup;
        private System.Windows.Forms.CheckBox chkFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSpecialItem;
        private System.Windows.Forms.CheckBox chkWildcards;
        private System.Windows.Forms.CheckBox chkRegExp;
    }
}
