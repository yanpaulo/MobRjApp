using System.Collections.Generic;
using System.Linq;

namespace MobRjApp.Data
{
    public class Fields
    {
        public string Sigla { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string Estado { get; set; }
        public string Capital { get; set; }
        public string Regiao { get; set; }

        public string ThumbnailUrl => Attachments.FirstOrDefault()?.Thumbnails.Large.Url;
    }
}