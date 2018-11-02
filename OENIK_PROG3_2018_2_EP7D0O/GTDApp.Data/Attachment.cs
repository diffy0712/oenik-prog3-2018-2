namespace GTDApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attachment")]
    public partial class Attachment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attachment()
        {
            Storage_attachment = new HashSet<Storage_attachment>();
        }

        [Key]
        public int attachment_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(200)]
        public string path { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage_attachment> Storage_attachment { get; set; }
    }
}
