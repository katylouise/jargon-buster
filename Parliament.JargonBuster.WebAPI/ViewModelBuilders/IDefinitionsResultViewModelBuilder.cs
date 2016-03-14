using Parliament.JargonBuster.Core.Domain;
using Parliament.JargonBuster.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parliament.JargonBuster.WebAPI.ViewModelBuilders
{
    public interface IDefinitionsResultViewModelBuilder
    {
        List<DefinitionsResultModel> Build(DefinitionsRequestModel requestModel);
    }
}
