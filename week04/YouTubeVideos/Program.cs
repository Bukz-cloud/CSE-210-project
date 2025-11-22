using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> allVideos = new List<Video>();
        
        Video firstVideo = new Video("Global Visibility", "James Sandra", 7.00f);
        firstVideo.AddComment(new Comment("Alice", "Great explanation!"));
        firstVideo.AddComment(new Comment("John", "Very Insightful!"));
        firstVideo.AddComment(new Comment("Bob", "Very helpful, thanks."));
        firstVideo.AddComment(new Comment("Charlie", "Can you make a video on OOP next?"));
        allVideos.Add(firstVideo);

        Video secondVideo = new Video("Object Oriented Programming", "Julius Caesar", 17.50f);
        secondVideo.AddComment(new Comment("Wang", "This is an eye opener!"));
        secondVideo.AddComment(new Comment("Drake", "I can watch this over and over again!"));
        secondVideo.AddComment(new Comment("Tayo", "Very helpful, thanks."));
        secondVideo.AddComment(new Comment("Dark Man", "I have always loved this channel."));
        allVideos.Add(secondVideo);

        Video thirdVideo = new Video("Life-Long Learning", "Donald Trump", 20.00f);
        thirdVideo.AddComment(new Comment("Mary", "I am glad I stumbled upon this video!"));
        thirdVideo.AddComment(new Comment("Leke", "What an insight!"));
        thirdVideo.AddComment(new Comment("Kumalo", "Very helpful, thanks."));
        thirdVideo.AddComment(new Comment("Charles", "This is worth watching."));
        allVideos.Add(thirdVideo);

        foreach (Video video in allVideos)
        {
            video.DIsplayVideoDetails();
        }
    }
}