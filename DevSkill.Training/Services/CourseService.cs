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
    public class CourseService : ICourseService
    {
        private ICourseUnitOfWork _courseUnitOfWork;

        public CourseService(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }

        public async Task<(IList<Course> Items, int Total, int TotalDisplay)> GetAllAsync(
            string searchText, string orderBy, int pageIndex, int pageSize)
        {
            var result = await _courseUnitOfWork.CourseRepository.GetAsync<Course>(
                x => x, x => x.Title.Contains(searchText),
                x => IQueryableExtension.ApplyOrdering(x, orderBy),
                x => x.Include(y => y.StudentRegistrations)
                        .ThenInclude(y => y.Course),
                pageIndex, pageSize, true);

            return (result.Items, result.Total, result.TotalDisplay);
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _courseUnitOfWork.CourseRepository.FirstOrDefaultAsync(x => x, x => x.Id == id);
        }

        public async Task AddAsync(Course entity)
        {
            await _courseUnitOfWork.CourseRepository.AddAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course entity)
        {
            await _courseUnitOfWork.CourseRepository.UpdateAsync(entity);
            await _courseUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _courseUnitOfWork.CourseRepository.RemoveAsync(id);
            await _courseUnitOfWork.SaveChangesAsync();
        }
    }
}
