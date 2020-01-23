using ContestApplication.Interfaces;
using ContestApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        public IContestService ContestService;
        public IActionService ActionsService;

        public ContestController(IContestService ContestService, IActionService ActionsService)
        {
            this.ContestService = ContestService;
            this.ActionsService = ActionsService;
        }

        [HttpPost]
        public void Post(int userId, string movieId)
        {
            this.ContestService.SetContestTaken(userId,movieId);
        }

        [HttpGet("{id}")]
        public Users Get(int Id)
        {
            return this.ContestService.GetUser(Id);
        }

        [HttpGet("getMovies")]
        public List<Movies> Get()
        {
            return this.ContestService.GetAllMovies();
        }

        [HttpGet("getQuestions/{MId}")]
        public List<Questions> Get(string MId)
        {
            return this.ContestService.GetQuestions(MId);
        }

        [HttpGet("isContestTaken/{userId}/{movieId}")]

        public ContestTaken Get(int userId,string movieId)
        {
            return this.ContestService.IsContestTaken(userId, movieId);
        }
    }
}
