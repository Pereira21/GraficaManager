using AutoMapper;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotificator _notificator;

        public BaseController(IMapper mapper, INotificator notificator)
        {
            _mapper = mapper;
            _notificator = notificator;
        }

        public bool OperacaoValida()
        {
            return !_notificator.HasNotification();
        }
    }
}
