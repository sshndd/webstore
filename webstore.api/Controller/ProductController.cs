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
        public async Task<ActionResult<ServerResponse>> GetProducts()
        {
            return Ok(new ServerResponse
            {
                IsSucess = true,
                StatusCode = HttpStatusCode.OK,
                Result = await dbContext.Products.ToListAsync()
            });
        }

        [HttpGet("{id}", Name = nameof(GetProductById))]
        public async Task<ActionResult<ServerResponse>> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ServerResponse
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Неверный id" }
                });
            }

            var productFromDb = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (productFromDb == null)
            {
                return NotFound(new ServerResponse
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = { "Элемент не найден" }
                });
            }
            else
            {
                return Ok(new ServerResponse
                {
                    IsSucess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = productFromDb
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
                            IsSucess = false,
                            StatusCode = HttpStatusCode.BadRequest,
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
        [HttpPut ("{id}")]
        public async Task<ActionResult<ServerResponse>> UpdateProduct(int id, [FromBody] ProductUpdateDTO productUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productUpdateDTO == null || productUpdateDTO.Id != id)
                    {
                        return BadRequest(new ServerResponse
                        {
                            IsSucess = false,
                            StatusCode= HttpStatusCode.BadRequest,
                            ErrorMessages = {"Несоответствие модели данных"}
                        });
                    }
                    else
                    {
                        Product productFromDb = await dbContext.Products.FindAsync(id);
                        
                        if (productFromDb == null)
                        {
                            return NotFound(new ServerResponse
                            {
                                IsSucess = false,
                                StatusCode = HttpStatusCode.NotFound,
                                ErrorMessages = {"Продукт не найден"}
                            });
                        }
                        productFromDb.Name = productUpdateDTO.Name;
                        productFromDb.Description = productUpdateDTO.Description;
                        productFromDb.SpecialTag = productUpdateDTO.SpecialTag;
                        productFromDb.Category = productUpdateDTO.Category;
                        productFromDb.Price = productUpdateDTO.Price;

                        if (productUpdateDTO.Image != null && productUpdateDTO.Image.Length > 0)
                        {
                            productFromDb.Image = $"https://placehold.co/300";
                        }

                        dbContext.Products.Update(productFromDb);
                        await dbContext.SaveChangesAsync();

                        return Ok(new ServerResponse
                        {
                            IsSucess = true,
                            StatusCode = HttpStatusCode.OK,
                            Result = productFromDb
                        });
                    }
                }
                else
                {
                    return BadRequest(new ServerResponse
                    {
                        IsSucess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = { "Модель не соответствует" }
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

        [HttpDelete ("{id}")]
        public async Task<ActionResult<ServerResponse>> RemoveProductById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new ServerResponse
                    {
                        IsSucess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = { "Неверный id" }
                    });
                }

                Product productFromDb = await dbContext.Products.FindAsync(id);

                if (productFromDb == null)
                {
                    return NotFound(new ServerResponse
                    {
                        IsSucess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessages = { "Элемент не найден" }
                    });
                }

                dbContext.Products.Remove(productFromDb);
                await dbContext.SaveChangesAsync();

                return Ok(new ServerResponse
                {
                    IsSucess = true,
                    StatusCode= HttpStatusCode.NoContent
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Что то пошло не так", ex.Message }
                });

            }
        }
    }
}
