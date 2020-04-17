using Autofac;
using DevSkill.Training.Entities;
using DevSkill.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Web.Areas.Admin.Models
{
    public class CourseModel : AdminBaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Seat Count")]
        public int? SeatCount { get; set; }
        [Required]
        public int? Fee { get; set; }

        public ICourseService _courseService { get; set; }

        public CourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        public async Task<object> GetAllAsync(DataTablesAjaxRequestModel tableModel)
        {
            var result = await _courseService.GetAllAsync(
                tableModel.SearchText, 
                tableModel.GetSortText(new string[] { "title", "seatCount", "fee" }), 
                tableModel.PageIndex, tableModel.PageSize);

            return new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.TotalDisplay,
                data = (from item in result.Items
                            select new string[]
                            {
                                    item.Title,
                                    item.SeatCount.ToString(),
                                    item.Fee.ToString(),
                                    item.Id.ToString()
                            }
                        ).ToArray()

            };
        }

        public async Task LoadByIdAsync(int id)
        {
            var result = await _courseService.GetByIdAsync(id);
            this.Id = result.Id;
            this.Title = result.Title;
            this.SeatCount = result.SeatCount;
            this.Fee = result.Fee;
        }

        public async Task AddAsync()
        {
            var entity = new Course { Title = this.Title, SeatCount = this.SeatCount.Value, Fee = this.Fee.Value };
            await _courseService.AddAsync(entity);
        }

        public async Task UpdateAsync()
        {
            var entity = new Course { Id = this.Id, Title = this.Title, SeatCount = this.SeatCount.Value, Fee = this.Fee.Value };
            await _courseService.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _courseService.DeleteAsync(id);
        }
    }
}
