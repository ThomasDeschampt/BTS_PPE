namespace ORM_PPE_SLAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipes()
        {
            Joueurs = new HashSet<Joueurs>();
            Match_Equipes = new HashSet<Match_Equipes>();
        }

        [Key]
        public int ID_Equipe { get; set; }

        [Required]
        [StringLength(50)]
        public string NOM_Equipe { get; set; }

        [Required]
        [StringLength(6)]
        public string LIB_Equipe { get; set; }

        public int NOMBRE_VICTOIRES_Equipe { get; set; }

        public int NOMBRE_DEFAITES_Equipe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Joueurs> Joueurs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match_Equipes> Match_Equipes { get; set; }
    }
}
