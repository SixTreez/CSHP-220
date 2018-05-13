using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HungryMinds.Repsitory;
using HungryMinds.LearningDatabase;

namespace HungryMinds.Repository
{
    public interface IEnrollmentRepository
    {
        EnrollmentModel[] Enrollments { get; }        
    }

    public class EnrollmentModel
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }
    }
    class EnrollmentRepository : IEnrollmentRepository
    {
        public EnrollmentModel[] Enrollments => DatabaseAccessor.Instance.Users
                                               .Select(t => new EnrollmentModel {StudentId = t.UserId })
                                               .ToArray();

    
    }
}
