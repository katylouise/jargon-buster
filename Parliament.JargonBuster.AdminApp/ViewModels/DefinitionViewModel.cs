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
        [Display(Name = "Phrase")]
        public string Phrase { get; set; }

        [Required(ErrorMessage = "A definition meaning is required")]
        [Display(Name = "Definition")]
        public string Definition { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string House { get; set; }

        [Display(Name = "Alternate Phrases")]
        public List<AlternateItemViewModel> Alternates { get; set; }

    }
}