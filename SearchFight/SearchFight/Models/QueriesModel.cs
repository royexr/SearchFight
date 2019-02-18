using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Models
{
    public class QueriesModel
    {
        public List<RequestModel> request { get; set; }
        public List<RequestModel> nextPage { get; set; }
    }
}
