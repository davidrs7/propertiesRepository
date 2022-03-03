using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using properties.core.interfaces;
using properties.core.entities;
using properties.core.DTO;
using System.Linq;
using AutoMapper;
using properties.api.Response;

namespace properties.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class propertyController : ControllerBase
    {

        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        public propertyController(IPropertyService propertyService, IMapper mapper) {
            _propertyService = propertyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getPorperties()
        {
            var properties = await _propertyService.getProperties();
            var propertiesDto = _mapper.Map<IEnumerable<PropertyDto>>(properties);
            var response = new Responses<IEnumerable<PropertyDto>>(propertiesDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPorperty(int id)
        {
            var property = await _propertyService.getProperty(id);
            var propertyDto = _mapper.Map<PropertyDto>(property);
            var response = new Responses<PropertyDto>(propertyDto);
            return Ok(propertyDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostPorperty(PropertyDto PropertyDto )
        {
            var property = _mapper.Map<Property>(PropertyDto);
            await _propertyService.postProperty(property);
            var propertydto = _mapper.Map<PropertyDto>(property);
            var response = new Responses<PropertyDto>(propertydto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPorperty(int id, PropertyDto PropertyDto)
        {
            var property = _mapper.Map<Property>(PropertyDto);
            property.IdProperty = id;
            var result = await _propertyService.PutPorperty(property);
            var response = new Responses<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePorperty(int id)
        { 
            var result = await _propertyService.deletePorperty(id);
            var response = new Responses<bool>(result);
            return Ok(response);
        }

    }
}
