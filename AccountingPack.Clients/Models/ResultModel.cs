using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPack.Models
{
    public class ResultModel
    {
        public bool Success { get; set; }

        public string View { get; set; }

        public string Redirect { get; set; }
    }
}
