using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Models
{
    public class SearchResultsModel
    {
        public string word { get; set; }
        public long GoogleResults { get; set; }
        public long? BingResults { get; set; }
    }
}
