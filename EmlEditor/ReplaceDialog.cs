using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlEditor
{
    public partial class ReplaceDialog : Form
    {
        private RichTextBox m_tbContent;
        private string m_selection;

        public ReplaceDialog(RichTextBox tbContent, String selection)
        {
            InitializeComponent();
            this.m_tbContent = tbContent;
            this.m_selection = selection;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            var text = m_tbContent.Text;
            m_tbContent.Text = text.Replace(tbWhat.Text, tbWith.Text);
        }

        private void ReplaceDialog_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(m_selection))
            {
                tbWhat.Text = m_selection;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
