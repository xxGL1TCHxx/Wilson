using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExxerProject.Scheduler.Data.DataAccess;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Areas.Scheduler.Controllers
{
    [Area(Constants.Areas.Scheduler)]
    [Authorize]
    public class SchedulerBaseController : Controller
    {
        public SchedulerBaseController(ISchedulerWorkData schedulerWorkData, IMapper mapper, IEventsFactory eventsFactory)
        {
            this.SchedulerWorkData = schedulerWorkData;
            this.Mapper = mapper;
            this.EventsFactory = eventsFactory;
        }

        public ISchedulerWorkData SchedulerWorkData { get; set; }

        public IMapper Mapper { get; set; }

        public IEventsFactory EventsFactory { get; set; }
    }
}
