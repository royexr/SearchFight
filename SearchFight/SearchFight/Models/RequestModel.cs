using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Models
{
    public class RequestModel
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }
}
