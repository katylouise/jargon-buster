using Parliament.JargonBuster.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminApp.ViewModels
{
    public class DefinitionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A definition phrase is required")]
        public string Phrase { get; set; }
        [Required(ErrorMessage = "A definition meaning is required")]
        public string Definition { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public HouseType House { get; set; }
        public List<AlternateItemViewModel> Alternates { get; set; }

    }
}