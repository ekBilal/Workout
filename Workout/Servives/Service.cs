using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using SQLite;
using SQLiteNetExtensions.Extensions;

using Workout.Models;

namespace Workout.Servives
{
    public class Service
    {

        private static Service instance = null;
        public static Service Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Service();
                }
                return instance;
            }
        }

        private SQLiteConnection _db;

        public Service()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "Workout.db");
            _db = new SQLiteConnection(path);
            _db.DropTable<Exercice>();
            _db.DropTable<Muscle>();
            _db.DropTable<ExerciceMuscle>();
            _db.DropTable<Historique>();
            _db.CreateTable<Exercice>();
            _db.CreateTable<Muscle>();
            _db.CreateTable<ExerciceMuscle>();
            _db.CreateTable<Historique>();

            if (!getAllMuscles().Any())
                PeuplerMuscles();

            if (!getAllExercices().Any())
                PeuplerExercices();
        }

        public ObservableCollection<Muscle> getAllMuscles()
        {
            var muscles = _db.GetAllWithChildren<Muscle>().OrderBy(m => m.Nom);
            return new ObservableCollection<Muscle>(muscles);
        }

        public ObservableCollection<Exercice> getAllExercices()
        {
            var exercices = _db.GetAllWithChildren<Exercice>().OrderBy(e => e.Nom);
            return new ObservableCollection<Exercice>(exercices);
        }

        public void Update(object o)
        {
            _db.UpdateWithChildren(o);
        }

        public void Insert(object o)
        {
            _db.InsertWithChildren(o);
        }

        public void PeuplerMuscles()
        {
            var muscles = JsonStatam.getAllMuscles();
            _db.InsertAllWithChildren(muscles);
        }

        public void PeuplerExercices()
        {
            var exercices = JsonStatam.getAllExercices();
            _db.InsertAllWithChildren(exercices);
        }
    }
}
