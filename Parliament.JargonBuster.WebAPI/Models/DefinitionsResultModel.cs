using System.Collections.Generic;

namespace Parliament.JargonBuster.WebAPI.Models
{
    public class DefinitionsResultModel
    {
        public List<DefinitionsResultItemModel> Phrases { get; set; }
        
        public string ToggleDefinitionHtml { get; set; }
    }
}