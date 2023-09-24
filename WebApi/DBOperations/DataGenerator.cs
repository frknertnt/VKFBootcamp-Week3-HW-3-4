using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,                        
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 02, 06)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Herland",
                        GenreId = 2,                       
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 03, 12)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2011, 12, 12)
                    });
                context.SaveChanges();
            }
        }
    }
}
