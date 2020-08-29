using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(UserForgotPasswordToken), Schema = SchemaConstants.Core)]
    public class UserForgotPasswordToken : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public string Token { get; set; }
    }
}