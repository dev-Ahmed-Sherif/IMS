using Microsoft.AspNetCore.Http;

namespace Entities.ViewModels.STR.Product
{
    public class StrProductGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string Attachment { get; set; }
        //public IFormFile FilePath { get; set; }
        public IFormFile File { get; set; }
        public int ItemId { get; set; }
        public int VendorId { get; set; }
        public int ModelId { get; set; }
        public int? TransactionUserId { get; set; }

    }
    public class StrProductVM : StrProductGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrProductGetVM : StrProductVM
    {

        public string VendorName { get; set; }
        public string ModelName { get; set; }
        public string ItemName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
