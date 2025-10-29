using Api29._10._25.DB;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Reflection.Metadata.Ecma335;

namespace Api29._10._25.CQRS.Command
{
    public class RegistreUserCommand : IRequest
    {
        public class RegistreUserCommandHandler : IRequestHandler<RegistreUserCommand, Unit>
        {
            private readonly KrylovXmarienkoContext db;
            public RegistreUserCommandHandler(KrylovXmarienkoContext db)
            {
                this.db = db;

            }
            public async Task<Unit> HandleAsync(RegistreUserCommand request, CancellationToken ct = default)
            {


                return Unit.Value;
            }
        }
    }
}
