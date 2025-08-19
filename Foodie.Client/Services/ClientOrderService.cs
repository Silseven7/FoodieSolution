using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Shared.Services;
using Foodie.Shared.Models;

namespace Foodie.Client.Services
{
    public class ClientOrderService : ClientBaseService<ORDER>, IOrderService
    {
        // Inherits all base methods from ClientBaseService
        // Additional order-specific methods can be added here if needed
    }
}
