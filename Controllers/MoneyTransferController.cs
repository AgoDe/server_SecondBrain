using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Models;
using SecondBrain.Models.Dto.MoneyTransfer;
using SecondBrain.Models.Entities;
using SecondBrain.Services;

namespace SecondBrain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MoneyTransferController : ControllerBase
    {
        protected ApiResponse _response;
        private MoneyTransferService _transferService;
        private IMapper _mapper;
        public MoneyTransferController(MoneyTransferService transferService, IMapper mapper)
        {
            this._response = new();
            _transferService = transferService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetMoneyTransfers([FromQuery]QueryInputModel inputModel)
        {
            try
            {
                IEnumerable<MoneyTransfer> transfers = await _transferService.GetAllAsync(inputModel);

                _response.Result = _mapper.Map<List<MoneyTransferIndexDto>>(transfers);
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
        public async Task<ActionResult<ApiResponse>> GetMoneyTransfer(int id)
        {
            try {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var transfer = await _transferService.GetAsync(id);
                if (transfer == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<MoneyTransferDto>(transfer);
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
        public async Task<ActionResult<ApiResponse>> CreateMoneyTransfer([FromBody]MoneyTransferCreateDto modelDto)
        {
            try
            {

                if (modelDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                MoneyTransfer model = _mapper.Map<MoneyTransfer>(modelDto);

                await _transferService.CreateAsync(model);
                
                
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
    
        [HttpDelete("{id:int}", Name = "DeleteMoneyTransfer")]
        public async Task<ActionResult<ApiResponse>> DeleteMoneyTransfer(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var transfer = await _transferService.GetAsync(q => q.Id == id);
                if (transfer == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                await _transferService.RemoveAsync(transfer);
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

        [HttpPut("{id:int}", Name = "UpdateMoneyTransfer")]
        public async Task<ActionResult<ApiResponse>> UpdateMoneyTransfer(int id, [FromBody] MoneyTransferUpdateDto updateDto)
        {
            try {
                if (updateDto == null || id != updateDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                MoneyTransfer model = _mapper.Map<MoneyTransfer>(updateDto);

                await _transferService.UpdateAsync(model);

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