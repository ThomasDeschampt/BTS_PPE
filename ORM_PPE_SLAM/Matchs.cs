namespace ORM_PPE_SLAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Matchs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Matchs()
        {
            Match_Equipes = new HashSet<Match_Equipes>();
            Match_joueur = new HashSet<Match_joueur>();
        }

        [Key]
        public int ID_Match { get; set; }

        [Required]
        [StringLength(50)]
        public string LIEU_Match { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DATE_Match { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match_Equipes> Match_Equipes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match_joueur> Match_joueur { get; set; }
    }
}
