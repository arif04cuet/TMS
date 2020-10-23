using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ResourcePerson), Schema = SchemaConstants.Training)]
    public class ResourcePerson : BaseEntity
    {
        public string ShortName { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? OfficeId { get; set; }
        public Office Office { get; set; }

        public long? HonorariumHeadId { get; set; }
        public HonorariumHead HonorariumHead { get; set; }

        public string NID { get; set; }
        public string TIN { get; set; }

        public string AltEmail { get; set; }
        public string AltMobile { get; set; }

        public string MailingAddress { get; set; }
        public string OfficeAddress { get; set; }

        public long? CvId { get; set; }
        public Media Cv { get; set; }

        public long? PhotoId { get; set; }
        public Media Photo { get; set; }

        public string FacebookUrl { get; set; }
        public bool IsFacebookUrlPublic { get; set; }

        public string YouTubeUrl { get; set; }
        public bool IsYouTubeUrlPublic { get; set; }

        public string LinkedinUrl { get; set; }
        public bool IsLinkedinUrlPublic { get; set; }

        public string InstagramUrl { get; set; }
        public bool IsInstagramUrlPublic { get; set; }


    }

}
