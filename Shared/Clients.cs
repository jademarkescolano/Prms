using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbeeRealty.Shared
{
    public class clients
    {
        public DateTime reservedate { get; set; } = DateTime.Now;
        public int clientID { get; set; }
        public string? fname { get; set; }
        public string? mname { get; set; }
        public string? lname { get; set; }
        public string? fullname { get; set; }
        public string? address { get; set; }
        public string? occupation { get; set; }
        [Required]
        public byte[]? validID { get; set; }
        public string? contact { get; set; }
        public string? email { get; set; }
        public string? income { get; set; }
        public string? civil { get; set; }
        public DateTime birthdate { get; set; } = DateTime.Now;
        public string? workadd { get; set; }
        public string? agentname { get; set; }
        public string? projectname { get; set; }
        public string? spousename { get; set; }
        public string? spousecontact { get; set; }
        public string? term { get; set; }
        public string? block { get; set; }
        public string? lot { get; set; }
        public double _tcp { get; set; }


        //tcp
        public string tcp
        {
            get { return _tcp.ToString("0.00"); }
            set { _tcp = double.Parse(value); }
        }

    }
}
