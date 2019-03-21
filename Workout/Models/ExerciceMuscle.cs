using SQLiteNetExtensions.Attributes;

namespace Workout.Models
{
    internal class ExerciceMuscle
    {
        [ForeignKey(typeof(Exercice))]
        public int ExerciceId { get; set; }
        [ForeignKey(typeof(Muscle))]
        public int MuscleId { get; set; }
    }
}