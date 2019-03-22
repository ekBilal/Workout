using System.Collections.ObjectModel;
using SQLite;

namespace Workout.Models
{
    public class Seance
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(255)]
        public string Nom { get; set; }

        public ObservableCollection<Serie> Series { get; set; }

        public override string ToString()
        {
            string msg="";
            foreach(Serie serie in Series)
            {
                msg += serie+ "\n";
            }
            return msg;
        }
    }
}