namespace Api29._10._25.CQRS.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ShippingAddressId { get; set; }

        public int PaymentMethodId { get; set; }
    }
}
