using KingICT.Academy.Model.Student;
using KingICT.Academy.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy.Repository.Student
{
	public class StudentRepository : RepositoryBase, IStudentRepository
	{
		public StudentRepository(AcademyDbContext dbContext)
			: base(dbContext)
		{ }

		public async Task<Model.Student.Student> GetStudentByIdAsync(int id)
		{
			return await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<int> CreateStudentAsync(Model.Student.Student student)
		{
			await _dbContext.Students.AddAsync(student);
			await _dbContext.SaveChangesAsync();

			return student.Id;
		}

		public async Task DeleteStudentAsync(Model.Student.Student student)
		{
			_dbContext.Students.Remove(student);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Model.Student.Student> UpdateStudentAsync(Model.Student.Student student)
		{
			_dbContext.Students.Update(student);
			await _dbContext.SaveChangesAsync();

			return student;
		}

		public async Task<IEnumerable<Model.Student.Student>> GetAllStudentsAsync()
		{
			return await _dbContext.Students.ToListAsync();
		}
	}
}
