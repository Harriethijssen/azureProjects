namespace GSSCC360._3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrialEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrialEntry()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }

        [Required]
        public string ScoreA { get; set; }

        [Required]
        public string ScoreB { get; set; }

        public int TrialEventId { get; set; }

        public short State { get; set; }

        public int Dog_Id { get; set; }

        public int Handler_Id { get; set; }

        public virtual Dog Dog { get; set; }

        public virtual Events_TrialEvent Events_TrialEvent { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
