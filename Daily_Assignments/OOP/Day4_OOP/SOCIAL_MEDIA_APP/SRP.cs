
// date - 2026-02-1
/*
 * Single Responsibility Principle (SRP) ----------------------------------
 * --A class should do one thing. We separate the Post (data), 
    the PostFormatter (UI logic), and the PostRepository (Storage logic).
 */

namespace Day4_OOP.SOCIAL_MEDIA_APP
{
    public class Post
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
    }

    // handles only how a post is comperessed/formatted
    public class PostCompressor
    {
        public string CompressToFormat(Post post) {
            return $"{post.Author}{post.Content}";
        }
    }

    // handles only how a post is saved, (CRUD operations)
    public class PostRepository
    {
        public void Save(Post post)
        {
            Console.WriteLine("Post saved to database.");
        }
    }
}
