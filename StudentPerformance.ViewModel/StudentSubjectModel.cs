using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModel
{
	public class StudentSubjectModel
	{
        public Guid StudentId { get; set; }
		public decimal English { get; set; } 
		public decimal Hindi { get; set; } 
		public decimal Maths { get; set; } 
		public decimal Science { get; set; } 
	}
}
