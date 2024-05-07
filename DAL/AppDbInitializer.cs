//using Microsoft.AspNetCore.Builder;

namespace DAL
{
    public class AppDbInitializer
    {
        //public static void Seed(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        if (!context.Books.Any())
        //        {
        //            context.Books.AddRange(new PR_Role()
        //            {
        //                Title = "1st book title",
        //                Description = "1st book Description",
        //                IsRead = true,
        //                DateRead = DateTime.Now.AddDays(-10),
        //                Rate = 4,
        //                Genre = "Biography",
        //                Author = "1st Author",
        //                CoverUrl = "https...",
        //                DateAdded = DateTime.Now
        //            },
        //            new PR_Role()
        //            {
        //                Title = "2nd book title",
        //                Description = "2nd book Description",
        //                //IsRead = false,
        //                //DateRead = DateTime.Now.AddDays(-10),
        //                Rate = 4,
        //                Genre = "Biography",
        //                Author = "2nd Author",
        //                CoverUrl = "https...",
        //                DateAdded = DateTime.Now
        //            });

        //            context.SaveChanges();
        //        }
        //    }
        //}
    }
}
