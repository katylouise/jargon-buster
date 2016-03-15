using Parliament.JargonBuster.WebAPI.Models;

namespace Parliament.JargonBuster.WebAPI.ViewModelBuilders
{
    public interface IDefinitionsResultViewModelBuilder
    {
        DefinitionsResultModel Build(DefinitionsRequestModel requestModel);
    }
}
