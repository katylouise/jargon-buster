using AdminApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public interface IAdminDefinitionsService
    {
        void UpdateDefinitionViewModel(DefinitionViewModel definitionViewModel);
        void AddDefinitionViewModel(DefinitionViewModel definitionViewModel);
    }
}
