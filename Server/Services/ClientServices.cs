using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using StarbeeRealty.Server.Class;
using StarbeeRealty.Shared;
using System.Data;
using System.Net;

namespace StarbeeRealty.Server.Services
{
    public class ClientServices
    {
        private readonly AppDb _constring;
        public IConfiguration Configuration;
        private readonly AppSettings _appSetting;



        public ClientServices(AppDb constring, IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _constring = constring;
            Configuration = configuration;
            _appSetting = appSettings.Value;
        }

        //View Clients
        public async Task<List<clients>> Clients()
        {
            List<clients> _clients = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("ViewClients", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    _clients.Add(new clients
                    {
                        reservedate = Convert.ToDateTime(rdr["reservedate"]).Date,
                        clientID = Convert.ToInt32(rdr["clientID"]),
                        fname = rdr["fname"].ToString(),
                        mname = rdr["mname"].ToString(),
                        lname = rdr["lname"].ToString(),
                        fullname = rdr["fullname"].ToString(),
                        address = rdr["address"].ToString(),
                        occupation = rdr["occupation"].ToString(),
                        validID = (byte[])rdr["validID"],
                        contact = rdr["contact"].ToString(),
                        email = rdr["email"].ToString(),
                        income = rdr["income"].ToString(),
                        civil = rdr["civil"].ToString(),
                        birthdate = Convert.ToDateTime(rdr["birthdate"]).Date,
                        workadd = rdr["workadd"].ToString(),
                        agentname = rdr["agentname"].ToString(),
                        projectname = rdr["projectname"].ToString(),
                        spousename = rdr["spousename"].ToString(),
                        spousecontact = rdr["spousecontact"].ToString(),
                        term = rdr["term"].ToString(),
                        block = rdr["block"].ToString(),
                        lot = rdr["lot"].ToString(),
                        tcp = rdr["tcp"].ToString(),
                    });
                }
            }
            return _clients;
        }

        //Search Clients
        public async Task<List<clients>> SearchClient(string search)
        {
            List<clients> _clients = new();
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("SearchClients", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.Clear();
                com.Parameters.AddWithValue("search", search);
                com.Parameters.AddWithValue("_searchWildcard", $"{search}%");

                var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);
                while (await rdr.ReadAsync().ConfigureAwait(false))
                {
                    _clients.Add(new clients
                    {
                        reservedate = Convert.ToDateTime(rdr["reservedate"]).Date,
                        clientID = Convert.ToInt32(rdr["clientID"]),
                        fname = rdr["fname"].ToString(),
                        mname = rdr["mname"].ToString(),
                        lname = rdr["lname"].ToString(),
                        fullname = rdr["fullname"].ToString(),
                        address = rdr["address"].ToString(),
                        occupation = rdr["occupation"].ToString(),
                        validID = (byte[])rdr["validID"],
                        contact = rdr["contact"].ToString(),
                        email = rdr["email"].ToString(),
                        income = rdr["income"].ToString(),
                        civil = rdr["civil"].ToString(),
                        birthdate = Convert.ToDateTime(rdr["birthdate"]).Date,
                        workadd = rdr["workadd"].ToString(),
                        agentname = rdr["agentname"].ToString(),
                        projectname = rdr["projectname"].ToString(),
                        spousename = rdr["spousename"].ToString(),
                        spousecontact = rdr["spousecontact"].ToString(),
                        term = rdr["term"].ToString(),
                        block = rdr["block"].ToString(),
                        lot = rdr["lot"].ToString(),
                        tcp = rdr["tcp"].ToString(),
                    });
                }
            }
            return _clients;
        }


        //Insert Client
        public async Task<int> AddClient(clients newClient)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("AddClient", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("_reservedate", newClient.reservedate);
                com.Parameters.AddWithValue("_fname", newClient.fname);
                com.Parameters.AddWithValue("_mname", newClient.mname);
                com.Parameters.AddWithValue("_lname", newClient.lname);
                com.Parameters.AddWithValue("_address", newClient.address);
                com.Parameters.AddWithValue("_occupation", newClient.occupation);
                com.Parameters.AddWithValue("_validID", newClient.validID);
                com.Parameters.AddWithValue("_contact", newClient.contact);
                com.Parameters.AddWithValue("_email", newClient.email);
                com.Parameters.AddWithValue("_income", newClient.income);
                com.Parameters.AddWithValue("_civil", newClient.civil);
                com.Parameters.AddWithValue("_birthdate", newClient.birthdate);
                com.Parameters.AddWithValue("_workadd", newClient.workadd);
                com.Parameters.AddWithValue("_agentname", newClient.agentname);
                com.Parameters.AddWithValue("_projectname", newClient.projectname);
                com.Parameters.AddWithValue("_spousename", newClient.spousename);
                com.Parameters.AddWithValue("_spousecontact", newClient.spousecontact);
                com.Parameters.AddWithValue("_term", newClient.term);
                com.Parameters.AddWithValue("_block", newClient.block);
                com.Parameters.AddWithValue("_lot", newClient.lot);
                com.Parameters.AddWithValue("_tcp", newClient.tcp);

                return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }


        //Update Client
        public async Task<int> UpdateClient(clients newClient)
        {
            using (var con = new MySqlConnection(_constring.GetConnection()))
            {
                await con.OpenAsync().ConfigureAwait(false);
                var com = new MySqlCommand("UpdateClient", con)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                com.Parameters.Clear();
                com.Parameters.AddWithValue("_clientID", newClient.clientID);
                com.Parameters.AddWithValue("_reservedate", newClient.reservedate);
                com.Parameters.AddWithValue("_fname", newClient.fname);
                com.Parameters.AddWithValue("_mname", newClient.mname);
                com.Parameters.AddWithValue("_lname", newClient.lname);
                com.Parameters.AddWithValue("_address", newClient.address);
                com.Parameters.AddWithValue("_occupation", newClient.occupation);
                com.Parameters.AddWithValue("_validID", newClient.validID);
                com.Parameters.AddWithValue("_contact", newClient.contact);
                com.Parameters.AddWithValue("_email", newClient.email);
                com.Parameters.AddWithValue("_income", newClient.income);
                com.Parameters.AddWithValue("_civil", newClient.civil);
                com.Parameters.AddWithValue("_birthdate", newClient.birthdate);
                com.Parameters.AddWithValue("_workadd", newClient.workadd);
                com.Parameters.AddWithValue("_agentname", newClient.agentname);
                com.Parameters.AddWithValue("_projectname", newClient.projectname);
                com.Parameters.AddWithValue("_spousename", newClient.spousename);
                com.Parameters.AddWithValue("_spousecontact", newClient.spousecontact);
                com.Parameters.AddWithValue("_term", newClient.term);
                com.Parameters.AddWithValue("_block", newClient.block);
                com.Parameters.AddWithValue("_lot", newClient.lot);
                com.Parameters.AddWithValue("_tcp", newClient.tcp);

                return await com.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }

    }
}
