using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModel
{
	public class MarksheetModel
	{
		public Guid MarksheetId { get; set; }

		public Guid? StudentId { get; set; }

		public string Sub { get; set; } = null!;

		public decimal? MarksObtained { get; set; }
	}
}
