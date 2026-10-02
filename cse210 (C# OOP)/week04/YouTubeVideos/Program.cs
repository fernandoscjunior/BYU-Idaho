using System;

class Program
{
    static void Main(string[] args)
    {
        //Comment comment = new Comment();
        //comment._user = "LittleJohn1442";
        //comment._commentContent = "lorem ipsulum dolor set amet...";

        Comment comment1 = new Comment();
        comment1._user = "Charlie Brown";
        comment1._commentContent = "Where is Snoopy? Good grief!";

        Comment comment2 = new Comment();
        comment2._user = "Sally Brown";
        comment2._commentContent = "Why do we have to watch thisin school? I bet Abraham Lincoln didn't watch this video when he was at school.";

        Comment comment3 = new Comment();
        comment3._user = "Lucy van Pelt";
        comment3._commentContent = "Who gave Charlie Brown an iPhone? Now I'll have double the amount of work..";

        Comment comment4 = new Comment();
        comment4._user = "Snoopy";
        comment4._commentContent = "'Finally I can express my deepest thoughts somewhere. I like cookies too'";

        Comment comment5 = new Comment();
        comment5._user = "Wood Stock";
        comment5._commentContent = "///| || // ||//| |// ?";

        Comment comment6 = new Comment();
        comment6._user = "Schroeder";
        comment6._commentContent = "Like the video but the music is kinda meh, why don't you try Beethoven next time?";

        Comment comment7 = new Comment();
        comment7._user = "Peppermint Patty (aka the best sportist in town)";
        comment7._commentContent = "Nice tricks!";

        Comment comment8 = new Comment();
        comment8._user = "Marcy";
        comment8._commentContent = "According to the law 20.0305/2003 it is illegal to hack a company like NASA.";

        Comment comment9 = new Comment();
        comment9._user = "Myself";
        comment9._commentContent = "Honestly I can't think of new Peanuts references.";

        Video video = new Video();
        video._author = "Testson";
        video._length = 120;
        video._title = "How to write a C# program";
        video._comments.Add(comment3);
        video._comments.Add(comment1);
        video._comments.Add(comment2);
        //video.ReturnComments();

        Video video1 = new Video();
        video1._author = "Chuck Norris";
        video1._length = 360;
        video1._title = "How I hacked NASA:";
        video1._comments.Add(comment5);
        video1._comments.Add(comment7);
        video1._comments.Add(comment8);

        Video video2 = new Video();
        video2._author = "deadmau5";
        video2._length = 486;
        video2._title = "A City in Florida";
        video2._comments.Add(comment9);
        video2._comments.Add(comment4);
        video2._comments.Add(comment6);

        List<Video> videos = new List<Video>();
        videos.Add(video);
        videos.Add(video1);
        videos.Add(video2);

        foreach (Video content in videos)
        {
            Console.WriteLine(content._author);
            Console.WriteLine(content._title);
            Console.WriteLine(content._length);
            video.ReturnComments();

            foreach (Comment c in content._comments)
            {
                Console.WriteLine(c._user);
                Console.WriteLine(c._commentContent + "\n");
            }
        }
    }
}