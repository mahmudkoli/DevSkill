using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Course
{
    public class CourseModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public CourseModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseDbContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CourseUnitOfWork>().As<ICourseUnitOfWork>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SubjectRepository>().As<ISubjectRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<GradeRepository>().As<IGradeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<SubjectService>().As<ISubjectService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<GradeService>().As<IGradeService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
