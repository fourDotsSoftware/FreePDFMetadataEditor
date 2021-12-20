using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFMetadataEditor
{
    public partial class frmSpecialItem : FreePDFMetadataEditor.CustomForm
    {
        public frmSpecialItem()
        {
            InitializeComponent();
        }

        public string SelectedItem = "";

        DataTable dtspecialitem = new DataTable("tablespecial");

        private void frmSpecialItem_Load(object sender, EventArgs e)
        {
            dtspecialitem.Columns.Add("specialitem");
            dtspecialitem.Columns.Add("specialvalue");

            dgSpecialItem.AutoGenerateColumns = false;

            dgSpecialItem.DataSource = dtspecialitem;

            DataRow dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Metadata Value");
            dr["specialvalue"] = "{CURRENT VALUE}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Filename");
            dr["specialvalue"] = "{FILENAME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Filename Without Extension");
            dr["specialvalue"] = "{FILENAME WITHOUT EXTENSION}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Full File Path");
            dr["specialvalue"] = "{FULLFILEPATH}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Directory Name");
            dr["specialvalue"] = "{DIRECTORY NAME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Directory Path");
            dr["specialvalue"] = "{DIRECTORY PATH}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Last Write Date and Time");
            dr["specialvalue"] = "{LAST WRITE TIME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Creation Date and Time");
            dr["specialvalue"] = "{CREATION TIME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Last Access Date and Time");
            dr["specialvalue"] = "{LAST ACCESS TIME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Date");
            dr["specialvalue"] = "{CURRENT DATE}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Time");
            dr["specialvalue"] = "{CURRENT TIME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Date and Time");
            dr["specialvalue"] = "{CURRENT DATETIME}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Day (DD)");
            dr["specialvalue"] = "{DAY}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Month (MM)");
            dr["specialvalue"] = "{MONTH}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Year (YYYY)");
            dr["specialvalue"] = "{YEAR}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Hour (HH)");
            dr["specialvalue"] = "{HOUR}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Minute (MI)");
            dr["specialvalue"] = "{MIN}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Second (SS)");
            dr["specialvalue"] = "{SEC}";
            dtspecialitem.Rows.Add(dr);

            dr = dtspecialitem.NewRow();
            dr["specialitem"] = TranslateHelper.Translate("Current Custom Date");
            dr["specialvalue"] = "{CUSTOM DATE:[FORMAT]}";
            dtspecialitem.Rows.Add(dr);

            dgSpecialItem.DataSource = dtspecialitem;

            dgSpecialItem.ClearSelection();

            chkFind.Checked = Properties.Settings.Default.SpecialFind;
            chkSpecialItem.Checked = Properties.Settings.Default.SpecialSpecialItem;

            dgSpecialItem.Rows[Properties.Settings.Default.SpecialItemIndex].Selected = true;

            txtFind.Text = Properties.Settings.Default.SpecialFindText;
            txtReplace.Text = Properties.Settings.Default.SpecialReplaceText;

            chkRegExp.Checked = Properties.Settings.Default.SpecialRegExp;
            chkWildcards.Checked = Properties.Settings.Default.SpecialWildcards;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkSpecialItem.Checked)
            {
                DataRowView drv = (DataRowView)dgSpecialItem.CurrentRow.DataBoundItem;
                SelectedItem = drv.Row["specialvalue"].ToString();
            }
            else
            {
                if (txtFind.Text.Trim() == string.Empty)
                {
                    Module.ShowMessage("Please specify Metadata Value text to Find !");
                    return;
                }

                if (chkRegExp.Checked)
                {                   
                    SelectedItem = "|||FindRegExp:" + txtFind.Text + "|||Replace:" + txtReplace.Text + "|||";
                }
                else if (chkWildcards.Checked)
                {                   
                    SelectedItem = "|||FindWildcards:" + txtFind.Text + "|||Replace:" + txtReplace.Text + "|||";
                }
                else
                {                   
                    SelectedItem = "|||Find:" + txtFind.Text + "|||Replace:" + txtReplace.Text + "|||";
                }
            }

            Properties.Settings.Default.SpecialFind = chkFind.Checked;
            Properties.Settings.Default.SpecialSpecialItem = chkSpecialItem.Checked;

            Properties.Settings.Default.SpecialItemIndex = dgSpecialItem.SelectedRows[0].Index;

            Properties.Settings.Default.SpecialFindText = txtFind.Text;
            Properties.Settings.Default.SpecialReplaceText = txtReplace.Text;

            Properties.Settings.Default.SpecialRegExp = chkRegExp.Checked;
            Properties.Settings.Default.SpecialWildcards = chkWildcards.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void dgSpecialItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void chkSpecialItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialItem.Checked)
            {
                chkFind.Checked = false;
                grpFind.Enabled = false;
                dgSpecialItem.Enabled = true;                
            }
        }

        private void chkFind_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFind.Checked)
            {
                chkSpecialItem.Checked = false;
                grpFind.Enabled = true;
                dgSpecialItem.Enabled = false;                
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtReplaceMatchGroup.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please insert a Regular Expression Match Group Name !");
                return;
            }

            txtReplace.Text += "###MATCH GROUP:" + txtReplaceMatchGroup.Text + "###";

            chkRegExp.Checked = true;
        }

        private void chkRegExp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegExp.Checked)
            {
                chkWildcards.Checked = false;
            }
        }

        private void chkWildcards_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWildcards.Checked)
            {
                chkRegExp.Checked = false;
            }
        }
    }
}
