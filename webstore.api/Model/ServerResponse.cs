﻿using System.Net;

namespace webstore.api.Model
{
    public class ServerResponse
    {
        public ServerResponse() 
        {
            ErrorMessages = new();
        }
        public bool IsSucess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
