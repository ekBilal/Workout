using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Workout.Models;

namespace Workout.Servives
{
    public class JsonStatam
    {
        private static Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

        public static IEnumerable<Exercice> getListExercice()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.Exercices.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var exercices = JsonConvert.DeserializeObject<IEnumerable<Exercice>>(json);
                return exercices;
            }
        }

        public static ObservableCollection<Muscle> getMuscles()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.muscles.json");

            //Muscle[] muscles;
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var muscles = JsonConvert.DeserializeObject<ObservableCollection<Muscle>>(json);
                return new ObservableCollection<Muscle>(muscles.OrderBy(m => m.Nom));
            }
        }

        public static ObservableCollection<Muscle> getAllMuscles()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.muscles.json");

            //Muscle[] muscles;
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var muscles = JsonConvert.DeserializeObject<ObservableCollection<Muscle>>(json);
                return muscles;
            }
        }

        public static ObservableCollection<Exercice> getAllExercices()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.Exercices.json");

            //Muscle[] muscles;
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var exercices = JsonConvert.DeserializeObject<ObservableCollection<Exercice>>(json);
                return exercices;
            }

        }

        public static Stack<Exercice> getExercice()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.Exercices.json");

            //Muscle[] muscles;
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var exercices = JsonConvert.DeserializeObject<ObservableCollection<Exercice>>(json);
                return new Stack<Exercice>(exercices.OrderBy(e => e.Nom));
            }

        }

        public static void Save(object o)
        {
            string json = JsonConvert.SerializeObject(o);
        }
    }
}
