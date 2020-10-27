using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExxerProject.Scheduler.Data.DataAccess;
using ExxerProject.Scheduler.Core.Entities;

namespace ExxerProject.Web.Areas.Scheduler.Services
{
    public interface IService
    {
        IMapper Mapper { get; set; }

        /// <summary>
        /// Gets or Sets the Scheduler work context.
        /// </summary>
        ISchedulerWorkData SchedulerWorkData { get; set; }
        
        /// <summary>
        /// Asynchronous method that creates Collection of Project as options for drop-down lists.
        /// </summary>
        /// <returns><see cref="List{T}"/> where {T} is <see cref="SelectListItem"/> with 
        /// value the <see cref="ProjectViewModel.Id"/> and text <see cref="ProjectViewModel.ShortName"/></returns>
        Task<List<SelectListItem>> GetProjectOptions();

        /// <summary>
        /// Asynchronous method that creates Collection of Employees as options for drop-down lists.
        /// </summary>
        /// <returns><see cref="List{T}"/> where {T} is <see cref="SelectListItem"/> with 
        /// value the <see cref="EmployeeConciseViewModel.Id"/> and text <see cref="EmployeeConciseViewModel.ToString()"/></returns>
        Task<List<SelectListItem>> GetEmployeeOptions();
    }
}
