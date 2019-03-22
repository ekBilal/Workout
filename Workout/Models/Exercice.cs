using System.Collections.ObjectModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Workout.Models
{
    public class Exercice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(255)]
        public string Nom { get; set; }

        public string Description { get; set; }

        public int Difficulte { get; set; }

        [ManyToOne]
        public Muscle Cible { get; set; }

        [ForeignKey(typeof(Muscle))]
        public int MuscleId { get; set; }

        [ManyToMany(typeof(ExerciceMuscle))]
        public ObservableCollection<Muscle> Cibles { get; set; }

        public Type Types { get; set; }

        [OneToMany]
        public ObservableCollection<Historique> Historiques { get; set; }

    }


    public enum Type
    {
        musculation, poids_de_corps, stretching
    }
}