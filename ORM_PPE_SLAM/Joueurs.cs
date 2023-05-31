namespace ORM_PPE_SLAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Joueurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Joueurs()
        {
            Match_joueur = new HashSet<Match_joueur>();
        }

        [Key]
        public int ID_Joueur { get; set; }

        [Required]
        [StringLength(50)]
        public string NOM_Joueur { get; set; }

        [Required]
        [StringLength(50)]
        public string PRENOM_Joueur { get; set; }

        public byte AGE_Joueur { get; set; }

        public byte NUMERO_Joueur { get; set; }

        [Required]
        [StringLength(50)]
        public string POSTE_Joueur { get; set; }

        public int ID_Equipe { get; set; }

        public virtual Equipes Equipes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match_joueur> Match_joueur { get; set; }
    }
}
