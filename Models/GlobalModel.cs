namespace Models
{
    public class ParamsModel
    {
        public static string DBCon { get; set; }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }

}