using StudentPerformance.Entity.Models;
using StudentPerformance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.Business.Contract
{
	public interface ISchoolBusiness
	{
		List<StudentModel> GetStudents();
		List<MarksheetModel> GetMarksheets();
		List<MarksheetModel> GetMarksheetById(Guid id);
		SubjectModel GetAllMarksById(Guid id);

		decimal GetTotalMarksObtained(Guid id);
		decimal GetTotalPercentageObtained(Guid id);

		List<StudentClassModel> GetStudentList();

		//POST METHODS
		void Add(StudentSubjectModel ssm);

		//PUT METHOD
		void Update(MarksheetUpModel marksheet);
	}
}
