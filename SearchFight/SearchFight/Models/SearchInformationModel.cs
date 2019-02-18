using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Models
{
    public class SearchInformationModel
    {
        public double searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }
}
