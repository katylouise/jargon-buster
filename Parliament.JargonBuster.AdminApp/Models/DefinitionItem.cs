using System.Collections.Generic;

namespace Parliament.JargonBuster.AdminApp.Models
{
    public class DefinitionItem
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
        public string Definition { get; set; }
        public List<AlternateDefinitionItem> Alternates { get; set; }
    }
}