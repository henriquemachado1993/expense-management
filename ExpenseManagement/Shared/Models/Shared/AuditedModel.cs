using System;

namespace ExpenseManagement.Shared.Models.Shared
{
    public class AuditedModel
    {
        public string UserName { get; set; }
        public string UserIdentifier { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public string CreatedAtText
        {
            get
            {
                return CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }
        public string LastModifiedAtText
        {
            get
            {
                return LastModifiedAt != null ? CreatedAt.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
    }
}
