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
    public class SubjectModel
    {
        [Required]
        public string Name { get; set; }
        public bool RegistrationOpen { get; set; }

        private ISubjectService _subjectService;

        public SubjectModel()
        {
            _subjectService = Startup.AutofacContainer.Resolve<ISubjectService>();
        }

        public async Task<IList<Subject>> GetAllAsync()
        {
            return await _subjectService.GetAllAsync();
        }

        public async Task AddAsync()
        {
            var entity = new Subject { Name = this.Name, RegistrationOpen = this.RegistrationOpen };
            await _subjectService.AddAsync(entity);
        }
    }
}
