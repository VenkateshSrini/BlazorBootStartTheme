using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyComp.KPortal.Server.Configuration;
using MyComp.KPortal.Shared;

namespace MyComp.KPortal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILogger<LearningController> logger;
        private readonly LearningDetails learningDetails;
        public LearningController(ILogger<LearningController> logger,
            IOptions<LearningDetails> learningDetails)
        {
            this.logger = logger;
            this.learningDetails = learningDetails?.Value;
        }
        [HttpGet]
        public LearningResponse Get()
        {
            LearningResponse response = new LearningResponse
            {
                UserName = User.Identity.Name,
                Learnings = learningDetails?.Learnings
            };
            return response;
        }
    }
}
