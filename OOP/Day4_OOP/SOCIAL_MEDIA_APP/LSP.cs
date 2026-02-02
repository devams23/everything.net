
// File created on 2026-02-1
/*  
    Interface Segregation Principle (ISP)----------------------------------
    Concept: Subtypes must be substitutable for their base types.
       If we have a "Sponsored Post" (Ad), it should still function like a 
       regular post without crashing the feed."
*/
namespace Day4_OOP.SOCIAL_MEDIA_APP
{
    public class SponsoredPost : BasePost
    {
        public SponsoredPost(Post post) : base(post) { }
        public override void Display()
        {
            Console.WriteLine("Displaying an Ad... [Sponsored Content]");
        }
    }
     
}
