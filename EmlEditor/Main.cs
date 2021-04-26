using MsgReader.Mime.Header;
using MsgReader.Outlook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EmlEditor
{
    public partial class Main : Form
    {
        private Encoding m_htmlBodyEncoding;
        private String m_HtmlContent = "";
        private Encoding m_textBodyEncoding;
        private String m_TextContent = "";
        private Dictionary<String, byte[]> m_Attachments = new Dictionary<string, byte[]>();
        public Main()
        {
            InitializeComponent();
            lbAttachments.DisplayMember = "Name";
            btLoadHtml_Click(null, null);
        }


        private void btLoadEml_Click(object sender, EventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find Eml Files";
            fileDialog.DefaultExt = "eml";
            fileDialog.Filter = "eml files (*.eml)|*.eml|msg files (*.msg)|*.msg|All files (*.*)|*.*";
            fileDialog.ShowDialog();
            if (!String.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                lbAttachments.Items.Clear();
                tbEmlPath.Text = fileDialog.FileName;
                m_Attachments = new Dictionary<string, byte[]>();
                m_HtmlContent = "";
                m_TextContent = "";
                tbTo.Text = "";
                tbCC.Text = "";
                tbBCC.Text = "";
                tbFrom.Text = "";
                tbSubject.Text = "";
                m_htmlBodyEncoding = Encoding.UTF8;
                m_textBodyEncoding = Encoding.UTF8;

                if (Path.GetExtension(fileDialog.FileName) == ".eml")
                {
                    var fileInfo = new FileInfo(tbEmlPath.Text);
                    var eml = MsgReader.Mime.Message.Load(fileInfo);
                    if (eml.Headers != null && eml.Headers.To != null) tbTo.Text = readEmails(eml.Headers.To);
                    if (eml.Headers != null && eml.Headers.Cc != null) tbCC.Text = readEmails(eml.Headers.Cc);
                    if (eml.Headers != null && eml.Headers.Bcc != null) tbBCC.Text = readEmails(eml.Headers.Bcc);
                    if (eml.Headers != null && eml.Headers.From != null) tbFrom.Text = readEmail(eml.Headers.From);
                    if (eml.Headers != null && eml.Headers.Subject != null) tbSubject.Text = eml.Headers.Subject;

                    if (eml.HtmlBody != null)
                    {
                        if (cbForceUTF8.Checked && eml.HtmlBody.BodyEncoding == Encoding.ASCII)
                        {
                            m_htmlBodyEncoding = Encoding.UTF8;
                        }
                        else
                        {
                            m_htmlBodyEncoding = eml.HtmlBody.BodyEncoding != null ? eml.HtmlBody.BodyEncoding : Encoding.UTF8;
                        }

                        m_HtmlContent = m_htmlBodyEncoding.GetString(eml.HtmlBody.Body);
                    }
                    if (eml.TextBody != null)
                    {
                        if (cbForceUTF8.Checked && eml.TextBody.BodyEncoding == Encoding.ASCII)
                        {
                            m_textBodyEncoding = Encoding.UTF8;
                        }
                        else
                        {
                            m_textBodyEncoding = eml.TextBody.BodyEncoding != null ? eml.TextBody.BodyEncoding : Encoding.UTF8;
                        }

                        m_TextContent = m_textBodyEncoding.GetString(eml.TextBody.Body);
                    }

                    foreach (object item in readAttachments(eml.Attachments))
                    {
                        lbAttachments.Items.Add(item);
                    }
                }
                else if (Path.GetExtension(fileDialog.FileName) == ".msg")
                {
                    using (var eml = new MsgReader.Outlook.Storage.Message(tbEmlPath.Text))
                    {
                        tbFrom.Text = readEmail(eml.Sender);
                        if (eml.Headers != null && eml.Headers.To != null) tbTo.Text = readEmails(eml.Headers.To);
                        if (eml.Headers != null && eml.Headers.Cc != null) tbCC.Text = readEmails(eml.Headers.Cc);
                        if (eml.Headers != null && eml.Headers.Bcc != null) tbBCC.Text = readEmails(eml.Headers.Bcc);
                        if (eml.Headers != null && eml.Headers.From != null) tbFrom.Text = readEmail(eml.Headers.From);
                        if (eml.Headers != null && eml.Headers.Subject != null) tbSubject.Text = eml.Headers.Subject;

                        if (eml.BodyHtml != null)
                        {
                            m_HtmlContent = eml.BodyHtml;
                        }
                        if (eml.BodyText != null) m_TextContent = eml.BodyText;

                        foreach (object item in readAttachments(eml.Attachments))
                        {
                            lbAttachments.Items.Add(item);
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(m_HtmlContent))
                {
                    btLoadHtml_Click(null, null);
                }
                else if (!string.IsNullOrWhiteSpace(m_TextContent))
                {
                    btLoadText_Click(null, null);
                }
            }
        }

        private IEnumerable<EmlAttachment> readAttachments(List<object> attachments)
        {
            foreach (var item in attachments)
            {
                var attachment = item as Storage.Attachment;
                if (attachment != null)
                {
                    yield return new EmlAttachment(attachment);
                }
            }
        }

        private IEnumerable<EmlAttachment> readAttachments(ReadOnlyCollection<MsgReader.Mime.MessagePart> attachments)
        {
            foreach (var attachment in attachments)
            {
                if (attachment.IsAttachment)
                {
                    yield return new EmlAttachment(attachment);
                }
            }
        }

        private string readEmail(Storage.Sender from)
        {
            if (!string.IsNullOrWhiteSpace(from.DisplayName))
            {
                return from.DisplayName + "<" + from.Email + ">";
            }
            return from.Email;
        }

        private string readEmails(List<RfcMailAddress> to)
        {
            String result = "";
            foreach (var recipient in to)
            {
                if (result.Length > 0) result += ";";
                result += readEmail(recipient);
            }
            return result;
        }

        private string readEmail(RfcMailAddress from)
        {
            if (string.IsNullOrWhiteSpace(from.Address))
            {
                return from.DisplayName;
            }
            if (!string.IsNullOrWhiteSpace(from.DisplayName))
            {
                return from.DisplayName + "<" + from.Address + ">";
            }
            return from.Address;
        }

        private void btSaveEml_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbFrom.Text) || string.IsNullOrWhiteSpace(tbTo.Text))
            {
                MessageBox.Show("To and from must be set before saving!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Save Eml Files";
            fileDialog.DefaultExt = "eml";
            fileDialog.Filter = "eml files (*.eml)|*.eml|All files (*.*)|*.*";
            fileDialog.ShowDialog();
            if (!String.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                tbEmlPath.Text = fileDialog.FileName;
                var message = new MailMessage();
                List<Tuple<String, string>> toReplace = new List<Tuple<string, string>>();
                toReplace.Add(addMessageEmails(message.To, tbTo.Text));
                toReplace.Add(addMessageEmails(message.CC, tbCC.Text));
                toReplace.Add(addMessageEmails(message.Bcc, tbBCC.Text));
                
                message.Subject = tbSubject.Text;
                toReplace.Add(addMessageFrom(message, tbFrom.Text));
                
                if (!string.IsNullOrWhiteSpace(m_TextContent))
                {
                    message.Body = m_TextContent.Replace("\r\n", "\n");
                    message.BodyEncoding = m_textBodyEncoding??Encoding.UTF8;
                    message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.EightBit;
                    message.IsBodyHtml = false;
                }
                else
                {
                    message.Body = m_HtmlContent;
                    message.BodyEncoding = m_htmlBodyEncoding ?? Encoding.UTF8;
                    message.BodyTransferEncoding = System.Net.Mime.TransferEncoding.EightBit;
                    message.IsBodyHtml = true;
                }

                if (!string.IsNullOrWhiteSpace(m_TextContent) && !string.IsNullOrWhiteSpace(m_HtmlContent))
                {
                    var mimeType = new System.Net.Mime.ContentType("text/html");
                    // Add the alternate body to the message.

                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(m_HtmlContent, mimeType);
                    alternate.TransferEncoding = System.Net.Mime.TransferEncoding.EightBit;
                    m_htmlBodyEncoding = m_htmlBodyEncoding ?? Encoding.UTF8;
                    alternate.ContentType.CharSet = m_htmlBodyEncoding.BodyName;
                    message.AlternateViews.Add(alternate);
                }

                foreach (EmlAttachment attachment in lbAttachments.Items)
                {
                    var ms = new MemoryStream(attachment.Data);
                    ms.Seek(0, SeekOrigin.Begin);
                    Attachment dataAtt = new Attachment(ms, attachment.Name, attachment.MimeType);
                    message.Attachments.Add(dataAtt);
                }
                using (var client = new SmtpClient())
                {
                    client.UseDefaultCredentials = true;
                    client.DeliveryMethod =
                       SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    client.PickupDirectoryLocation = Path.GetDirectoryName(tbEmlPath.Text);
                    client.Send(message);
                }
                var defaultMsgPath = new
               DirectoryInfo(Path.GetDirectoryName(tbEmlPath.Text)).GetFiles()
                  .OrderByDescending(f => f.LastWriteTime)
                  .First();
                var realMsgPath = tbEmlPath.Text;

                if (File.Exists(realMsgPath)) File.Delete(realMsgPath);
                File.Move(defaultMsgPath.FullName, realMsgPath);

                String data = File.ReadAllText(realMsgPath);
                foreach(var tup in toReplace)
                {
                    if (tup != null)
                    {
                        data = data.Replace(tup.Item1, tup.Item2);
                    }
                }
                File.WriteAllText(realMsgPath,data);


                Console.WriteLine("Message saved.");
            }
        }



        private Tuple<String, String> addMessageFrom(MailMessage mail, string text)
        {
            try
            {
                mail.From = buildAddress(text);
                return null;
            }
            catch (Exception)
            {
                var fakeEmail = Guid.NewGuid().ToString() + "@test.com";
                mail.From = buildAddress(fakeEmail);
                return new Tuple<String, String>(fakeEmail, text);
            }
        }

        private Tuple<String, String> addMessageEmails(MailAddressCollection addresses, string text)
        {
            try
            {
                addresses.Add(text);
                return null;
            }
            catch(Exception )
            {
                var fakeEmail = Guid.NewGuid().ToString() + "@test.com";
                addresses.Add(fakeEmail);
               return new Tuple<String, String>(fakeEmail, text);
            }
        }

        private MailAddress buildAddress(string text)
        {
            if (text.EndsWith(">"))
            {
                var data = text.Split('<');
                return new MailAddress(data[1].TrimEnd('>'), data[0]);
            }
            return new MailAddress(text);
        }

        Nullable<Boolean> isTextLoaded = null;
        private void btLoadHtml_Click(object sender, EventArgs e)
        {
            isTextLoaded = false;
            wbHtml.Navigate("about:blank");
            if (wbHtml.Document != null)
            {
                wbHtml.Document.Write(string.Empty);
            }
            wbHtml.DocumentText = m_HtmlContent;
            wbHtml.Show();
            wbText.Hide();
            tbContent.Text = m_HtmlContent;//.Replace("\n", "\r\n");
            btLoadText.Enabled = true;
            btLoadHtml.Enabled = false;
        }

        private void btLoadText_Click(object sender, EventArgs e)
        {
            isTextLoaded = true;
            wbHtml.Hide();
            wbText.Text = m_TextContent;
            wbText.Show();
            tbContent.Text = m_TextContent;//.Replace("\n", "\r\n");
            btLoadText.Enabled = false;
            btLoadHtml.Enabled = true;
        }

        private void btTestHtml_Click(object sender, EventArgs e)
        {
            if (isTextLoaded == null)
            {
                m_TextContent = tbContent.Text;
                isTextLoaded =true;
            }
            if (isTextLoaded.Value)
            {
                var tmp = tbContent.Text;//.Replace("\r\n", "\n");
                m_TextContent = tmp;
                btLoadText_Click(null, null);
            }
            else
            {
                var tmp = tbContent.Text;//.Replace("\r\n", "\n");
                m_HtmlContent = tmp;
                btLoadHtml_Click(null, null);
            }
        }

        private void btAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Find Files";
            fileDialog.Filter = "All files (*.*)|*.*";
            fileDialog.ShowDialog();
            if (!String.IsNullOrWhiteSpace(fileDialog.FileName))
            {
                string mimeType = System.Web.MimeMapping.GetMimeMapping(fileDialog.FileName);
                AttachDialog dialog = new AttachDialog();
                dialog.FileName = Path.GetFileName(fileDialog.FileName);
                dialog.Mime = System.Web.MimeMapping.GetMimeMapping(fileDialog.FileName);
                dialog.ShowDialog();
                if (dialog.IsOk)
                {

                    var data = File.ReadAllBytes(fileDialog.FileName);

                    EmlAttachment attach = new EmlAttachment()
                    {
                        Data = data,
                        MimeType = dialog.Mime,
                        Name = dialog.FileName
                    };
                    lbAttachments.Items.Add(attach);
                }
            }
        }

        private void btDetach_Click(object sender, EventArgs e)
        {
            if (lbAttachments.Items.Count == 0) return;
            if (lbAttachments.SelectedIndex >= 0)
            {
                lbAttachments.Items.RemoveAt(lbAttachments.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No attachment selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string replace(String v, int i)
        {
            String src = "";
            src += (char)i;
            return v.Replace(src, "&#" + i.ToString() + ";");
        }
        private string diacritic(string v)
        {
            return v;
            v = replace(v, 161);
            for (int i = 191; i < 194; i++)
            {
                // v = replace(v, i);
            }

            for (int i = 195; i < 255; i++)
            {
                v = replace(v, i);
            }
            return v;
        }

        private int m_currentSelection = 0;
        private List<int> m_selections = new List<int>();
        private void btFind_Click(object sender, EventArgs e)
        {
            m_selections = new List<int>();
            int start = 0;
            int end = tbContent.Text.Length;
            String txtToSearch = tbFind.Text.Trim();
            if (txtToSearch.Length == 0)
            {
                tbContent.DeselectAll();
                return;
            }
            while (start >= 0 && start < tbContent.Text.Length)
            {
                start = tbContent.Find(txtToSearch, start, end, RichTextBoxFinds.None);
                if (start >= 0)
                {
                    tbContent.SelectionBackColor = Color.Red;
                    tbContent.Select(start, txtToSearch.Length);
                    m_selections.Add(start);
                    start += txtToSearch.Length;
                }
            }
        }

        private void setContentPos(int ptrChar)
        {
            tbContent.Select(ptrChar, 0);
            tbContent.ScrollToCaret();
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            if (m_selections.Count == 0) return;
            if(m_currentSelection == 0)
            {
                m_currentSelection = m_selections.Count - 1;
            }
            else
            {
                m_currentSelection--;
            }
            setContentPos(m_selections[m_currentSelection]);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (m_selections.Count == 0) return;
            if (m_currentSelection == (m_selections.Count - 1))
            {
                m_currentSelection = 0;
            }
            else
            {
                m_currentSelection++;
            }
            setContentPos(m_selections[m_currentSelection]);
        }

        private void btClean_Click(object sender, EventArgs e)
        {
            m_currentSelection = 0;
            m_selections = new List<int>();
            tbFind.Text = "";
            tbContent.SelectAll();
            tbContent.SelectionBackColor = Color.Transparent;
            tbContent.DeselectAll();
        }

        private void btReplace_Click(object sender, EventArgs e)
        {
            ReplaceDialog replace = new ReplaceDialog(tbContent,tbContent.SelectedText);
            replace.ShowDialog();
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            String help = "Can load *.msg or *.eml files\n" +
                "The Load Text and Load Html buttons loads the current text or html content\n" +
                "With the Apply button the content is stored in the current eml but not saved and shown into the preview box\n" +
                "Find will highlight the founded items and can move between them with Prev/Next\n" +
                "Replace will do a simple search and replace case sensitive on the editor box. You should then click apply to store changes" +
                "The SaveEml will save the new Eml files" +
                "The codepage will be set by default to UTF8 when missing when the Force UTF8 checkbox is selected\n"+
                "THe codepage will be UTF8 when not loading any template\n"+
                "When setting the email fields to not valid emails they will be saved AS IS";
            MessageBox.Show(help, "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void lbAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDetach.Enabled = lbAttachments.SelectedIndex >= 0;
        }
    }
}
