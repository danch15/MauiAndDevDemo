namespace MauiAndDevDemo;

public class User
{
    public string UserID { get; set; }
    public string UserNumber { get; set; }
    public string UserName { get; set; }

    public override string ToString()
    {
        return $"{UserID},{UserNumber},{UserName}";
    }
}