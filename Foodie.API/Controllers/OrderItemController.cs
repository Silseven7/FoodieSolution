using Microsoft.AspNetCore.Mvc;
using Foodie.Shared.Models;
using Foodie.Shared.Services;
using Foodie.API.Services;
using Foodie.API.Data;

namespace Foodie.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ServiceBase<ORDER_ITEMS>, IOrderItemService
{
	public OrderItemController(FoodieDbContext context) : base(context)
	{
	}
}
