using Capstonep2.Infrastructure.Domain.Models;

namespace Capstonep2.ViewModel
{
    public class CRViewModel
    {
        public Guid? ConsultationRecordID { get; set; }
        public Guid? PatientID { get; set; }
        public string? Symptoms { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid? FindingID { get; set; }
        public string? FTags { get; set; }
        public string? FDescription { get; set; }
        public Guid? PrescriptionID { get; set; }
        public string? PTags { get; set; }
        public string? PDescription { get; set; }
        public Patient? Patient { get; set; }
    }
}
