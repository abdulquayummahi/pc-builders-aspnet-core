using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class OrderService(OrderRepo orderRepo)
    {
        Mapper mapper = MapperConfig.GetMapper();

        public bool Create(OrderDTO order)
        {
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            var mapped = mapper.Map<Order>(order);
            return orderRepo.Create(mapped);
        }

        public List<OrderDTO> Get()
        {
            return mapper.Map<List<OrderDTO>>(orderRepo.Get());
        }

        public OrderDTO? Get(int id)
        {
            return mapper.Map<OrderDTO>(orderRepo.Get(id));
        }

        public bool Update(OrderDTO order)
        {
            return orderRepo.Update(mapper.Map<Order>(order));
        }
    }
}