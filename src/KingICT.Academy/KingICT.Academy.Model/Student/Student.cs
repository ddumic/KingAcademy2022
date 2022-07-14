namespace KingICT.Academy.Model.Student
{
	public class Student
	{
		public int Id { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public int? ProjectId { get; private set; }

		public virtual Project.Project Project { get; private set; }


		public void SetId(int id)
		{
			Id = id;
		}

		public void SetFirstName(string firstName)
		{
			if (string.IsNullOrWhiteSpace(firstName))
			{
				throw new ArgumentException(nameof(firstName));
			}

			FirstName = firstName;
		}

		public void SetLastName(string lastName)
		{
			if (string.IsNullOrWhiteSpace(lastName))
			{
				throw new ArgumentException(nameof(lastName));
			}

			LastName = lastName;
		}
	}
}
