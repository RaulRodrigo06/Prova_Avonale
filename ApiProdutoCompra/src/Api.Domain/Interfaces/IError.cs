using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IError
    {
        List<ErrorMessage> ErrorMessages { get; set; }
    }
}
