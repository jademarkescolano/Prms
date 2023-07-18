using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbeeRealty.Shared
{
    public class payments
    {
        public int paymentid { get; set; }
        public int clientid { get; set; }
        public string ar { get; set; }
        public string clientname { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public string projectname { get; set; }
        public string paymentof { get; set; }
        public string block { get; set; }
        public string lot { get; set; }
        public string address { get; set; }
        public double _tcp { get; set; }
        public double _amount { get; set; }
        public double _balance { get; set; }
        public string term { get; set; }
        public DateTime nextpaymentdate { get; set; } = DateTime.Now;


        //tcp
        public string tcp
        {
            get { return _tcp.ToString("0.00"); }
            set { _tcp = double.Parse(value); }
        }


        //balance
        public string balance
        {
            get { return _balance.ToString("0.00"); }
            set { _balance = double.Parse(value); }
        }

        //amount
        public string amount
        {
            get { return _amount.ToString("0.00"); }
            set { _amount = double.Parse(value); }
        }

        public int amount2
        {
            get { return ((int)_amount); }
            set { _amount = value; }
        }
    }
}
