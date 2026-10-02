// Each video also has responsibility to store a list of comments, and should have a method to return the number of comments.
class Video
{
    public string _title;
    public string _author;
    public double _length;
    public List<Comment> _comments = new List<Comment>();

    public Video()
    {    
    }
    public void ReturnComments()
    {
        int list_size = _comments.Count();
        Console.WriteLine(list_size);
    }
}