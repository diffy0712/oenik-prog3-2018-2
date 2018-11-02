namespace GTDApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Container")]
    public partial class Container
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Container()
        {
            Container_storage = new HashSet<Container_storage>();
            Container_item = new HashSet<Container_item>();
            Container1 = new HashSet<Container>();
        }

        [Key]
        public int container_id { get; set; }

        public int? parent_container_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(500)]
        public string purpose { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        [Required]
        [StringLength(1000)]
        public string principles { get; set; }

        [Required]
        [StringLength(1000)]
        public string invisioned_outcome { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Container_storage> Container_storage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Container_item> Container_item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Container> Container1 { get; set; }

        public virtual Container Container2 { get; set; }
    }
}
