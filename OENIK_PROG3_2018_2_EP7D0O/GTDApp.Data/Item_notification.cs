namespace GTDApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_notification
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int item_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int notification_id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime created_at { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime updated_at { get; set; }

        public virtual Item Item { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
