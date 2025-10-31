namespace Api29._10._25.CQRS.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PaymentMethodId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string House {  get; set; }
        public string Street {  get; set; }
        public string Citi {  get; set; }
        public int PostalCode {  get; set; }
        public string PaymentMethod {  get; set; }

       
    }
}
