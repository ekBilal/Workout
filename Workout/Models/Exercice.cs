using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

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

        public List<Muscle> Cibles { get; set; }
        public Type Types { get; set; }

        public override string ToString()
        {
            return Nom;
        }

        public enum Type
        {
            musculation, poids_du_corps, stretching
            //haut, bas, push, pull
        }
    }
}