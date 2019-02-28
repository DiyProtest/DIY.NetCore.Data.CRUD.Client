using System;
using System.Collections.Generic;
using Dapper;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using DIY.NetCore.Data.CRUD.Client.Repository;
using System.Net.Http.Headers;

namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRepository;

        public ClientController(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.OK, Description = "Returns all clients.", Type = typeof(IEnumerable<Client>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{Id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns a Client by its Id.", Type = typeof(Client))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all Clients that match the specified critera.", Type = typeof(IEnumerable<Client>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> SearchAsync(string property, string condition)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Creates a Client and returns the Id of the new Client", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> CreateAsync(Client client)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Updates a client.", Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{Id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all clients.", Type = typeof(Client))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> GetInactiveClientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all clients.", Type = typeof(IEnumerable<Client>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> GetInactiveClientsAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all clients.", Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns all clients.", Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Returns all clients.", Type = typeof(string))]
[SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An internal error has occured", Type = typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> ActivateAsync(int id)
        {
            if (id < 1)
                return BadRequest("the requested Id doesn't exist");

            return null;
        }

        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.OK, type:typeof(HealthCheckResponse))]
        [SwaggerResponse((int) HttpStatusCode.InternalServerError, type: typeof(InternalServerErrorResponse))]
        public async Task<IActionResult> HealthCheck()
        {
        try
            {
                var result = await _clientRepository.HealthCheck();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var data = new InternalServerErrorResponse
                {
                    Exception = ex
                };
                return new ObjectResult(data);
            }
        }
    }
}
