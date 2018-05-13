using HungryMinds.LearningDatabase;

namespace  HungryMinds.Repsitory
{
    public class DatabaseAccessor
    {
        private static readonly cstructorDbEntities entities;

        static DatabaseAccessor()
        {
            entities = new cstructorDbEntities();
            entities.Database.Connection.Open();
        }

        public static cstructorDbEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
