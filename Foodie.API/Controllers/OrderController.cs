using Microsoft.AspNetCore.Mvc;
using Foodie.Shared.Models;
using Foodie.Shared.Services;
using Foodie.API.Services;
using Foodie.API.Data;

namespace Foodie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ServiceBase<ORDER>, IOrderService
{
	public OrderController(FoodieDbContext context) : base(context)
	{
	}
}
