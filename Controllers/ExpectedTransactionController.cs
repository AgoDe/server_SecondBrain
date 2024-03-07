using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.Dto.ExpectedTransaction;
using SecondBrain.Models.Entities;
using SecondBrain.Services;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ExpectedTransactionController : ControllerBase
    {
        protected ApiResponse _response;
        private ExpectedTransactionService _transactionService;
        private IMapper _mapper;
        public ExpectedTransactionController(ExpectedTransactionService transactionService, IMapper mapper)
        {
            this._response = new();
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetExpectedTransactions([FromQuery]QueryInputModel inputModel)
        {
            try
            {
                IEnumerable<ExpectedTransaction> transactions = await _transactionService.GetAllAsync(inputModel);

                _response.Result = _mapper.Map<List<ExpectedTransactionIndexDto>>(transactions);
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
        public async Task<ActionResult<ApiResponse>> GetExpectedTransaction(int id)
        {
            try {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var transaction = await _transactionService.GetAsync(id);
                if (transaction == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<ExpectedTransactionDto>(transaction);
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
        public async Task<ActionResult<ApiResponse>> CreateExpectedTransaction([FromBody]ExpectedTransactionCreateDto modelDto)
        {
            try
            {

                if (modelDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                ExpectedTransaction model = _mapper.Map<ExpectedTransaction>(modelDto);

                await _transactionService.CreateAsync(model);
                
                
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
    
        [HttpDelete("{id:int}", Name = "DeleteExpectedTransaction")]
        public async Task<ActionResult<ApiResponse>> DeleteExpectedTransaction(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var transaction = await _transactionService.GetAsync(q => q.Id == id);
                if (transaction == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                await _transactionService.RemoveAsync(transaction);
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

        [HttpPut("{id:int}", Name = "UpdateExpectedTransaction")]
        public async Task<ActionResult<ApiResponse>> UpdateExpectedTransaction(int id, [FromBody] ExpectedTransactionUpdateDto updateDto)
        {
            try {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                ExpectedTransaction model = _mapper.Map<ExpectedTransaction>(updateDto);

                await _transactionService.UpdateAsync(model);

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