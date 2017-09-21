using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp.SQLite
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<SpellingList> SpellingLists { get; set; }
        public DbSet<SpellingTest> SpellingTests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SpellingWord> SpellingWords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging3.db");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class SpellingList
    {
        public int SpellingListID { get; set; }
        public string Name { get; set; }

    }

    //made a change
    public class SpellingWord
    {
        public int SpellingWordID { get; set; }
        public string Word { get; set; }
        public int SpellingListID { get; set; }

    }

    public class SpellingTest
    {
        public int SpellingTestID { get; set; }
        public string User { get; set; }
        public int SpellingListID { get; set; }
        public int Grade { get; set; }
    }



    public class Answer
    {
        public int AnswerID { get; set; }
        public string Word { get; set; }
        public int SpellingTestID { get; set; }
        public int SpellingWordID { get; set; }
        public bool Correct { get; set; }
    }









































}