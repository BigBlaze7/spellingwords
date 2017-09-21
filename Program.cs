using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApp.SQLite
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new BloggingContext())
            {
                foreach (var spellList in db.SpellingLists)
                {
        
              
                    Console.WriteLine(spellList.Name);

                    var words = db.SpellingWords.Where(p => p.SpellingListID == spellList.SpellingListID).ToList();
                    foreach (var word in words)
                    {
                        Console.WriteLine(word.Word);
                        
                    }


                }

                /* *

                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
                */
            }
        }
    }
}