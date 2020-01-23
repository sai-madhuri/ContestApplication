using ContestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication.Interfaces
{
    public interface IContestService
    {
        Users GetUser(int Id);

        List<Questions> GetQuestions(string MId);

        List<Movies> GetAllMovies();

        void SetContestTaken(int id,string MovieId);

        ContestTaken IsContestTaken(int userId, string MId);
    }
}
