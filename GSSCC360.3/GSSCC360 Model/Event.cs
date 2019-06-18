namespace GSSCC360._3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int Id { get; set; }

        [Required]
        public string DateStart { get; set; }

        [Required]
        public string DateEnd { get; set; }

        public virtual Events_TrialEvent Events_TrialEvent { get; set; }
    }
}
