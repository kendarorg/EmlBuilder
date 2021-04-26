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
    public partial class AttachDialog : Form
    {
        public AttachDialog()
        {
            InitializeComponent();
            IsOk = false;
        }

        public string FileName { get; internal set; }
        public string Mime { get; internal set; }
        public bool IsOk { get; internal set; }

        private void btOk_Click(object sender, EventArgs e)
        {
            FileName = tbFileName.Text;
            Mime = tbFileMime.Text;
            IsOk = true;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AttachDialog_Shown(object sender, EventArgs e)
        {
            tbFileMime.Text = Mime;
            tbFileName.Text = FileName;

        }
    }
}
