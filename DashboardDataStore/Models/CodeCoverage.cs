using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildStatisticsServices.Models
{
    [Serializable]
    public class CodeCoverage
    {
        public int TotalStatements { get; set; }

        public int CoveredStatements { get; set; }
    }
}