namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public int Age { get; set; }

        public Department Department { get; set; }

        public string ShortName() {
            return this.LastName + " " + this.FirstName.Substring(0, 1) + ". " + this.Patronymic.Substring(0, 1) + ".";
        }
    }
}
