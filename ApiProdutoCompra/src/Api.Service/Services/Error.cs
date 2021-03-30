using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Service.Services
{
    public class Error : IError
    {
        public List<ErrorMessage> ErrorMessages { get; set; }

        public Error()
        {
            ErrorMessages = new List<ErrorMessage>();
        }
    }
}
