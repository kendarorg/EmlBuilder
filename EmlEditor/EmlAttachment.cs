
using MsgReader.Mime;
using MsgReader.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmlEditor
{
    public class EmlAttachment
    {
        public EmlAttachment() { }
        public EmlAttachment(Storage.Attachment attachment)
        {
            Name = attachment.FileName;
            MimeType = attachment.GetMapiProperty("370E")!=null? attachment.GetMapiProperty("370E").ToString():"application/octet-stream";
            Data = attachment.Data;


        }

        public EmlAttachment(MessagePart attachment)
        {

            Name = attachment.FileName;
            MimeType = attachment.ContentType!=null && attachment.ContentType.MediaType!=null?attachment.ContentType.MediaType: "application/octet-stream";
            Data = attachment.Body;
        }

        public string Name { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
    }
}
