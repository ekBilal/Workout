using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Exercice> Exercices { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }

    public enum Groupe
    {
        non_def,
        bas_du_corps,
        haut_du_corps
    }
}