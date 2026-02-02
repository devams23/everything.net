
// File created on 2026-02-1
namespace Day4_OOP.SOCIAL_MEDIA_APP
{
    class MainSocialMediaAppProgram
    {
        static void Main(string[] args)
        {


                // DIP: Choosing the data storage at runtime
                IDataStore database = new SqlDatabase();
                FeedManager feed = new FeedManager(database);

            /*
             OCP/LSP: Handling different post types in one list,
             because they all inherit from BasePost, and so we can use the Display() method 
            for each Post.
            */
            List<BasePost> userFeed = new List<BasePost>
                {
                    new ImagePost(new Post { Id = 1, Author = "User1", Content = "Image Post Content" }),
                    new VideoPost(new Post { Id = 2, Author = "User2", Content = "Video Post Content" }),
                    new SponsoredPost(new Post { Id = 3, Author = "User_SPONSORED3", Content = "Sponsored Post Content" })
                };
                
                foreach (var post in userFeed)
                {
                    post.Display(); // Runtime Polmorphism
                }

                feed.Publish("User Post !");
            }

    }
}
