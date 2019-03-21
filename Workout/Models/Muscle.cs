using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Workout.Models
{
    public class Muscle
    {
        [PrimaryKey, AutoIncrement]
        public int Id{get; set;}

        [Unique]
        public string Nom { get; set;}

        public Groupe Groupe { get; set;}

        [ManyToMany(typeof(ExerciceMuscle))]
        public List<Exercice> exercices { get; set; }

        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            try
            {
                var muscle = (Muscle)obj;
                if (Id != muscle.Id) return false;
                if (Nom != muscle.Nom) return false;

            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public override int GetHashCode()
        {
            var hashCode = 543565279;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + Groupe.GetHashCode();
            return hashCode;
        }
    }

    public enum Groupe
    {
        non_def,
        bas_du_corps,
        haut_du_corps
    }
}