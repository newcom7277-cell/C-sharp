public class MemberService
{
    private readonly List<string> _members=new List<string>
    {
        "Rahul",
        "Amit",
        "Priya"
    };
    public bool MemberExists(string name)
    {
        return _members.Contains(name);
    }
}