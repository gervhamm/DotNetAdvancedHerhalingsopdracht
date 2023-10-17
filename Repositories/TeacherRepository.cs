using DotNetAdvancedHerhalingsopdracht.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvancedHerhalingsopdracht.Repositories
{
    class TeacherRepository : BaseRepository<Teacher>
    {
        protected override string Table => "Teachers";
        public TeacherRepository(DbConnection connection) : base(connection)
        {
        }
        public void AddTeacher(Teacher teacher)
        {
            if (teacher.Course.Length > 2) { throw new ArgumentOutOfRangeException("The teacher can only have two courses");}
            else
            {
                var sql = $"INSERT INTO [{Table}] ([FirstName], [LastName],[Age], [Course1], [Course2]) VALUES (@FirstName, @LastName, @Age, @Course1, @Course2)";
                var numberOfAffectedRows = InsertOneRecord(teacher, sql);
            }
        }

        protected override void MapCommand(DbCommand command, Teacher entity)
        {
            command.Parameters.Add(CreateParameter(command, "Id", entity.Id));
            command.Parameters.Add(CreateParameter(command, "FirstName", entity.FirstName));
            command.Parameters.Add(CreateParameter(command, "LastName", entity.LastName));
            command.Parameters.Add(CreateParameter(command, "Age", entity.Age));
            command.Parameters.Add(CreateParameter(command, "Course1", entity.Course[0]));
            command.Parameters.Add(CreateParameter(command, "Course2", entity.Course[1]));
        }

        protected override Teacher MapEntity(DbDataReader reader)
        {
            return new Teacher
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Age = reader.GetByte(3),
                Course = new string[] { reader.GetString(4), reader.GetString(5) }
            };
        }
    }
}

