using Microsoft.EntityFrameworkCore;
using Foodie.API.Data;
using Foodie.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.API.Services;

public class ServiceBase<TModel> : ControllerBase, IServiceBase<TModel> where TModel : class, new()
{
	protected readonly FoodieDbContext _context;

	public ServiceBase(FoodieDbContext context)
	{
		_context = context;
	}

	[HttpPost(nameof(AddAsync))]
	public virtual async Task<TModel> AddAsync(TModel entity)
	{
		await _context.Set<TModel>().AddAsync(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	[HttpPost(nameof(DeleteAsync))]
	public virtual async Task<TModel> DeleteAsync(TModel entity)
	{
		_context.Set<TModel>().Remove(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	[HttpPost(nameof(GetAllAsync))]
	public virtual async Task<List<TModel>> GetAllAsync()
	{
		return await _context.Set<TModel>().AsNoTracking().ToListAsync();
	}

	[HttpPost(nameof(GetAsync))]
	public virtual async Task<TModel> GetAsync(int id)
	{
		return (await _context.Set<TModel>().FindAsync(id))!;
	}

	[HttpPost(nameof(UpdateAsync))]
	public virtual async Task<TModel> UpdateAsync(TModel entity)
	{
		_context.Set<TModel>().Update(entity);
		await _context.SaveChangesAsync();
		return entity;
	}
}
