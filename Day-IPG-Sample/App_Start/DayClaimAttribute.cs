using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day_IPG_Sample.App_Start
{
    public class DayClaimAttribute : Attribute
    {
        public string Title { get; set; }

        public DayClaimAttribute(string title)
        {
            Title = title;
        }
    }
}