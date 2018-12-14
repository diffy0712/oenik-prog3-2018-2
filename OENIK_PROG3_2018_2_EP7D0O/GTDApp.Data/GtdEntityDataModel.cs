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

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Container_item> Container_item { get; set; }
        public virtual DbSet<Container_storage> Container_storage { get; set; }
        public virtual DbSet<Item_notification> Item_notification { get; set; }
        public virtual DbSet<Item_storage> Item_storage { get; set; }
        public virtual DbSet<Storage_attachment> Storage_attachment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.Storage_attachment)
                .WithRequired(e => e.Attachment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Container>()
                .HasMany(e => e.Container_storage)
                .WithRequired(e => e.Container)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Item_storage)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.Item_notification)
                .WithRequired(e => e.Notification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.Container_storage)
                .WithRequired(e => e.Storage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.Item_storage)
                .WithRequired(e => e.Storage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.Storage_attachment)
                .WithRequired(e => e.Storage)
                .WillCascadeOnDelete(false);
        }
    }
}
