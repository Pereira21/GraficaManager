using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
