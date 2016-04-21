using Parliament.JargonBuster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.ViewModels
{
    public class DefinitionViewModel
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
        public string Definition { get; set; }
        public List<AlternateItemViewModel> Alternates { get; set; }

    }
}