using Api29._10._25.DB;
using Api29._10._25.CQRS.DTO;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Reflection.Metadata.Ecma335;

namespace Api29._10._25.CQRS.Command
{
    public class RegistreUserCommand : IRequest
    {
        public required UserDTO User { get; set; }
        public class RegistreUserCommandHandler : IRequestHandler<RegistreUserCommand, Unit>
        {
            private readonly KrylovXmarienkoContext db;

            public RegistreUserCommandHandler(KrylovXmarienkoContext db)
            {
                this.db = db;

            }
            public async Task<Unit> HandleAsync(RegistreUserCommand request, CancellationToken ct = default)
            {
                db.Users.Add(new User()
                {
                    Email = request.User.Email,
                    Phone = request.User.Phone,
                    Info = request.User.Info,
                    DateOfBirth = request.User.DateOfBirth,
                    FirstName = request.User.FirstName,
                    LastName = request.User.LastName,
                    Password = request.User.Password,
                });
                db.SaveChanges();
                return Unit.Value;
            }
        }
    }
}
