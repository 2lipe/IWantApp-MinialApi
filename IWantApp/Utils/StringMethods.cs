namespace IWantApp.Utils;

public static class StringMethods
{
    public static string TransformEmailInUserName(this string email)
    {
        return email.Split("@").FirstOrDefault()!.Replace(".", "-");
    }
}