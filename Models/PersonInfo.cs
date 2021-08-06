using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Models
{
    public class PersonInfo
    {
        public int Personid { get; set; }
        public string Name { get; set; }
        public string Phoneno { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
    }
}
