namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("medecin")]
    public partial class medecin
    {
        [Key]
        public int id_med { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_med { get; set; }

        [Required]
        [StringLength(50)]
        public string pre_med { get; set; }

        [Required]
        [StringLength(250)]
        public string adr_med { get; set; }

        [Required]
        [StringLength(50)]
        public string tel_med { get; set; }

        [Column("_FK_id_spe")]
        public int? C_FK_id_spe { get; set; }

        [Column("_FK_id_dep")]
        public int C_FK_id_dep { get; set; }

        public virtual departement departement { get; set; }

        public virtual specialite specialite { get; set; }
    }
}
