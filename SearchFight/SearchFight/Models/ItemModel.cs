using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Models
{
    public class ItemModel
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string htmlTitle { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        public string snippet { get; set; }
        public string htmlsnippet { get; set; }
        public string cacheId { get; set; }
        public string mime { get; set; }
        public string fileFormat { get; set; }
        public string formattedUrl { get; set; }
        public string htmlFormattedUrl { get; set; }
        public PageMapModel pagemap { get; set; }
        public List<LabelModel> labels { get; set; }
    }
}
