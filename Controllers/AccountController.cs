using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.Dto.Account;
using SecondBrain.Models.Entities;
using SecondBrain.Services;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountController : ControllerBase
    {
        protected ApiResponse _response;
        private AccountService _accountService;
        private IMapper _mapper;
        public AccountController(AccountService accountService, IMapper mapper)
        {
            this._response = new();
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAccounts()
        {
            try
            {
                IEnumerable<Account> accounts = await _accountService.GetAllAsync();

                _response.Result = _mapper.Map<List<AccountIndexDto>>(accounts);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetAccount(int id)
        {
            try {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var account = await _accountService.GetAsync(q => q.Id == id, includeProperties: new string[] {"User"});
                if (account == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<AccountDto>(account);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateAccount([FromBody]AccountCreateDto modelDto)
        {
            try
            {

                if (modelDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Account model = _mapper.Map<Account>(modelDto);

                await _accountService.CreateAsync(model);
                
                
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                
                //return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }
    
        [HttpDelete("{id:int}", Name = "DeleteAccount")]
        public async Task<ActionResult<ApiResponse>> DeleteAccount(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var account = await _accountService.GetAsync(q => q.Id == id);
                if (account == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                await _accountService.RemoveAsync(account);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateAccount")]
        public async Task<ActionResult<ApiResponse>> UpdateAccount(int id, [FromBody] AccountUpdateDto updateDto)
        {
            try {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Account model = _mapper.Map<Account>(updateDto);

                await _accountService.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }


    
    }

}