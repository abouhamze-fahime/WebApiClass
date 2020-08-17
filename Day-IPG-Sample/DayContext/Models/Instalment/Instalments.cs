using Day_IPG_Sample.DayContext.Models.Account;

namespace Day_IPG_Sample.Models
{
    public class Instalments
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public int InsuranceNumber { get; set; }
        public string DueDate { get; set; }
        public decimal Price { get; set; }

        public Users User { get; set; }
    }
}