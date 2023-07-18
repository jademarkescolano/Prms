using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using StarbeeRealty.Server.Class;
using StarbeeRealty.Shared;
using System.Data;

namespace StarbeeRealty.Server.Services
{
    public class PaymentServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;



        public PaymentServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        //View Payment
        public async Task<List<payments>> Payments()
        {
            List<payments> _payments = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("Viewpayments", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    _payments.Add(new payments
                    {
                        paymentid = Convert.ToInt32(rdr["paymentid"]),
                        clientid = Convert.ToInt32(rdr["clientID"]),
                        ar = rdr["ar"].ToString(),
                        clientname = rdr["clientname"].ToString(),
                        date = Convert.ToDateTime(rdr["date"]),
                        projectname = rdr["projectname"].ToString(),
                        paymentof = rdr["paymentof"].ToString(),
                        block = rdr["block"].ToString(),
                        lot = rdr["lot"].ToString(),
                        address = rdr["address"].ToString(),
                        amount = rdr["amount"].ToString(),
                        tcp = rdr["tcp"].ToString(),
                        balance = rdr["balance"].ToString(),
                        term = rdr["term"].ToString(),
                        nextpaymentdate = Convert.ToDateTime( rdr["nextpaymentdate"]),

                    });
                }
            }
            return _payments;
        }

        //Search Payment
        public async Task<List<payments>> SearchPayment(string search)
        {
            List<payments> _payments = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SearchPayment", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.Clear();
                com.Parameters.AddWithValue("search", search);
                com.Parameters.AddWithValue("searchWildcard", $"{search}%");
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    _payments.Add(new payments
                    {
                        paymentid = Convert.ToInt32(rdr["paymentid"]),
                        clientid = Convert.ToInt32(rdr["clientID"]),
                        ar = rdr["ar"].ToString(),
                        clientname = rdr["clientname"].ToString(),
                        date = Convert.ToDateTime(rdr["date"]),
                        projectname = rdr["projectname"].ToString(),
                        paymentof = rdr["paymentof"].ToString(),
                        block = rdr["block"].ToString(),
                        lot = rdr["lot"].ToString(),
                        address = rdr["address"].ToString(),
                        amount = rdr["amount"].ToString(),
                        balance = rdr["balance"].ToString(),
                        tcp = rdr["tcp"].ToString(),
                        term = rdr["term"].ToString(),
                        nextpaymentdate = Convert.ToDateTime(rdr["nextpaymentdate"]),

                    });
                }
            }
            return _payments;
        }


        //Insert Payment
        public async Task<int> AddPayment(payments _payments)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("AddPayment", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("_clientID", _payments.clientid);
                com.Parameters.AddWithValue("_ar", _payments.ar);
             
                com.Parameters.AddWithValue("_date", _payments.date);
                
                com.Parameters.AddWithValue("_paymentof", _payments.paymentof);
             
                com.Parameters.AddWithValue("_amount", _payments.amount);
           
                com.Parameters.AddWithValue("_nextpaymentdate", _payments.nextpaymentdate);
                return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }

        //Update Payment
        public async Task<int> UpdatePayment(payments _payments)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UpdatePayment", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("_paymentid", _payments.paymentid);
                com.Parameters.AddWithValue("_clientID", _payments.clientid);
                com.Parameters.AddWithValue("_ar", _payments.ar);
                
                com.Parameters.AddWithValue("_date", _payments.date);
               
                com.Parameters.AddWithValue("_paymentof", _payments.paymentof);
               
                com.Parameters.AddWithValue("_amount", _payments.amount);
                com.Parameters.AddWithValue("_balance", _payments.balance);
              
                com.Parameters.AddWithValue("_nextpaymentdate", _payments.nextpaymentdate);
                return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }


    }
}
