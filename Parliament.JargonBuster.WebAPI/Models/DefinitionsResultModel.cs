using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parliament.JargonBuster.WebAPI.Models
{
    public class DefinitionsResultModel
    {
        public string Definition { get; set; }
        public string Phrase { get; set; }
        public string Alternates { get; set; }
        public bool DisplayAlternates { get; set; }
    }
}