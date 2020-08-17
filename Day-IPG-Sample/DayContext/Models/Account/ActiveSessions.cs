using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day_IPG_Sample.DayContext.Models.Account
{
    public class ActiveSessions
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string IP { get; set; }

        public Users User { get; set; }
    }
}