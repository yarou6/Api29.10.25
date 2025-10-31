using Api29._10._25.Behaviors;
using Api29._10._25.CQRS.DTO;
using Api29._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace Api29._10._25.CQRS.Command
{
    public class OrderCommandValidator : IValidator<NewOrderCommand>
    {
        private readonly KrylovXmarienkoContext db;

        public OrderCommandValidator(KrylovXmarienkoContext db)
        {
            this.db = db;

        }
        public async Task<IEnumerable<string>> ValidateAsync(NewOrderCommand request, CancellationToken ct)
        {
            var result = new List<string>();
            bool c = false;
            foreach (Item item in db.Items)
            {
                for (int i = 0; i < item.Count; i++)
                    if (request.Order.ProductId == item.ProductId)
                        c = true;
        }
            if (!c)
                result.Add("Продукт не содержится");
            if (request.Order.Count == 0)
                result.Add("Продукта нет");
            c = false;
            foreach (User user in db.Users)
            {
                if (request.Order.UserId == user.Id)
                    c = true;
            }
            if (!c)
                result.Add("Пользователь не содержится");
            return result;
        }
    }

}
