using SearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.DTOs
{
    public class DTOBingResult
    {
        public string kind { get; set; }
        public UrlModel url { get; set; }
        public QueriesModel queries { get; set; }
        public ContextModel context { get; set; }
        public SearchInformationModel searchInformation { get; set; }
        public List<ItemModel> items { get; set; }
    }
}
