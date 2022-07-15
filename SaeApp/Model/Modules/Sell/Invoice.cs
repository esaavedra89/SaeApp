using Newtonsoft.Json;
using SaeApp.Model.Modules.System.Entity;
using SaeApp.Model.Modules.System.Finance;
using SaeApp.Model.Modules.System.Locations;
using SaeApp.Model.Modules.System.Security;
using SQLite;
using System;
using System.Collections.Generic;

namespace SaeApp.Model.Modules.Sell
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int IdInvoice { get; set; }
        public int IdClient { get; set; }
        [Ignore, JsonIgnore]
        public Client Client { get; set; }
        public int IdSellerUser { get; set; }
        [Ignore, JsonIgnore]
        public User SellerUser { get; set; }
        public int IdLocal { get; set; }
        [Ignore, JsonIgnore]
        public Local Local { get; set; }
        public int IdCurrency { get; set; }
        [Ignore, JsonIgnore]
        public Currency Currency { get; set; }
        public DateTime? PayDay { get; set; }
        public int IdPaymentStatus { get; set; }
        [Ignore, JsonIgnore]
        public PaymentStatus PaymentStatus { get; set; }
        public int IdStateEntity { get; set; }
        [Ignore, JsonIgnore]
        public StateEntity StateEntity { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceInTheNameOf { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public List<InvoiceItem> ItemsList { get; set; }

        public DateTime AdmissionDate { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}
