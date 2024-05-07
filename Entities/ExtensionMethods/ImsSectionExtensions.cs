using Entities.Models.SE;
using Entities.ViewModels.SE;

namespace Entities.ExtensionMethods
{
    public static class ImsSectionExtensions
    {
        public static ImsSectionGeneralVM ToImsSectioGeneralVM(this ImsSection entity)
        {
            return new ImsSectionGeneralVM
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
