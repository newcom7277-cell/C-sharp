public class BookService
{
    private readonly List<string> _books=new List<string>
    {
        "C# Basics",
        "Asp.Net Core Guide",
        "Data Structure"
    };
    //  return true if the book is in list ,false if  not

    public bool BookExists(string title)
    {
        return _books.Contains(title);
    }
}