using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parliament.JargonBuster.WebAPI.Models
{
    public class DefinitionsResultItemModel
    {
        public string Definition { get; set; }
        public string Phrase { get; set; }
        public List<string> Alternates { get; set; }
        public bool DisplayAlternates { get; set; }
        public string AlternatesContent { get; set; }
    }
}