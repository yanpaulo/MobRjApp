using System;
using System.Collections.Generic;
using System.Linq;

namespace MobRjApp.Data
{
    public class Thumbnail
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Thumbnails
    {
        public Thumbnail Small { get; set; }
        public Thumbnail Large { get; set; }
        public Thumbnail Full { get; set; }
    }

    public class Attachment
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Filename { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public Thumbnails Thumbnails { get; set; }
    }

    public class Fields
    {
        public string Id { get; set; }
        public string Sigla { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string Estado { get; set; }
        public string Capital { get; set; }
        public string Regiao { get; set; }

        public string ThumbnailUrl => Attachments.FirstOrDefault()?.Thumbnails.Large.Url;
    }

    public class State
    {
        public string Id { get; set; }
        public Fields Fields { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}