using System;

namespace Day_IPG_Sample.DayContext.Models.Account
{
    public class OTPRequests
    {
        public string NationalCode { get; set; }
        public int Code { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}