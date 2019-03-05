using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DIY.NetCore.Data.CRUD.Client.Repository;
using ClientModel = DIY.NetCore.Data.CRUD.Client.Models.Client;

namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all clients.", Type = typeof(IEnumerable<ClientModel>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _clientRepository.GetAllAsync();
            return response.Successful ? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Creates a Client and returns the Id of the new Client", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> CreateAsync(ClientModel client)
        {
            var response = await _clientRepository.CreateAsync(client);
            return response.Successful ? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Updates a client.", Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> UpdateAsync(ClientModel client)
        {
            var response = await _clientRepository.UpdateAsync(client);
            return response.Successful ? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpGet("{Id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a Client by its Id.", Type = typeof(ClientModel))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _clientRepository.GetByIdAsync(id);
            return response.Successful ? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpGet("search")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all Clients that match the specified critera.", Type = typeof(IEnumerable<ClientModel>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> SearchAsync(string property, string condition)
        {
            return BadRequest("This method is not implemented yet");
        }

        [HttpGet("all/inactive")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all inactive clients.", Type = typeof(IEnumerable<ClientModel>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> GetInactiveClientsAsync()
        {
            var response = await _clientRepository.GetInactiveClientsAsync();
            return response.Successful ? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpPatch("deactiveate/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Sets a client to inactive.", Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> DeactivateAsync(int id)
        {
            if (id < 1)
                return BadRequest("the requested Id doesn't exist");

            var response = await _clientRepository.DeactivateAsync(id);
            return response.Successful ? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpPatch("activeate/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Sets a client to active.", Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Returns all clients.", Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(Exception))]
        public async Task<IActionResult> ActivateAsync(int id)
        {
            if (id < 1)
                return BadRequest("the requested Id doesn't exist");

            var response = await _clientRepository.ActivateAsync(id);
            return response.Successful? Ok(response.Result) : new ObjectResult(response.Exception);
        }

        [HttpGet("healthcheck")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(HealthCheckResponse))]
        public async Task<IActionResult> HealthCheck()
        {
            var result = await _clientRepository.HealthCheck();
            return Ok(result);
        }
    }
}
