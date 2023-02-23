﻿using BookStore.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions <BookStoreDbContext> options) : base(options) {
        
        
        }
        public DbSet<Book> Books { get; set;} 
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
