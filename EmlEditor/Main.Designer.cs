
namespace EmlEditor
{
    partial class Main
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
            this.wbHtml = new System.Windows.Forms.WebBrowser();
            this.btLoadText = new System.Windows.Forms.Button();
            this.btLoadHtml = new System.Windows.Forms.Button();
            this.btLoadEml = new System.Windows.Forms.Button();
            this.lbAttachments = new System.Windows.Forms.ListBox();
            this.btAttach = new System.Windows.Forms.Button();
            this.btDetach = new System.Windows.Forms.Button();
            this.btSaveEml = new System.Windows.Forms.Button();
            this.tbEmlPath = new System.Windows.Forms.TextBox();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBCC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.btTestHtml = new System.Windows.Forms.Button();
            this.cbForceUTF8 = new System.Windows.Forms.CheckBox();
            this.tbContent = new System.Windows.Forms.RichTextBox();
            this.btFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btPrev = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btClean = new System.Windows.Forms.Button();
            this.btReplace = new System.Windows.Forms.Button();
            this.btHelp = new System.Windows.Forms.Button();
            this.wbText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // wbHtml
            // 
            this.wbHtml.Location = new System.Drawing.Point(12, 161);
            this.wbHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHtml.Name = "wbHtml";
            this.wbHtml.Size = new System.Drawing.Size(776, 165);
            this.wbHtml.TabIndex = 0;
            this.wbHtml.Visible = false;
            // 
            // btLoadText
            // 
            this.btLoadText.Location = new System.Drawing.Point(5, 18);
            this.btLoadText.Name = "btLoadText";
            this.btLoadText.Size = new System.Drawing.Size(75, 23);
            this.btLoadText.TabIndex = 1;
            this.btLoadText.Text = "Load Text";
            this.btLoadText.UseVisualStyleBackColor = true;
            this.btLoadText.Click += new System.EventHandler(this.btLoadText_Click);
            // 
            // btLoadHtml
            // 
            this.btLoadHtml.Location = new System.Drawing.Point(86, 18);
            this.btLoadHtml.Name = "btLoadHtml";
            this.btLoadHtml.Size = new System.Drawing.Size(75, 23);
            this.btLoadHtml.TabIndex = 2;
            this.btLoadHtml.Text = "Load Html";
            this.btLoadHtml.UseVisualStyleBackColor = true;
            this.btLoadHtml.Click += new System.EventHandler(this.btLoadHtml_Click);
            // 
            // btLoadEml
            // 
            this.btLoadEml.Location = new System.Drawing.Point(86, 50);
            this.btLoadEml.Name = "btLoadEml";
            this.btLoadEml.Size = new System.Drawing.Size(90, 23);
            this.btLoadEml.TabIndex = 3;
            this.btLoadEml.Text = "Load Eml/MSG";
            this.btLoadEml.UseVisualStyleBackColor = true;
            this.btLoadEml.Click += new System.EventHandler(this.btLoadEml_Click);
            // 
            // lbAttachments
            // 
            this.lbAttachments.FormattingEnabled = true;
            this.lbAttachments.Location = new System.Drawing.Point(608, 47);
            this.lbAttachments.Name = "lbAttachments";
            this.lbAttachments.Size = new System.Drawing.Size(156, 108);
            this.lbAttachments.TabIndex = 4;
            this.lbAttachments.SelectedIndexChanged += new System.EventHandler(this.lbAttachments_SelectedIndexChanged);
            // 
            // btAttach
            // 
            this.btAttach.Location = new System.Drawing.Point(608, 18);
            this.btAttach.Name = "btAttach";
            this.btAttach.Size = new System.Drawing.Size(75, 23);
            this.btAttach.TabIndex = 5;
            this.btAttach.Text = "Attach";
            this.btAttach.UseVisualStyleBackColor = true;
            this.btAttach.Click += new System.EventHandler(this.btAttach_Click);
            // 
            // btDetach
            // 
            this.btDetach.Enabled = false;
            this.btDetach.Location = new System.Drawing.Point(689, 18);
            this.btDetach.Name = "btDetach";
            this.btDetach.Size = new System.Drawing.Size(75, 23);
            this.btDetach.TabIndex = 6;
            this.btDetach.Text = "Detach";
            this.btDetach.UseVisualStyleBackColor = true;
            this.btDetach.Click += new System.EventHandler(this.btDetach_Click);
            // 
            // btSaveEml
            // 
            this.btSaveEml.Location = new System.Drawing.Point(5, 50);
            this.btSaveEml.Name = "btSaveEml";
            this.btSaveEml.Size = new System.Drawing.Size(75, 23);
            this.btSaveEml.TabIndex = 8;
            this.btSaveEml.Text = "SaveEml";
            this.btSaveEml.UseVisualStyleBackColor = true;
            this.btSaveEml.Click += new System.EventHandler(this.btSaveEml_Click);
            // 
            // tbEmlPath
            // 
            this.tbEmlPath.Location = new System.Drawing.Point(191, 52);
            this.tbEmlPath.Name = "tbEmlPath";
            this.tbEmlPath.ReadOnly = true;
            this.tbEmlPath.Size = new System.Drawing.Size(385, 20);
            this.tbEmlPath.TabIndex = 9;
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(46, 80);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(241, 20);
            this.tbFrom.TabIndex = 10;
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(46, 106);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(241, 20);
            this.tbTo.TabIndex = 11;
            // 
            // tbCC
            // 
            this.tbCC.Location = new System.Drawing.Point(335, 80);
            this.tbCC.Name = "tbCC";
            this.tbCC.Size = new System.Drawing.Size(241, 20);
            this.tbCC.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "CC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "BCC";
            // 
            // tbBCC
            // 
            this.tbBCC.Location = new System.Drawing.Point(335, 105);
            this.tbBCC.Name = "tbBCC";
            this.tbBCC.Size = new System.Drawing.Size(241, 20);
            this.tbBCC.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Subj.";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(46, 132);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(530, 20);
            this.tbSubject.TabIndex = 20;
            // 
            // btTestHtml
            // 
            this.btTestHtml.Location = new System.Drawing.Point(650, 343);
            this.btTestHtml.Name = "btTestHtml";
            this.btTestHtml.Size = new System.Drawing.Size(138, 23);
            this.btTestHtml.TabIndex = 23;
            this.btTestHtml.Text = "Apply: ^ ^ ^ ";
            this.btTestHtml.UseVisualStyleBackColor = true;
            this.btTestHtml.Click += new System.EventHandler(this.btTestHtml_Click);
            // 
            // cbForceUTF8
            // 
            this.cbForceUTF8.AutoSize = true;
            this.cbForceUTF8.Checked = true;
            this.cbForceUTF8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbForceUTF8.Location = new System.Drawing.Point(419, 23);
            this.cbForceUTF8.Name = "cbForceUTF8";
            this.cbForceUTF8.Size = new System.Drawing.Size(153, 17);
            this.cbForceUTF8.TabIndex = 24;
            this.cbForceUTF8.Text = "Force UTF8 When Missing";
            this.cbForceUTF8.UseVisualStyleBackColor = true;
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(13, 369);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(775, 234);
            this.tbContent.TabIndex = 25;
            this.tbContent.Text = "";
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(82, 343);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(75, 23);
            this.btFind.TabIndex = 26;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(163, 345);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(215, 20);
            this.tbFind.TabIndex = 27;
            // 
            // btPrev
            // 
            this.btPrev.Location = new System.Drawing.Point(428, 342);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(55, 23);
            this.btPrev.TabIndex = 28;
            this.btPrev.Text = "Prev";
            this.btPrev.UseVisualStyleBackColor = true;
            this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(489, 343);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(53, 23);
            this.btNext.TabIndex = 29;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btClean
            // 
            this.btClean.Location = new System.Drawing.Point(372, 343);
            this.btClean.Name = "btClean";
            this.btClean.Size = new System.Drawing.Size(55, 23);
            this.btClean.TabIndex = 30;
            this.btClean.Text = "Clean";
            this.btClean.UseVisualStyleBackColor = true;
            this.btClean.Click += new System.EventHandler(this.btClean_Click);
            // 
            // btReplace
            // 
            this.btReplace.Location = new System.Drawing.Point(5, 343);
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size(75, 23);
            this.btReplace.TabIndex = 31;
            this.btReplace.Text = "Replace";
            this.btReplace.UseVisualStyleBackColor = true;
            this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
            // 
            // btHelp
            // 
            this.btHelp.Location = new System.Drawing.Point(167, 18);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(75, 23);
            this.btHelp.TabIndex = 32;
            this.btHelp.Text = "Help";
            this.btHelp.UseVisualStyleBackColor = true;
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
            // 
            // wbText
            // 
            this.wbText.Location = new System.Drawing.Point(13, 161);
            this.wbText.Name = "wbText";
            this.wbText.ReadOnly = true;
            this.wbText.Size = new System.Drawing.Size(775, 166);
            this.wbText.TabIndex = 33;
            this.wbText.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 615);
            this.Controls.Add(this.wbText);
            this.Controls.Add(this.btHelp);
            this.Controls.Add(this.btReplace);
            this.Controls.Add(this.btClean);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btPrev);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.cbForceUTF8);
            this.Controls.Add(this.btTestHtml);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbBCC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCC);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.tbEmlPath);
            this.Controls.Add(this.btSaveEml);
            this.Controls.Add(this.btDetach);
            this.Controls.Add(this.btAttach);
            this.Controls.Add(this.lbAttachments);
            this.Controls.Add(this.btLoadEml);
            this.Controls.Add(this.btLoadHtml);
            this.Controls.Add(this.btLoadText);
            this.Controls.Add(this.wbHtml);
            this.Name = "Main";
            this.Text = "EmlEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbHtml;
        private System.Windows.Forms.Button btLoadText;
        private System.Windows.Forms.Button btLoadHtml;
        private System.Windows.Forms.Button btLoadEml;
        private System.Windows.Forms.ListBox lbAttachments;
        private System.Windows.Forms.Button btAttach;
        private System.Windows.Forms.Button btDetach;
        private System.Windows.Forms.Button btSaveEml;
        private System.Windows.Forms.TextBox tbEmlPath;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Button btTestHtml;
        private System.Windows.Forms.CheckBox cbForceUTF8;
        private System.Windows.Forms.RichTextBox tbContent;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btClean;
        private System.Windows.Forms.Button btReplace;
        private System.Windows.Forms.Button btHelp;
        private System.Windows.Forms.RichTextBox wbText;
    }
}

