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
    public class StudentRegistrationModel : AdminBaseModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Enroll Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMMM, yyyy}")]
        public DateTime? EnrollDate { get; set; }
        [Required]
        [Display(Name = "Is Payment Complete")]
        public bool IsPaymentComplete { get; set; }

        public IList<object> StudentSelectList { get; set; }
        public IList<object> CourseSelectList { get; set; }

        public IStudentRegistrationService _studentRegistrationService { get; set; }

        public StudentRegistrationModel()
        {
            _studentRegistrationService = Startup.AutofacContainer.Resolve<IStudentRegistrationService>();
        }

        public async Task<object> GetAllAsync(DataTablesAjaxRequestModel tableModel)
        {
            var result = await _studentRegistrationService.GetAllAsync(
                tableModel.SearchText, 
                tableModel.GetSortText(new string[] { "enrollDate", "studentName", "courseTitle" }), 
                tableModel.PageIndex, tableModel.PageSize);

            return new
            {
                recordsTotal = result.Total,
                recordsFiltered = result.TotalDisplay,
                data = (from item in result.Items
                            select new string[]
                            {
                                    item.EnrollDate.ToString("dd MMMM, yyyy"),
                                    item.Student.Name,
                                    item.Course.Title,
                                    item.IsPaymentComplete.ToString(),
                                    item.Id.ToString()
                            }
                        ).ToArray()

            };
        }

        public async Task LoadByIdAsync(int id)
        {
            var result = await _studentRegistrationService.GetByIdAsync(id);
            this.StudentId = result.StudentId;
            this.CourseId = result.CourseId;
            this.EnrollDate = result.EnrollDate;
            this.IsPaymentComplete = result.IsPaymentComplete;
        }

        public async Task LoadAllSelectListAsync()
        {
            this.StudentSelectList = await _studentRegistrationService.GetStudentsForSelectAsync();
            this.CourseSelectList = await _studentRegistrationService.GetCoursesForSelectAsync();
        }

        public async Task AddAsync()
        {
            var entity = new StudentRegistration
            {
                StudentId = this.StudentId,
                CourseId = this.CourseId,
                EnrollDate = this.EnrollDate.Value,
                IsPaymentComplete = this.IsPaymentComplete
            };

            await _studentRegistrationService.AddAsync(entity);
        }

        public async Task UpdateAsync()
        {
            var entity = new StudentRegistration
            {
                Id = this.Id,
                StudentId = this.StudentId,
                CourseId = this.CourseId,
                EnrollDate = this.EnrollDate.Value,
                IsPaymentComplete = this.IsPaymentComplete
            };

            await _studentRegistrationService.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRegistrationService.DeleteAsync(id);
        }
    }
}
