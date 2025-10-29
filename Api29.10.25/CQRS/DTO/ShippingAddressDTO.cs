namespace Api29._10._25.CQRS.DTO
{
    public class ShippingAddressDTO
    {
        public int Id { get; set; }

        public string House { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public int PostalCode { get; set; }
    }
}
