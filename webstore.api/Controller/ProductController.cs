using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using webstore.api.Data;
using webstore.api.Model;
using webstore.api.ModelDTO;

namespace webstore.api.Controller
{
    public class ProductController : StoreController
    {
        public ProductController(AppDbContext dbContext) : base(dbContext)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(new ServerResponse
            {
                StatusCode = HttpStatusCode.OK,
                Result = await dbContext.Products.ToListAsync()
            });
        }

        [HttpGet("{id}", Name = nameof(GetProductById))]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest(new ServerResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    IsSucess = false,
                    ErrorMessages = { "Неверный id" }
                });

            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound(new ServerResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    IsSucess = false,
                    ErrorMessages = { "Элемент не найден" }
                });
            }
            else
            {
                return Ok(new ServerResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = product
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse>> CreateProduct(
            [FromBody] ProductCreateDTO productCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productCreateDTO.Image == null || productCreateDTO.Image.Length == 0)
                    {
                        return BadRequest(new ServerResponse
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            IsSucess = false,
                            ErrorMessages = { "Image не может быть пустым" }
                        });
                    }
                    else
                    {
                        Product item = new()
                        {
                            Name = productCreateDTO.Name,
                            Description = productCreateDTO.Description,
                            SpecialTag = productCreateDTO.SpecialTag,
                            Category = productCreateDTO.Category,
                            Price = productCreateDTO.Price,
                            Image = $"https://placehold.co/250",
                        };
                        await dbContext.Products.AddAsync(item);
                        await dbContext.SaveChangesAsync();

                        ServerResponse response = new()
                        {
                            StatusCode = HttpStatusCode.Created,
                            Result = item
                        };

                        return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, response);
                    }
                }
                else
                {
                    return BadRequest(new ServerResponse
                    {
                        IsSucess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = { "Модель данных не подходит" }
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Что-то пошло не так", ex.Message }
                });
            }
        }
    }
}
