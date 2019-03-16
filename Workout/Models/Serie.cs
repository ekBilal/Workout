using System;
using SQLite;

namespace Workout.Models
{
    public class Serie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Exercice Exercice { get; set; }
        public int NbReps { get; set; }
        public int Repos { get; set; }
        public int Charge { get; set; }

        public override string ToString()
        {
            return NbReps + "x " + Exercice;
        }
    }
}