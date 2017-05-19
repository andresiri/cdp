using System;
namespace api.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Number { get; set; }
        public string Position { get; set; }
    }
}
