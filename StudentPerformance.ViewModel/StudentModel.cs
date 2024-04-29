using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModel
{
	public class StudentModel
	{
		public Guid StudentId { get; set; }

		public string StudentName { get; set; } = null!;

		public int Class { get; set; }
	}
}
