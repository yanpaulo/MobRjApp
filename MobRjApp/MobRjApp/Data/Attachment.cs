namespace MobRjApp.Data
{
    public class Attachment
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Filename { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public Thumbnails Thumbnails { get; set; }
    }
}