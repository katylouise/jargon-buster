using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parliament.JargonBuster.Core.Domain
{
    public class DefinitionItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Definition { get; set; }
        public string Phrase { get; set; }
        public List<AlternateDefinitionItem> Alternates { get; set; } 
    }
}
