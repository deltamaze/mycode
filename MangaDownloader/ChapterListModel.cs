using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader
{
    public class Attributes
    {
        public string volume { get; set; }
        public string chapter { get; set; }
        public string title { get; set; }
        public string translatedLanguage { get; set; }
        public object externalUrl { get; set; }
        public DateTime publishAt { get; set; }
        public DateTime readableAt { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int pages { get; set; }
        public int version { get; set; }
    }

    public class Relationship
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
        public IList<Relationship> relationships { get; set; }
    }

    public class ChapterListModel
    {
        public string result { get; set; }
        public string response { get; set; }
        public IList<Datum> data { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
    }
}
