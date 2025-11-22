using System;

public class Video
{
    public string _title;
    public string _author;
    public float _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, float length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetComment()
    {
        return _comments.Count;
    }

    public void DIsplayVideoDetails()
    {
        Console.WriteLine($"Video title: {_title}");
        Console.WriteLine($"Video author: {_author}");
        Console.WriteLine($"Video length: {Math.Round(_length, 2)} min");
        Console.WriteLine($"Video comments: {GetComment}");

        foreach (Comment com in _comments)
        {
            com.DisplayComment();
        }
    }
}

