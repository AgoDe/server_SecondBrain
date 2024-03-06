using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.Dto.Transaction;
using SecondBrain.Models.Entities;
using SecondBrain.Services;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TransactionController : ControllerBase
    {
        protected ApiResponse _response;
        private TransactionService _transactionService;
        private IMapper _mapper;
        public TransactionController(TransactionService transactionService, IMapper mapper)
        {
            this._response = new();
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetTransactions([FromQuery]QueryInputModel query)
        {
            try
            {
                IEnumerable<Transaction> transactions = await _transactionService.GetAllAsync(query);

                _response.Result = _mapper.Map<List<TransactionIndexDto>>(transactions);
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
        public async Task<ActionResult<ApiResponse>> GetTransaction(int id)
        {
            try {

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

                _response.Result = _mapper.Map<TransactionDto>(transaction);
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
        public async Task<ActionResult<ApiResponse>> CreateTransaction([FromBody]TransactionCreateDto modelDto)
        {
            try
            {

                if (modelDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Transaction model = _mapper.Map<Transaction>(modelDto);

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
    
        [HttpDelete("{id:int}", Name = "DeleteTransaction")]
        public async Task<ActionResult<ApiResponse>> DeleteTransaction(int id)
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

        [HttpPut("{id:int}", Name = "UpdateTransaction")]
        public async Task<ActionResult<ApiResponse>> UpdateTransaction(int id, [FromBody] TransactionUpdateDto updateDto)
        {
            try {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Transaction model = _mapper.Map<Transaction>(updateDto);

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