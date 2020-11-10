namespace SSS.DataAccess
{
    class Constants
    {
        public static string CheckIfUserExistQuery { get; private set; } = "select Id,Name,Email,BirthDate,PassWord  from Customers c where lower(c.Email) = '{0}' and c.PassWord = '{1}'";
        public static string CheckIfUserExistByEmailQuery { get; private set; } = "select Id,Name,Email,BirthDate,PassWord  from Customers c where lower(c.Email) = '{0}'";

        public static string GetProductByNameLikeQuery { get; private set; } = "  select * from Products c where lower(c.Name) like '%{0}%'";

    }
}
