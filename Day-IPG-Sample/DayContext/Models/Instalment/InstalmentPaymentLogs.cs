using System;

namespace Day_IPG_Sample.DayContext.Models.Instalment
{
    public class InstalmentPaymentLogs
    {
        public int Id { get; set; }
        public int InstalmentId { get; set; }
        public string TrackCode { get; set; }
        public DateTime PayDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}