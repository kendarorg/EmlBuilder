
namespace EmlEditor
{
    partial class ReplaceDialog
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
            this.btOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWith = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWhat = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(11, 73);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 10;
            this.btOk.Text = "Replace";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "With";
            // 
            // tbWith
            // 
            this.tbWith.Location = new System.Drawing.Point(68, 38);
            this.tbWith.Name = "tbWith";
            this.tbWith.Size = new System.Drawing.Size(198, 20);
            this.tbWith.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "What";
            // 
            // tbWhat
            // 
            this.tbWhat.Location = new System.Drawing.Point(68, 12);
            this.tbWhat.Name = "tbWhat";
            this.tbWhat.Size = new System.Drawing.Size(198, 20);
            this.tbWhat.TabIndex = 6;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(191, 73);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 12;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ReplaceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 117);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbWith);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWhat);
            this.Name = "ReplaceDialog";
            this.Text = "ReplaceDialog";
            this.Shown += new System.EventHandler(this.ReplaceDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWith;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWhat;
        private System.Windows.Forms.Button btClose;
    }
}