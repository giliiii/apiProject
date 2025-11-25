namespace Chocolate.Models
{
    public class Users
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Orders? Order { get; set; }
        public string Email { get; set; }
    }
}
