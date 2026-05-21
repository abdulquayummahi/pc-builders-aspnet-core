using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            cfg.CreateMap<Order, OrderDTO>().ReverseMap();
        }, NullLoggerFactory.Instance);

        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}