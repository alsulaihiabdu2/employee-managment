using System.ComponentModel.DataAnnotations;

namespace Emp.Librarary.Domain
{
    public class Employee
    {

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Verify FristName required")]
        public string FristName { get; set; }
        [Required(ErrorMessage = "Verify LastName required")]
        public string LastName { get; set; }
        public string Depatment { get; set; }
        [Required(ErrorMessage = "Verify Salary required")]
        public int Salary { get; set; }
    }
}
