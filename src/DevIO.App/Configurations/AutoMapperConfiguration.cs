using AutoMapper;
using DevIO.App.Models.ClienteViewModel;
using DevIO.Business.Models;

namespace DevIO.App.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateClienteViewModel, Cliente>();
            CreateMap<EditClienteViewModel, Cliente>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
