using System.Collections.Generic;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.DayContext.Models.Account
{
    public class Users
    {
        public string MobileNumber { get; set; }

        public string NationalCode { get; set; }

        public ICollection<ActiveSessions> ActiveSessions{ get; set; }

        public ICollection<Instalments> Instalments { get; set; }
    }
}