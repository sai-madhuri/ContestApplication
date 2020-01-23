using ContestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication.Interfaces
{
    public interface IActionService
    {
        void AddUser();

        void AddMovie(Movies movie);

        void AddQuestion(string movieName, Questions Question);
    }
}
