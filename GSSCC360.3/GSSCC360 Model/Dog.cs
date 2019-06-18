namespace GSSCC360._3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dog()
        {
            Dogs1 = new HashSet<Dog>();
            Dogs11 = new HashSet<Dog>();
            Notifications = new HashSet<Notification>();
            TrialEntries = new HashSet<TrialEntry>();
        }

        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Sex { get; set; }

        public short? State { get; set; }

        public int Breed_Id { get; set; }

        public int Sire_Id { get; set; }

        public int Dam_Id { get; set; }

        public int Pedigree_Id { get; set; }

        public int? MemberId { get; set; }

        public virtual Document Document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dog> Dogs1 { get; set; }

        public virtual Dog Dog1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dog> Dogs11 { get; set; }

        public virtual Dog Dog2 { get; set; }

        public virtual lutBreed lutBreed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrialEntry> TrialEntries { get; set; }
    }
}
