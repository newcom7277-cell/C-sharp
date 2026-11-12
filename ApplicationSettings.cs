// A plain class that holds our settings. It is like a struct in C++
// or an interface in TypeScript. It has no logic, only data.
public class ApplicationSettings
{
    // Box for the text value "ApplicationName" from appsettings.json
    // { get; set; } = we can read it and ASP.NET can write into it
    // = "" means start with empty text instead of null
    public string ApplicationName { get; set; } = "";

    // Box for the number value "PingInterval" from appsettings.json
    // int = whole number, so 30 in JSON becomes the number 30
    public int PingInterval { get; set; }
}