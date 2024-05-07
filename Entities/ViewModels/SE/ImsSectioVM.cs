using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.SE
{
    public class ImsSectionVM
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
    public class ImsSectionGeneralVM : ImsSectionVM
    {
        public int Id { get; set; }

    }
}
