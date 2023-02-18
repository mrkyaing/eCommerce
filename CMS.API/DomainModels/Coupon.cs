using System;
namespace CMS.API.DomainModels{
    public class Coupon{
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountAmount { get; set; }
        public int AvailableQuantity{ get; set; }
        public string QRCode { get; set; }
    }
}
