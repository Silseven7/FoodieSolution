namespace Foodie.Shared.Services;

public interface IServiceBase<TModel> where TModel : class, new()
{
	Task<List<TModel>> GetAllAsync();
	Task<TModel> GetAsync(int id);
	Task<TModel> AddAsync(TModel entity);
	Task<TModel> UpdateAsync(TModel entity);
	Task<TModel> DeleteAsync(TModel entity);
}
