using APIIO.Api.ViewModels;
using APIIO.Business.Models;
using AutoMapper;

namespace APIIO.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
