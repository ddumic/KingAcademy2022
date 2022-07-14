namespace KingICT.Academy.Model.Project
{
	public class Project
	{
		public int Id { get; private set; }

		public string Name { get; private set; }

		public virtual ICollection<Student.Student> Students { get; private set; }


		public void SetId(int id)
		{
			Id = id;
		}

		public void SetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException(nameof(name));
			}

			Name = name;
		}

		public void SetStudents(IEnumerable<Student.Student> students)
		{
			Students = students.ToList();
		}
	}
}
