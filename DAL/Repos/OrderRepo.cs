using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class OrderRepo(PcBuildersDbContext dbContext)
    {
        public bool Create(Order order)
        {
            dbContext.Orders.Add(order);
            return dbContext.SaveChanges() > 0;
        }

        public Order? Get(int id)
        {
            return dbContext.Orders.Find(id);
        }

        public List<Order> Get()
        {
            return dbContext.Orders.ToList();
        }

        public bool Update(Order order)
        {
            dbContext.Entry(Get(order.Id)).CurrentValues.SetValues(order);
            return dbContext.SaveChanges() > 0;
        }
    }
}