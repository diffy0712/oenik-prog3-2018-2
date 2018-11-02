namespace GTDApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Storage_attachment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int storage_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int attachment_id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime created_at { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime updated_at { get; set; }

        public virtual Attachment Attachment { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
