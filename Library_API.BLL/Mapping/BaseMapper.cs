using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.Mapping
{
    public class BaseMapper<TSource, TDestination> : Profile
    {
        public BaseMapper()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}
