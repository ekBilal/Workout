using System;
using System.Collections.Generic;

namespace Workout.Models
{
    public class Muscle
    {
        public int IdMuscle{get; set;}
        public string Nom { get; set;}
        public Groupe Groupe { get; set;}

        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            try
            {
                var muscle = (Muscle)obj;
                if (IdMuscle != muscle.IdMuscle) return false;
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
            hashCode = hashCode * -1521134295 + IdMuscle.GetHashCode();
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
