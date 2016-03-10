using System.ComponentModel.DataAnnotations;

namespace Parliament.JargonBuster.Core.Domain
{
    public class AlternateDefinitionItem
    {
        [Key]
        public int Id { get; set; }
        public string AlternateDefinition { get; set; }
    }
}
