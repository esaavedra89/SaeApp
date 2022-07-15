using Newtonsoft.Json;
using SaeApp.Model.Modules.Sell;
using SaeApp.Model.Modules.System.Finance;
using SaeApp.Model.Modules.System.Locations;
using SQLite;
using System;

namespace SaeApp.Model.Modules.Receivable
{
    public class Receivable
    {
        [PrimaryKey, AutoIncrement]
        public int IdReceivable { get; set; }
        public int Number { get; set; }
        public string Coments { get; set; }
        public int IdClient { get; set; }
        [Ignore]
        public Client Client { get; set; }
        public int IdLocal { get; set; }
        [Ignore, JsonIgnore]
        public Local Local { get; set; }
        public int IdCurrency { get; set; }
        [Ignore, JsonIgnore]
        public Currency Currency { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
