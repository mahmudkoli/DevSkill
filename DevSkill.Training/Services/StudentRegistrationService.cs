using DevSkill.Data.Extensions;
using DevSkill.Training.Entities;
using DevSkill.Training.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var columnsMap = new Dictionary<string, Expression<Func<StudentRegistration, object>>>()
            {
                ["enrollDate"] = v => v.EnrollDate,
                ["studentName"] = v => v.Student.Name,
                ["courseTitle"] = v => v.Course.Title,
            };

            var result = await _courseUnitOfWork.StudentRegistrationRepository.GetAsync<StudentRegistration>(
                x => x, x => x.Student.Name.Contains(searchText) || x.Course.Title.Contains(searchText),
                x => x.ApplyOrdering(columnsMap, orderBy),
                x => x.Include(y => y.Student).Include(y => y.Course),
                pageIndex, pageSize, true);

            return (result.Items, result.Total, result.TotalDisplay);
        }

        public async Task<StudentRegistration> GetByIdAsync(int studentId, int courseId)
        {
            return await _courseUnitOfWork.StudentRegistrationRepository.GetByIdAsync(studentId, courseId);
        }

        public async Task<IList<object>> GetStudentsForSelectAsync()
        {
            return await _courseUnitOfWork.StudentRepository.GetAsync<object>(x => new { Value = x.Id.ToString(), Text = x.Name }, null, null, null, true);
        }

        public async Task<IList<object>> GetCoursesForSelectAsync()
        {
            return await _courseUnitOfWork.CourseRepository.GetAsync<object>(x => new { Value = x.Id.ToString(), Text = x.Title }, null, null, null, true);
        }

        public async Task<bool> IsExistsAsync(int studentId, int courseId)
        {
            return await _courseUnitOfWork.StudentRegistrationRepository.IsExistsAsync(x => x.StudentId == studentId && x.CourseId == courseId);
        }

        public async Task AddAsync(StudentRegistration entity)
        {
            await _courseUnitOfWork.StudentRegistrationRepository.AddAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentRegistration entity)
        {
            var updateEntity = await GetByIdAsync(entity.StudentId, entity.CourseId);
            updateEntity.StudentId = entity.StudentId;
            updateEntity.CourseId = entity.CourseId;
            updateEntity.EnrollDate = entity.EnrollDate;
            updateEntity.IsPaymentComplete = entity.IsPaymentComplete;

            await _courseUnitOfWork.StudentRegistrationRepository.UpdateAsync(updateEntity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int studentId, int courseId)
        {
            await _courseUnitOfWork.StudentRegistrationRepository.DeleteAsync(x => x.StudentId == studentId && x.CourseId == courseId);
            await _courseUnitOfWork.SaveChangesAsync();
        }
    }
}
