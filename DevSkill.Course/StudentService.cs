using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class StudentService : IStudentService
    {
        private readonly ICourseUnitOfWork courseUnitOfWork;

        public StudentService(ICourseUnitOfWork courseUnitOfWork)
        {
            this.courseUnitOfWork = courseUnitOfWork;
        }
        public async Task AddAsync(Student entity)
        {
            await this.courseUnitOfWork.StudentRepository.AddAsync(entity);
            await this.courseUnitOfWork.SaveChangesAsync();
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            return await this.courseUnitOfWork.StudentRepository.GetAsync(x => x, null, null, null, true);
        }

        public void Dispose()
        {
            this.courseUnitOfWork.Dispose();
        }
    }
}
