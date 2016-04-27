using AdminApp.ViewModels;
using Parliament.JargonBuster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.ViewModelBuilders
{
    public interface IAlternateItemsViewModelBuilder
    {
        List<AlternateItemViewModel> Build(DefinitionItem defintionItem);
    }
}
