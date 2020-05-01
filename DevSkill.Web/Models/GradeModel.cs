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
    public class GradeModel
    {
        [Required]
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal GradeValue { get; set; }

        public IList<object> Students { get; set; }
        public IList<object> Subjects { get; set; }

        private IGradeService _gradeService;

        public GradeModel()
        {
            _gradeService = Startup.AutofacContainer.Resolve<IGradeService>();
        }

        public async Task AddAsync()
        {
            var entity = new Grade { StudentId = this.StudentId, SubjectId = this.SubjectId, GradeValue = this.GradeValue };
            await _gradeService.AddAsync(entity);
        }

        public async Task<IList<Grade>> GetAllAsync()
        {
            return await _gradeService.GetAllAsync();
        }

        public async Task LoadAllAsync()
        {
            this.Students = await _gradeService.GetAllStudentForSelectAsync();
            this.Subjects = await _gradeService.GetAllSubjectForSelectAsync();
        }
    }
}
