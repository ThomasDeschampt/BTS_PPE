namespace ORM_PPE_SLAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Match_joueur
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Match { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Joueur { get; set; }

        public int ScoreJoueur { get; set; }

        public virtual Joueurs Joueurs { get; set; }

        public virtual Matchs Matchs { get; set; }
    }
}
