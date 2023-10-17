using DotNetAdvancedHerhalingsopdracht.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DotNetAdvancedHerhalingsopdracht.Repositories
{
    class StudentRepository : BaseRepository<Student>
    {
        protected override string Table => "Students";
        public StudentRepository(DbConnection connection) : base(connection)
        {
        }
        public void AddStudent(Student student)
        {
            var sql = $"INSERT INTO [{Table}] ([FirstName], [LastName],[Age], [Year]) VALUES (@FirstName, @LastName, @Age, @Year)";
            var numberOfAffectedRows =  InsertOneRecord(student,sql);
            
        }

        protected override void MapCommand(DbCommand command, Student entity)
        {
            command.Parameters.Add(CreateParameter(command, "Id", entity.Id));
            command.Parameters.Add(CreateParameter(command,"FirstName",entity.FirstName));
            command.Parameters.Add(CreateParameter(command, "LastName", entity.LastName));
            command.Parameters.Add(CreateParameter(command, "Age", entity.Age));
            command.Parameters.Add(CreateParameter(command, "Year", entity.Year));
        }

        protected override Student MapEntity(DbDataReader reader)
        {
            return new Student
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Age = reader.GetByte(3),
                Year = reader.GetInt16(4)

            };
        }
    }
}
