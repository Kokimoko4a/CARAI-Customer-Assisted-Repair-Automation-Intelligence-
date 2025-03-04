



namespace CARAI.Domain.Entities
{
    using CARAI.Domain.Entities.Enumerations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Domain.Constants.ResponseAndRequestConstants;

    public class MechanicTask
    {
        


        [ForeignKey(nameof(Request))]
        public Guid RequestId { get; set; }

        public RequestToMechanic Request { get; set; }


        [ForeignKey(nameof(Mechanic))]
        public Guid MechanicId { get; set; }

        public Mechanic Mechanic { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        
    }
}
