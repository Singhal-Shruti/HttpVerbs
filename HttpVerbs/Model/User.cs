namespace HttpVerbs
{
    public class User
    {
        public string UserName
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public string UserEmail
        {
            get;
            set;
        }
        public User(int Id, string Name, string Email)
        {
            UserId = Id;
            UserName = Name;
            UserEmail = Email;
        }
    }
}
