using ContestApplication.Interfaces;
using ContestApplication.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication.Services
{
    public class ContestService : IContestService
    {
        private IDatabase DB;

        public ContestService(IDatabase db)
        {
            this.DB = db;
        }

        public ContestTaken IsContestTaken(int userId, string MId)
        {
            ContestTaken taken = this.DB.FirstOrDefault<Models.ContestTaken>($"where UserId=@0 and MId=@1", userId, MId);
            return taken;
        }

        public Users GetUser(int Id)
        {
            return this.DB.FirstOrDefault<Models.Users>($"where UserId=@0", Id);
        }

        public List<Questions> GetQuestions(string MId)
        {
            List<Questions> questions = this.DB.Fetch<Models.Questions>($"where MId=@0", MId);
            return questions;
        }

        public List<Movies> GetAllMovies()
        {
            return this.DB.Fetch<Models.Movies>();
        }

        public void SetContestTaken(int id,string movieId)
        {
            ContestTaken contestTakenBy = new ContestTaken()
            {
                UserId = id,
                MId = movieId
            };
            this.DB.Insert(contestTakenBy);
        }
    }
}
