using System.Collections.ObjectModel;
using SQLite;

namespace Workout.Models
{
    public class Entrainement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique, MaxLength(255)]
        public string Nom { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Seance> Seances { get; set; }

        public override string ToString()
        {
            string msg = "";
            foreach(Seance seance in Seances)
            {
                msg += seance.Nom;
            }
            return msg;
        }
    }
}