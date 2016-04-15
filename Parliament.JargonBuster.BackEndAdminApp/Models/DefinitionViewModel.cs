using System.Collections.Generic;

namespace Parliament.JargonBuster.BackEndAdminApp.Models
{
    public class DefinitionViewModel
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
        public string Definition { get; set; }
        public List<AlternateDefinitionViewModel> Alternates { get; set; }
    }
}