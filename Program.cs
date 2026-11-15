var builder = WebApplication.CreateBuilder(args);


//  register all four service (write the menu)

builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<MemberService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<LibraryService>();


var app = builder.Build();


// ask the container for libraryService
//it create the three helper first ,then librarySErvice with them inside
var l=app.Services.GetRequiredService<LibraryService>();
//  Test 1: book and member both exist
Console.WriteLine("--- Test 1: success ---");
l.BorrowBook("C# Basics", "Rahul");

// Test 2: book is missing
Console.WriteLine("--- Test 2: book missing ---");
l.BorrowBook("Harry Potter", "Rahul");

// Test 3: member is missing
Console.WriteLine("--- Test 3: member missing ---");
l.BorrowBook("C# Basics", "Unknown");

app.Run();