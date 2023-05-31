namespace ORM_PPE_SLAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Match_Equipes
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Match { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Equipe { get; set; }

        public int ScoreEquipe1 { get; set; }

        public int ScoreEquipe2 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateMatch { get; set; }

        public virtual Equipes Equipes { get; set; }

        public virtual Matchs Matchs { get; set; }
    }
}
