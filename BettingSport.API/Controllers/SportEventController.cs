using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BettingSport.API.Controllers
{
    // https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio
    [Route("api/[controller]")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly IRepository<SportEvent> repository;
        private readonly IAsyncReadonlyRepository<SportEvent> readonlyRepository;
        private readonly IAsyncUnitOfWork unitOfWork;
        public SportEventController(
            IRepository<SportEvent> repository,
            IAsyncReadonlyRepository<SportEvent> readonlyRepository,
            IAsyncUnitOfWork unitOfWork
            )
        {
            this.repository = repository;
            this.readonlyRepository = readonlyRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportEvent>>> GetAll()
        {
            var events = await readonlyRepository.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SportEvent>> Get(int id)
        {
            var _event = await readonlyRepository.GetAsync(id);
            if(_event == null)
            {
                return NotFound();
            }
            return Ok(_event);
        }

        [HttpPost]
        public async Task<ActionResult<SportEvent>> Create(SportEvent sportEvent)
        {
            sportEvent.StartDate = DateTime.UtcNow;
            sportEvent = repository.Add(sportEvent);
            await unitOfWork.CommitChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = sportEvent.Id }, sportEvent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SportEvent>> Update(int id, SportEvent sportEvent)
        {
            if (id != sportEvent.Id)
                return BadRequest();

            repository.Update(sportEvent);
            await unitOfWork.CommitChangesAsync();

            // Choosing OK (200) over NoConten (204) in order to retrieve the entity in the response 
            return Ok(sportEvent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SportEvent>> Delete(int id)
        {
            var _event = await readonlyRepository.GetAsync(id);

            if(_event == null)
            {
                return NotFound();
            }
            repository.Delete(_event);
            await unitOfWork.CommitChangesAsync();
            return NoContent();
        }

    }
}
