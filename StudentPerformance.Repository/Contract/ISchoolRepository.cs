using StudentPerformance.Entity.Models;
using StudentPerformance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.Repository.Contract
{
	public interface ISchoolRepository
	{
		List<StudentMaster> GetStudents();
		List<Marksheet> GetMarksheets();

		List<Marksheet> GetMarksheetById(Guid id);

		decimal GetTotalMarksObtained(Guid id);

		decimal GetTotalPercentageObtained(Guid id);

		decimal GetTotalMarks(Guid id);

		void Add(List<Marksheet> marksheets);

		void Update(MarksheetUpModel marksheet);
	}
}
