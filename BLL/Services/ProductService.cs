using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class ProductService (ProductRepo productRepo)
    {
        Mapper mapper = MapperConfig.GetMapper();

        public bool Create(ProductDTO product)
        {
            return productRepo.Create(mapper.Map<Product>(product));
        }

        public List<ProductDTO> Get()
        {
            return mapper.Map<List<ProductDTO>>(productRepo.Get());
        }

        public ProductDTO? Update(int id)
        {
            return mapper.Map<ProductDTO>(productRepo.Get(id));
        }

        public bool Update(ProductDTO product)
        {
            return productRepo.Update(mapper.Map<Product>(product));
        }

        public bool Delete(int id)
        {
            return productRepo.Delete(id);
        }
    }
}
