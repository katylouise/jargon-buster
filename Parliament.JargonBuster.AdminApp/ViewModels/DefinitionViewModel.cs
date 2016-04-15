using System.Collections.Generic;

namespace Parliament.JargonBuster.AdminApp.Models
{
    public class DefinitionViewModel
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
        public string Definition { get; set; }
        public List<AlternateDefinitionViewModel> Alternates { get; set; }
    }
}