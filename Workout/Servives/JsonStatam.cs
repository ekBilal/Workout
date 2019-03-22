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

        public static ObservableCollection<Muscle> getAllMuscles()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.Muscles.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var muscles = JsonConvert.DeserializeObject<ObservableCollection<Muscle>>(json);
                return new ObservableCollection<Muscle>(muscles.OrderBy(m => m.Nom));
            }
        }

        public static ObservableCollection<Exercice> getAllExercices()
        {
            Stream stream = assembly.GetManifestResourceStream("Workout.Exercices.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var exercices = JsonConvert.DeserializeObject<ObservableCollection<Exercice>>(json);
                return new ObservableCollection<Exercice>(exercices.OrderBy(e => e.Nom));
            }

        }

        public static void Save(object o)
        {
            string json = JsonConvert.SerializeObject(o);
        }
    }
}