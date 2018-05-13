using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HungryMinds.Repository;

namespace HungryMinds.Business
{
 
 
        public interface IEnrollmentManager
        {
            EnrollmentModel[] Enrollments { get; }
            
        }
        public class EnrollmentModel
        {
            public int CourseId { get; set; }
            public int StudentId { get; set; }

            public EnrollmentModel(int courseId, int studentId)
            {
                StudentId = studentId;
                CourseId = courseId;
            }
        }

        public class EnrollmentManager : IEnrollmentManager
        {
            private readonly IEnrollmentRepository enrollmentRepository;

            public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
            {
                this.enrollmentRepository = enrollmentRepository;
            }

            public EnrollmentModel[] Enrollments
            {
                get
                {
                    return enrollmentRepository.Enrollments
                                             .Select(t => new EnrollmentModel(t.ClassId, t.StudentId))
                                             .ToArray();
                }
            }

           

        }
    }



