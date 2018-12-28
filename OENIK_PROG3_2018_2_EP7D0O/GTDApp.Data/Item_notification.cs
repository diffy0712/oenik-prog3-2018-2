namespace GTDApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_notification
    {
        public int id { get; set; }

        public int item_id { get; set; }

        public int notification_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime updated_at { get; set; }

        public virtual Item Item { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
