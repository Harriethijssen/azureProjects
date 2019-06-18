namespace GSSCC360._3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notification()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }

        public int PersonId { get; set; }

        [Required]
        public string Description { get; set; }

        public int? Club_Id { get; set; }

        public int? TrialEntry_Id { get; set; }

        public int? TrialEvent_Id { get; set; }

        public int? Dog_Id { get; set; }

        public virtual Club Club { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }

        public virtual Dog Dog { get; set; }

        public virtual Events_TrialEvent Events_TrialEvent { get; set; }

        public virtual Person Person { get; set; }

        public virtual TrialEntry TrialEntry { get; set; }
    }
}
