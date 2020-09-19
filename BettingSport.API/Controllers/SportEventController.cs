using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using FluentValidation;
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
        private readonly AbstractValidator<SportEvent> validator;
        public SportEventController(
            IRepository<SportEvent> repository,
            IAsyncReadonlyRepository<SportEvent> readonlyRepository,
            IAsyncUnitOfWork unitOfWork,
            AbstractValidator<SportEvent> validator
            )
        {
            this.repository = repository;
            this.readonlyRepository = readonlyRepository;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
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
            sportEvent = repository.Add(sportEvent);
            await unitOfWork.CommitChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = sportEvent.Id }, sportEvent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SportEvent>> Update(int id, SportEvent sportEvent)
        {
            if (id != sportEvent.Id)
                return BadRequest("Id mismatch");
            var result = validator.Validate(sportEvent);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

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
