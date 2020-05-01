using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class GradeService : IGradeService
    {
        private readonly ICourseUnitOfWork courseUnitOfWork;

        public GradeService(ICourseUnitOfWork courseUnitOfWork)
        {
            this.courseUnitOfWork = courseUnitOfWork;
        }

        public async Task<IList<Grade>> GetAllAsync()
        {
            return await this.courseUnitOfWork.GradeRepository.GetAsync(x => x, null, null,
                x => x.Include(y => y.Student).Include(y => y.Subject), true);
        }

        public async Task<IList<object>> GetAllStudentForSelectAsync()
        {
            return await this.courseUnitOfWork.StudentRepository.GetAsync<object>(x => new { Value = x.Id, Text = x.Name }, 
                null, null, null, true);
        }

        public async Task<IList<object>> GetAllSubjectForSelectAsync()
        {
            return await this.courseUnitOfWork.SubjectRepository.GetAsync<object>(x => new { Value = x.Id, Text = x.Name },
                null, null, null, true);
        }

        public async Task AddAsync(Grade entity)
        {
            await this.courseUnitOfWork.GradeRepository.AddAsync(entity);
            await this.courseUnitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.courseUnitOfWork.Dispose();
        }
    }
}
