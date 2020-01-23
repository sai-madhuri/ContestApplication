using ContestApplication.Interfaces;
using ContestApplication.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication.Services
{
    public class ActionService : IActionService
    {
        private IDatabase DB;

        public ActionService(IDatabase db)
        {
            this.DB = db;
        }

        public void AddUser()
        {
            Users user = new Users();
            user.UserName = "Madhuri";
            this.DB.Insert(user);
        }

        public void AddMovie(Movies movie)
        {
            Movies newMovie = new Movies();
            newMovie.MId = movie.MId;
            newMovie.Name = movie.Name;
            newMovie.CoverPhoto = movie.CoverPhoto;
            this.DB.Insert(newMovie);
        }

        public void AddQuestion(string movieName, Questions question)
        {
            Questions newQuestion = new Questions();
            Movies movie = this.DB.FirstOrDefault<Models.Movies>($"where Name = @0 ", movieName);
            newQuestion.MId = movie.MId;
            newQuestion.QId = Guid.NewGuid().ToString();
            newQuestion.Question = question.Question;
            newQuestion.Option1 = question.Option1;
            newQuestion.Option2 = question.Option2;
            newQuestion.Option3 = question.Option3;
            newQuestion.Option4 = question.Option4;
            newQuestion.CorrectOption = question.CorrectOption;
            this.DB.Insert(newQuestion);
        }
    }
}
