using System;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace Workout.Models
{
    public class Historique
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(typeof(Exercice))] 
        public int ExerciceId { get; set; }

        [ManyToOne]
        public Exercice Exercice { get; set; }

        public int Charge { get; set; }

        public int Reps { get; set; }
    }
}
