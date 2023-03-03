using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PuzzleSolver.Models;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MongoDBService : IDataBaseService<int>
    {
        private IMongoCollection<PuzzleModel<int>> PuzzleCollection { get; }
        public MongoDBService(IOptions<MongodbModelSettings> settings)
        {
            var mongodClient = new MongoClient(settings.Value.ConnectionString);
            var mongodDB = mongodClient.GetDatabase(settings.Value.DatabaseName);
            PuzzleCollection = mongodDB.GetCollection<PuzzleModel<int>>(settings.Value.CollectionName);
        }

        public MongoDBService(IMongoCollection<PuzzleModel<int>> puzzleCollection)
        {
            PuzzleCollection = puzzleCollection;
        }

        public async Task<PuzzleModel<int>> GetPuzzleAsync(int id)
        {
            return await PuzzleCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreatePuzzle(PuzzleModel<int> puzzle)
        {
            await PuzzleCollection.InsertOneAsync(puzzle);
        }
    }
}
