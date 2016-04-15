using Parliament.JargonBuster.BackEndAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parliament.JargonBuster.BackEndAdminApp.Models
{
    public class DefinitionsViewModel
    {
        public IEnumerable<DefinitionViewModel> Definitions { get; set; }
    }
}
