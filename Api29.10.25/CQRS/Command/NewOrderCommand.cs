using Api29._10._25.CQRS.DTO;
using Api29._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api29._10._25.CQRS.Command
{
    public class NewOrderCommand : CommandInfo, IRequest
    {
        public required OrderDTO Order { get; set; }

        public class NewOrderCommandHandler : IRequestHandler<NewOrderCommand, Unit>
        {
            private readonly KrylovXmarienkoContext db;

            public NewOrderCommandHandler(KrylovXmarienkoContext db)
            {
                this.db = db;

            }
            public async Task<Unit> HandleAsync(NewOrderCommand request, CancellationToken ct = default)
            {
                var order = new Order()
                {
                    UserId = request.Order.UserId,
                    ShippingAddressId = db.ShippingAddresses.FirstOrDefault(s => 
                        request.Order.House == s.House &&
                        request.Order.Street == s.Street &&
                        request.Order.Citi == s.City &&
                        request.Order.PostalCode == s.PostalCode).Id,
                    PaymentMethodId = db.PaymentMethods.FirstOrDefault(s => s.Value == request.Order.PaymentMethod).Id,
                };

                db.Orders.Add(order);
                db.SaveChanges();
                db.Items.Add(new Item()
                {
                    OrderId = order.Id,
                    ProductId = request.Order.ProductId,
                    Count = request.Order.Count,
                });
                db.SaveChanges();
                return Unit.Value;
            }
        }
    }
}
