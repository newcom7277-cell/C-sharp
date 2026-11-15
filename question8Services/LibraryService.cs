// the coordinator . it needs all three helper 
public class LibraryService
{    

    // one private variable per helper
    private readonly BookService _bookService;
    private readonly MemberService _memberService;
    private readonly NotificationService _notificationService;


    // construcotr inject ll three service 
    // th cntiner create the three helper and passes them in 
    public LibraryService(BookService b,MemberService m,NotificationService n)
    {
        _bookService=b;
        _memberService=m;
        _notificationService=n;
    }

    public void BorrowBook(String b,string m)
    {
        Console.WriteLine("Checking Book Availablity...");
        if (!_bookService.BookExists(b))
        {
            Console.WriteLine("Book Not Found!");
            return; // stop here, nothing else runs
            
        }
         Console.WriteLine("Book Found!");

          Console.WriteLine("Checking Member...");
          if (!_memberService.MemberExists(m))
        {
            Console.WriteLine("Member Not Found!");
            return; // stop here
        }
        Console.WriteLine("Member Found!");

        // Step 3: both exist, so confirm and notify
        Console.WriteLine("Book Borrowed Successfully!");
        _notificationService.Notify("Your book has been borrowed.");

    }

}