using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Models
{
    public class ContextModel
    {
        public string title { get; set; }
        public List<List<FacetModel>> facets { get; set; }
    }
}
