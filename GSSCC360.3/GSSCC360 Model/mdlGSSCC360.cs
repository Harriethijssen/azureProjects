namespace GSSCC360._3
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mdlGSSCC360 : DbContext
    {
        public mdlGSSCC360()
            : base("name=mdlGSSCC360")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Events_TrialEvent> Events_TrialEvent { get; set; }
        public virtual DbSet<lutBreed> lutBreeds { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<TrialEntry> TrialEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.Club)
                .HasForeignKey(e => e.Club_Id);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Events_TrialEvent)
                .WithRequired(e => e.Club)
                .HasForeignKey(e => e.HostedBy_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Members)
                .WithMany(e => e.Clubs1)
                .Map(m => m.ToTable("ClubMember").MapLeftKey("Clubs_Id").MapRightKey("Members_Id"));

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .HasMany(e => e.Dogs)
                .WithRequired(e => e.Document)
                .HasForeignKey(e => e.Pedigree_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dog>()
                .HasMany(e => e.Dogs1)
                .WithRequired(e => e.Dog1)
                .HasForeignKey(e => e.Sire_Id);

            modelBuilder.Entity<Dog>()
                .HasMany(e => e.Dogs11)
                .WithRequired(e => e.Dog2)
                .HasForeignKey(e => e.Dam_Id);

            modelBuilder.Entity<Dog>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.Dog)
                .HasForeignKey(e => e.Dog_Id);

            modelBuilder.Entity<Dog>()
                .HasMany(e => e.TrialEntries)
                .WithRequired(e => e.Dog)
                .HasForeignKey(e => e.Dog_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasOptional(e => e.Events_TrialEvent)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Events_TrialEvent>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.Events_TrialEvent)
                .HasForeignKey(e => e.TrialEvent_Id);

            modelBuilder.Entity<Events_TrialEvent>()
                .HasMany(e => e.TrialEntries)
                .WithRequired(e => e.Events_TrialEvent)
                .HasForeignKey(e => e.TrialEventId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lutBreed>()
                .HasMany(e => e.Dogs)
                .WithRequired(e => e.lutBreed)
                .HasForeignKey(e => e.Breed_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Clubs)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.President_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.TrialEntries)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Handler_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.Documents)
                .WithOptional(e => e.Notification)
                .HasForeignKey(e => e.NotificationDocument_Document_Id);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Member)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Clubs)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrialEntry>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.TrialEntry)
                .HasForeignKey(e => e.TrialEntry_Id);
        }
    }
}
