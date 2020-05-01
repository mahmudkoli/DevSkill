using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class CourseUnitOfWork : UnitOfWork, ICourseUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public ISubjectRepository SubjectRepository { get; set; }
        public IGradeRepository GradeRepository { get; set; }

        public CourseUnitOfWork(CourseDbContext dbContext,
            IStudentRepository studentRepository,
            ISubjectRepository subjectRepository,
            IGradeRepository gradeRepository) : base(dbContext)
        {
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
            GradeRepository = gradeRepository;
        }
    }
}
