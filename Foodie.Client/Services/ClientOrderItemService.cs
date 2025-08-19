using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Shared.Services;
using Foodie.Shared.Models;

namespace Foodie.Client.Services
{
    public class ClientOrderItemService : ClientBaseService<ORDER_ITEMS>, IOrderItemService
    {
        // Inherits all base methods from ClientBaseService
        // Additional order item-specific methods can be added here if needed
    }
}
