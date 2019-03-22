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

        private SQLiteConnection db;

        private Service()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "Workout.db");

            db = new SQLiteConnection(path);

            db.DropTable<Exercice>();
            db.DropTable<Muscle>();
            db.DropTable<ExerciceMuscle>();
            db.DropTable<Historique>();

            db.CreateTable<Exercice>();
            db.CreateTable<Muscle>();
            db.CreateTable<ExerciceMuscle>();
            db.CreateTable<Historique>();

            var allMuscles = db.GetAllWithChildren<Muscle>();
            if (allMuscles.Count <= 0) 
                PeuplerMuscle();

            var allExercices = db.GetAllWithChildren<Exercice>();
            if (allExercices.Count <= 0) 
                PeuplerExercice();

        }

        private void PeuplerMuscle()
        {
            var muscles = JsonStatam.getAllMuscles();
            foreach(Muscle muscle in muscles)
            {
                var m = AddMuscle(muscle);
            }
        }

        private void PeuplerExercice()
        {
            var exercices = JsonStatam.getAllExercices();
            db.InsertAllWithChildren(exercices);
        }

        public Exercice AddExercice(Exercice exercice)
        {
            db.Insert(exercice);
            return exercice;
        }

        public Exercice UpdateExercice(Exercice exercice)
        {
            db.UpdateWithChildren(exercice);
            return exercice;
        }

        public Historique SaveHistorique(Historique historique)
        {
            db.InsertWithChildren(historique);
            return historique;
        }

        public Muscle AddMuscle(Muscle muscle)
        {
            db.Insert(muscle);
            return muscle;
        }

        public ObservableCollection<Muscle> AllMuscles()
        {
            var muscles = db.GetAllWithChildren<Muscle>();
            return new ObservableCollection<Muscle>(muscles.OrderBy(m => m.Nom));
        }

        public ObservableCollection<Exercice> AllExercices()
        {
            var exercices = db.GetAllWithChildren<Exercice>();
            return new ObservableCollection<Exercice>(exercices.OrderBy(m => m.Nom));
        }

    }
}
