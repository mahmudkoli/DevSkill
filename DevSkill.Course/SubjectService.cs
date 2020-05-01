using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class SubjectService : ISubjectService
    {
        private readonly ICourseUnitOfWork courseUnitOfWork;

        public SubjectService(ICourseUnitOfWork courseUnitOfWork)
        {
            this.courseUnitOfWork = courseUnitOfWork;
        }
        public async Task AddAsync(Subject entity)
        {
            await this.courseUnitOfWork.SubjectRepository.AddAsync(entity);
            await this.courseUnitOfWork.SaveChangesAsync();
        }

        public async Task<IList<Subject>> GetAllAsync()
        {
            return await this.courseUnitOfWork.SubjectRepository.GetAsync(x => x, null, null, null, true);
        }

        public void Dispose()
        {
            this.courseUnitOfWork.Dispose();
        }
    }
}
