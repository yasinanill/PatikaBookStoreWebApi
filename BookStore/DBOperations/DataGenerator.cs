using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DBOperations
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
                     //   Id = 1,
                        Title = "Title",
                        Author = "Author",
                        Description = "Description",
                        Name = "Name",

                        PublishDate = new DateTime(2001, 06, 29)

                    },
                new Book
                {
                  //  Id = 3,
                    Title = "Harland",
                    Author = "Anil",
                    Description = "Description",
                    Name = "Name",

                    PublishDate = new DateTime(2001, 04, 29)

                },

             new Book
             {
               //  Id = 4,
                 Title = "Harland",
                 Author = "Anil",
                 Description = "Description",
                 Name = "Name",

                 PublishDate = new DateTime(2021, 06, 29)

             }

             );
       
                context.SaveChanges();
            
            }

    }

}
}
