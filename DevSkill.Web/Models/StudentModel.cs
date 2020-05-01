using Autofac;
using DevSkill.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Web.Models
{
    public class StudentModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        private IStudentService _studentService;

        public StudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            return await _studentService.GetAllAsync();
        }

        public async Task AddAsync()
        {
            var entity = new Student { Name = this.Name, UserName = this.UserName, Email = this.Email };
            await _studentService.AddAsync(entity);
        }
    }
}
