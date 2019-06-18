//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSSCC360._2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dog()
        {
            this.Notifications = new HashSet<Notification>();
            this.TrialEntries = new HashSet<TrialEntry>();
        }
    
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public Nullable<DogState> State { get; set; }
        public int Breed_Id { get; set; }
        public int Sire_Id { get; set; }
        public int Dam_Id { get; set; }
        public int Pedigree_Id { get; set; }
        public Nullable<int> MemberId { get; set; }
    
        public virtual Document Document { get; set; }
        public virtual lutBreed lutBreed { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrialEntry> TrialEntries { get; set; }
        public virtual Member Owner { get; set; }
    }
}