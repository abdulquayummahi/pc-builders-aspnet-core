using DAL.EF;
using DAL.EF.Tables;

namespace DAL.Repos
{
    public class ProductRepo(PcBuildersDbContext dbContext)
    {
        public bool Create(Product product)
        {
            dbContext.Products.Add(product);
            return dbContext.SaveChanges() > 0;
        }

        public Product? Get(int id)
        {
            return dbContext.Products.Find(id);
        }

        public List<Product> Get()
        {
            return dbContext.Products.ToList();
        }

        public bool Update(Product product)
        {
            dbContext.Entry(Get(product.Id)).CurrentValues.SetValues(product);
            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            dbContext.Products.Remove(Get(id));
            return dbContext.SaveChanges() > 0;
        }
    }
}