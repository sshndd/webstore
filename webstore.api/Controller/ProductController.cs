﻿using Microsoft.AspNetCore.Mvc;

namespace webstore.api.Controller
{
    public class ProductController : StoreController
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return Ok(await Task.FromResult<string>("HelloWorld"));
        }
    }
}
