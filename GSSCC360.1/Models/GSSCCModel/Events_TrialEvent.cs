//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSSCC360._1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Events_TrialEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Events_TrialEvent()
        {
            this.Notifications = new HashSet<Notification>();
            this.TrialEntries = new HashSet<TrialEntry>();
        }
    
        public int IdTrialEvent { get; set; }
        public string State { get; set; }
        public int Id { get; set; }
        public int HostedBy_Id { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual Event Event { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrialEntry> TrialEntries { get; set; }
    }
}
