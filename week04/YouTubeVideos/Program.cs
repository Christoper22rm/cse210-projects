using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }
    
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Duration { get; set; }
    private List<Comment> comments = new List<Comment>();
    
    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
    }
    
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }
    
    public int GetCommentCount()
    {
        return comments.Count;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Duration: {Duration} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($" - {comment.Name}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        
        Video video1 = new Video("Learning C#", "John Perez", 600);
        video1.AddComment(new Comment("Anna", "Very useful, thanks!"));
        video1.AddComment(new Comment("Charles", "Excellent explanation."));
        video1.AddComment(new Comment("Martha", "It helped me a lot."));
        videos.Add(video1);
        
        Video video2 = new Video("Introduction to Programming", "Luis Gomez", 900);
        video2.AddComment(new Comment("Peter", "Very clear and concise."));
        video2.AddComment(new Comment("Sophia", "Thanks for sharing."));
        video2.AddComment(new Comment("Diego", "I would like to see more content."));
        videos.Add(video2);
        
        Video video3 = new Video("Python Tutorial", "Maria Lopez", 750);
        video3.AddComment(new Comment("Laura", "I loved it!"));
        video3.AddComment(new Comment("Robert", "Excellent explanation."));
        video3.AddComment(new Comment("Helen", "I will keep practicing."));
        videos.Add(video3);
        
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}