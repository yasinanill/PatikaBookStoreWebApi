using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public DateTime PublishDate
        {
            get; set;
        }
    }
}
