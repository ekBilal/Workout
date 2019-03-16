using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Workout.Models;

namespace Workout.Servives
{
    public class Service
    {

        private SQLiteAsyncConnection _connection;

        public Service()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MyData.db");
            _connection = new SQLiteAsyncConnection(path);

            //_connection = SQLiteDb.Instance.Connection;
            Init();
        }

        private async void Init()
        {
            await _connection.CreateTableAsync<Exercice>();

            //var exercices = JsonStatam.getListExercice();
            //await _connection.InsertAllAsync(exercices);
        }


        public async Task<List<Exercice>> GetExercices()
        {
            var exercices = await _connection.Table<Exercice>().ToListAsync();
            return exercices;
        }

        public async Task<Exercice> AddExercice(Exercice exercice)
        {
            await _connection.InsertAsync(exercice);
            return exercice;
        }

        public async Task<Exercice> UpdateExercice(Exercice exercice)
        {
            exercice.Nom += " MAJ";
            await _connection.UpdateAsync(exercice);
            return exercice;
        }

        public async Task<int> DeleteExercice(Exercice exercice)
        {
            return await _connection.DeleteAsync(exercice);
        }
    }
}
