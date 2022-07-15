
namespace SaeApp.Model.Modules.Sell
{
    public class PaymentStatus
    {
        public const int SELL_PAYMENTSTATUS_NOTPAYED = 1;
        public const int SELL_PAYMENTSTATUS_PAIDOUT = 2;
        public const int SELL_PAYMENTSTATUS_SEMIPAIDOUT = 3;

        public int IdPaymentStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
