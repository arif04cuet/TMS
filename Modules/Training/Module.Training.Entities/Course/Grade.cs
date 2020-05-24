using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Grade), Schema = SchemaConstants.Training)]
    public class Grade : IdNameEntity
    {
        public int From { get; set; }
        public int To { get; set; }
    }
}
