
// File created on 2026-02-1
/*  
    Open/Closed Principle (OCP)----------------------------------
    Concept: Open for extension, closed for modification.
    Instead of using a switch statement to handle different post types (Image, Video, Text), we use an abstract base class.   
*/


namespace Day4_OOP.SOCIAL_MEDIA_APP
{
    public abstract class BasePost : Post
    {
        public BasePost(Post post)
        {
            Id = post.Id;
            Author = post.Author;
            Content = post.Content;
        }
        public abstract void Display();
    }

    public class ImagePost : BasePost
    {

        public ImagePost(Post post) : base(post) { }
        public override void Display() 
        { 
             Console.WriteLine("Displaying an Image Post.");
            Console.WriteLine(Content);
        }
    }

    public class VideoPost : BasePost
    {
        public VideoPost(Post post) : base(post) { }
        public override void Display() 
        { 
            Console.WriteLine("Streaming a Video Post."); 
            Console.WriteLine("video content: " + Content);
        }
    }
}
