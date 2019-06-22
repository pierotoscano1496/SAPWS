namespace SAPWS.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public int NumberAccount { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
    }
}