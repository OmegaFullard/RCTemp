using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RCTemp
{
    [Serializable]
    public class ServiceCartItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal LineTotal
        {
            get { return UnitPrice * Quantity; }
        }
    }

    public static class ServiceCatalog
    {
        public static readonly ServiceCartItem Bronze = new ServiceCartItem
        {
            Code = "bronze",
            Name = "Bronze",
            Description = "5 users included, 20 GB of storage, limited email support.",
            UnitPrice = 100m,
            Quantity = 1
        };

        public static readonly ServiceCartItem Silver = new ServiceCartItem
        {
            Code = "silver",
            Name = "Silver",
            Description = "10 users included, 100 GB of storage, priority email support.",
            UnitPrice = 200m,
            Quantity = 1
        };

        public static readonly ServiceCartItem Gold = new ServiceCartItem
        {
            Code = "gold",
            Name = "Gold",
            Description = "20 users included, unlimited storage, 24/7 support.",
            UnitPrice = 300m,
            Quantity = 1
        };

        public static bool TryGetPlan(string code, out ServiceCartItem plan)
        {
            switch ((code ?? string.Empty).ToLowerInvariant())
            {
                case "bronze":
                    plan = Bronze;
                    return true;
                case "silver":
                    plan = Silver;
                    return true;
                case "gold":
                    plan = Gold;
                    return true;
                default:
                    plan = null;
                    return false;
            }
        }
    }

    public static class ServiceCartManager
    {
        private const string SessionKey = "ServiceCart";

        public static List<ServiceCartItem> GetCart(HttpSessionState session)
        {
            if (session == null)
            {
                return new List<ServiceCartItem>();
            }

            var cart = session[SessionKey] as List<ServiceCartItem>;
            if (cart == null)
            {
                cart = new List<ServiceCartItem>();
                session[SessionKey] = cart;
            }

            return cart;
        }

        public static void AddItem(HttpSessionState session, string code)
        {
            ServiceCartItem plan;
            if (!ServiceCatalog.TryGetPlan(code, out plan))
            {
                return;
            }

            var cart = GetCart(session);
            var existing = cart.FirstOrDefault(x => string.Equals(x.Code, plan.Code, StringComparison.OrdinalIgnoreCase));
            if (existing == null)
            {
                cart.Add(new ServiceCartItem
                {
                    Code = plan.Code,
                    Name = plan.Name,
                    Description = plan.Description,
                    UnitPrice = plan.UnitPrice,
                    Quantity = 1
                });
                return;
            }

            existing.Quantity += 1;
        }

        public static void RemoveOne(HttpSessionState session, string code)
        {
            var cart = GetCart(session);
            var existing = cart.FirstOrDefault(x => string.Equals(x.Code, code, StringComparison.OrdinalIgnoreCase));
            if (existing == null)
            {
                return;
            }

            if (existing.Quantity > 1)
            {
                existing.Quantity -= 1;
                return;
            }

            cart.Remove(existing);
        }

        public static decimal GetTotal(HttpSessionState session)
        {
            return GetCart(session).Sum(x => x.LineTotal);
        }

        public static int GetItemCount(HttpSessionState session)
        {
            return GetCart(session).Sum(x => x.Quantity);
        }

        public static void Clear(HttpSessionState session)
        {
            if (session != null)
            {
                session.Remove(SessionKey);
            }
        }
    }
}
