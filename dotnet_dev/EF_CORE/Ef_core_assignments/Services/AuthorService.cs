using EF_CORE.DAY_1.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.Services
{
    internal class AuthorService
    {
        public readonly AppDbContext _appDbContext;
        public AuthorService(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public void GetAuthorBooks()
        {

            var author_books = _appDbContext.Authors.First();


            foreach (var book in author_books.Books)
            {
                Console.WriteLine(book.Title);
            }
            //foreach (var author in author_books)
            //{
            //    Console.WriteLine(author.FirstName);

            //    //Console.WriteLine("iff books"+author?.Books);

            //    foreach(var book in author.Books)
            //    {
            //        Console.WriteLine(book.Title);
            //    }
            //}
        }

    }

}
