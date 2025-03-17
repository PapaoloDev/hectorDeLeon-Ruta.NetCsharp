using _2.Backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace _2.Backend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<T?> GetById(int id);
        Task<T> Add(TI beerInsertDto);
        Task<T?> Update(int id, TU beerUpdateDto);
        Task<T?> Delete(int id);
        bool Validate(TI dto);
        bool Validate(TU dto);
    }
}
