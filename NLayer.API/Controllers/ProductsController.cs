using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    //[ApiController]
    public class ProductsController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync(); 
            var productsDtos = _mapper.Map<List<ProductDto>>(products);
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            return CreateActionResult<List<ProductDto>>(CustomResponseDto<List<ProductDto>>.Success(201, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(201, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult<ProductDto>(CustomNoContentResponseDto<ProductDto>.Success(204));
        }
    }
}
