using Api29._10._25.Behaviors;
using Api29._10._25.DB;
using System.ComponentModel.DataAnnotations;

namespace Api29._10._25.CQRS.Command
{
    public class UserCommandVaildator : IValidator<RegistreUserCommand>
    {
        public async Task<IEnumerable<string>> ValidateAsync(RegistreUserCommand request, CancellationToken ct)
        {
            var result = new List<string>();

            if (!request.User.Email.Contains("@"))
                result.Add("Не правильный email");

            if (request.User.DateOfBirth.ToDateTime(TimeOnly.MinValue).Year - DateTime.Now.Year < 18)
                result.Add("Не совершеннолетний ");

            if (!request.User.Phone.StartsWith("+") || !request.User.Phone.Contains("(") || !request.User.Phone.Contains(")") || !request.User.Phone.Contains("-"))
                result.Add("Не правильный телефон");

            return result;
        }
    }
}
