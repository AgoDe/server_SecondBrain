using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.Dto.RecurringTransaction;
using SecondBrain.Models.Entities;
using SecondBrain.Services;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecurringTransactionController : ControllerBase
    {
        protected ApiResponse _response;
        private RecurringTransactionService _transactionService;
        private IMapper _mapper;
        public RecurringTransactionController(RecurringTransactionService transactionService, IMapper mapper)
        {
            this._response = new();
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetRecurringTransactions([FromQuery]QueryInputModel inputModel)
        {
            try
            {
                IEnumerable<RecurringTransaction> transactions = await _transactionService.GetAllAsync(inputModel);

                _response.Result = _mapper.Map<List<RecurringTransactionIndexDto>>(transactions);
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
        public async Task<ActionResult<ApiResponse>> GetRecurringTransaction(int id)
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

                _response.Result = _mapper.Map<RecurringTransactionDto>(transaction);
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
        public async Task<ActionResult<ApiResponse>> CreateRecurringTransaction([FromBody]RecurringTransactionCreateDto modelDto)
        {
            try
            {

                if (modelDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                RecurringTransaction model = _mapper.Map<RecurringTransaction>(modelDto);

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
    
        [HttpDelete("{id:int}", Name = "DeleteRecurringTransaction")]
        public async Task<ActionResult<ApiResponse>> DeleteRecurringTransaction(int id)
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

        [HttpPut("{id:int}", Name = "UpdateRecurringTransaction")]
        public async Task<ActionResult<ApiResponse>> UpdateRecurringTransaction(int id, [FromBody] RecurringTransactionUpdateDto updateDto)
        {
            try {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                RecurringTransaction model = _mapper.Map<RecurringTransaction>(updateDto);

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