using _2.Backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace _2.Backend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI beerInsertDto);
        Task<T> Update(int id, TU beerUpdateDto);
        Task<T> Delete(int id);
    }
}
