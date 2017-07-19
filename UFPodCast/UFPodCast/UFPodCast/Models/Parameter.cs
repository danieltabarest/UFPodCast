using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace UFPodCast.Models
{
    public class Parameter
    {
        [PrimaryKey, AutoIncrement]
        public int ParameterId { get; set; }

        public string URLBase { get; set; }
        

        public string Option { get; set; }

        public override int GetHashCode()
        {
            return ParameterId;
        }
    }


}
