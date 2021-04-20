using AutoMapper;
using DevIO.App.Models;
using DevIO.Business.Models;

namespace DevIO.App.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
        }
    }
}
