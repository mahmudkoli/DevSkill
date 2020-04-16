using DevSkill.Training.Entities;
using DevSkill.Training.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevSkill.Data.Extensions;

namespace DevSkill.Training.Services
{
    public class StudentService : IStudentService
    {
        private ICourseUnitOfWork _courseUnitOfWork;

        public StudentService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }

        public async Task<(IList<Student> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText, string orderBy, int pageIndex, int pageSize)
        {
            var result = await _courseUnitOfWork.StudentRepository.GetAsync<Student>(
                x => x, x => x.Name.Contains(searchText),
                x => IQueryableExtension.ApplyOrdering(x, orderBy), 
                x => x.Include(y => y.StudentRegistrations)
                        .ThenInclude(y => y.Course), 
                pageIndex, pageSize, true);

            return (result.Items, result.Total, result.TotalDisplay);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _courseUnitOfWork.StudentRepository.FirstOrDefaultAsync(x => x, x => x.Id == id);
        }

        public async Task AddAsync(Student entity)
        {
            await _courseUnitOfWork.StudentRepository.AddAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            await _courseUnitOfWork.StudentRepository.UpdateAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _courseUnitOfWork.StudentRepository.RemoveAsync(id);
            await _courseUnitOfWork.SaveChangesAsync();
        }
    }
}
