using DevSkill.Data.Extensions;
using DevSkill.Training.Entities;
using DevSkill.Training.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Training.Services
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private ICourseUnitOfWork _courseUnitOfWork;

        public StudentRegistrationService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }

        public async Task<(IList<StudentRegistration> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText, string orderBy, int pageIndex, int pageSize)
        {
            var result = await _courseUnitOfWork.StudentRegistrationRepository.GetAsync<StudentRegistration>(
                x => x, x => x.Student.Name.Contains(searchText) || x.Course.Title.Contains(searchText),
                x => IQueryableExtension.ApplyOrdering(x, orderBy),
                x => x.Include(y => y.Student).Include(y => y.Course),
                pageIndex, pageSize, true);

            return (result.Items, result.Total, result.TotalDisplay);
        }

        public async Task<StudentRegistration> GetByIdAsync(int studentId, int courseId)
        {
            return await _courseUnitOfWork.StudentRegistrationRepository.GetFirstOrDefaultAsync(x => x, x => x.StudentId == studentId && x.CourseId == courseId);
        }

        public async Task AddAsync(StudentRegistration entity)
        {
            await _courseUnitOfWork.StudentRegistrationRepository.AddAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentRegistration entity)
        {
            await _courseUnitOfWork.StudentRegistrationRepository.UpdateAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int studentId, int courseId)
        {
            await _courseUnitOfWork.StudentRegistrationRepository.RemoveAsync(x => x.StudentId == studentId && x.CourseId == courseId);
            await _courseUnitOfWork.SaveChangesAsync();
        }
    }
}
