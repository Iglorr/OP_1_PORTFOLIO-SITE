namespace CoreApi.Domain
{
    public class Blogpost
    {
        public int Id {get; set; }
        public string BlogName {get; set; } = string.Empty;
        public string BlogText {get; set; }  = string.Empty;
        public string SourceUrl {get; set; }  = string.Empty;
        public DateTime Datumnaangemaakt {get; set; }
        public string BronnenJson {get; set; } = "[]";
    }
}