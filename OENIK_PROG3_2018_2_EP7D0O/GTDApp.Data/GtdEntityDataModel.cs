namespace GTDApp.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GtdEntityDataModel : DbContext
    {
        public GtdEntityDataModel()
            : base("name=GtdEntityDataModel")
        {
        }

        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Container_item> Container_item { get; set; }
        public virtual DbSet<Item_notification> Item_notification { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>()
                .HasMany(e => e.Container_item)
                .WithRequired(e => e.Container)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Container_item)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Item_notification)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.Item_notification)
                .WithRequired(e => e.Notification)
                .WillCascadeOnDelete(false);
        }
    }
}
