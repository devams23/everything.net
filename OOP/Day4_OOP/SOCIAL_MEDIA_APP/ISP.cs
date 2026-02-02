// File created on 2026-02-1
/*
 * Interface Segregation Principle (ISP)----------------------------------
    Don't force a class to implement methods it doesn't need. 
    Not all posts are "likeable" (e.g., an announcement post might disable likes) 
    and not all are "shareable."
*/


namespace Day4_OOP.SOCIAL_MEDIA_APP
{
    public interface ILikeable
    {
        void Like();
    }

    public interface IShareable
    {
        void Share();
    }

    // A standard user post can be both liked and shared
    public class DisableLikesPost : BasePost, IShareable 
    {
        public DisableLikesPost(Post post) : base(post) { }
        
        public override void Display() => Console.WriteLine("Standard User Post.");
        //public void Like() => Console.WriteLine("Post Liked!");
        public void Share() => Console.WriteLine("Post Shared!");
    }
}
