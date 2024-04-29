using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.ViewModel
{
	public class StudentClassModel
	{
        public string Name { get; set; }
		public int Class { get; set; }
		public decimal TotalMarkObtained { get; set; } = 0;
		public decimal TotalMarks { get; set; } = 0;
		public decimal TotalPercentage { get; set; } = 0;
    }
}
