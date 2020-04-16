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
    public class StudentModel : AdminBaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM, yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        public IStudentService _studentService { get; set; }

        public StudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public async Task<object> GetAllAsync(DataTablesAjaxRequestModel tableModel)
        {
            var result = await _studentService.GetAllAsync(
                tableModel.SearchText, 
                tableModel.GetSortText(new string[] { nameof(Student.Name), nameof(Student.DateOfBirth) }), 
                tableModel.PageIndex, tableModel.PageSize);

            return new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.TotalDisplay,
                data = (from item in result.Items
                            select new string[]
                            {
                                    item.Name,
                                    item.DateOfBirth.ToString("dd MMMM, yyyy"),
                                    item.Id.ToString()
                            }
                        ).ToArray()

            };
        }

        public async Task LoadByIdAsync(int id)
        {
            var result = await _studentService.GetByIdAsync(id);
            this.Id = result.Id;
            this.Name = result.Name;
            this.DateOfBirth = result.DateOfBirth;
        }

        public async Task AddAsync()
        {
            var entity = new Student { Name = this.Name, DateOfBirth = this.DateOfBirth.Value };
            await _studentService.AddAsync(entity);
        }

        public async Task UpdateAsync()
        {
            var entity = new Student { Id = this.Id, Name = this.Name, DateOfBirth = this.DateOfBirth.Value };
            await _studentService.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentService.DeleteAsync(id);
        }
    }
}
