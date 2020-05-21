using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Hostel), Schema = SchemaConstants.Training)]
    public class Hostel : IdNameEntity
    {
        public long? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
