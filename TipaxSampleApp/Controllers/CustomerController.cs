using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TipaxSampleApp.Services.Interfaces;
using TipaxSampleApp.Validators.Interfaces;
using TipaxSampleApp.ViewModels;

namespace TipaxSampleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerModelValidator _validator;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, ICustomerModelValidator validator, IMapper mapper)
        {
            _customerService = customerService;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        /// بازیابی اطللاعات همه مشتریان
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CustomerViewModel>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(_mapper.Map<List<CustomerViewModel>>(customers));
        }

        /// <summary>
        /// بازیابی اطلاعات یک مشتری
        /// </summary>
        /// <param name="id">شناسه مشتری</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerViewModel>> GetCustomerById(int id)
        {
            var customerDto = await _customerService.GetCustomerByIdAsync(id);
            return Ok(_mapper.Map<CustomerViewModel>(customerDto));
        }

        /// <summary>
        /// افزودن مشتری
        /// </summary>
        /// <param name="customerModel">اطلاعات مشتری</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerBindingModel customerModel)
        {
            _validator.ValidateAndThrow(customerModel);
            var customerDto = _mapper.Map<CustomerDto>(customerModel);
            var result = await _customerService.AddCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = result.Id }, result);
        }

        /// <summary>
        /// ویرایش اطلاعات یک مشتری
        /// </summary>
        /// <param name="customerModel">اطلاعات مشتری</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerBindingModel customerModel)
        {
            _validator.ValidateAndThrow(customerModel);
            var updateValidationResult = _validator.Validate(customerModel, options => options.IncludeRuleSets("Update"));
            if (updateValidationResult.IsValid)
            {
                var customerDto = _mapper.Map<CustomerDto>(customerModel);
                await _customerService.UpdateCustomerAsync(customerDto);
                return NoContent();
            }
            return BadRequest(updateValidationResult.Errors);
        }

        /// <summary>
        /// حذف مشتری
        /// </summary>
        /// <param name="id">شناسه مشتری</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}