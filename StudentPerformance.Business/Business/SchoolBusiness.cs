using Microsoft.EntityFrameworkCore.Metadata;
using StudentPerformance.Business.Common;
using StudentPerformance.Business.Contract;
using StudentPerformance.Entity.Models;
using StudentPerformance.Repository.Contract;
using StudentPerformance.ViewModel;

namespace StudentPerformance.Business.Business
{
	public class SchoolBusiness : ISchoolBusiness
	{
		private readonly ISchoolRepository _schoolRepository;
        public SchoolBusiness(ISchoolRepository schoolRepository)
        {
			_schoolRepository = schoolRepository;
        }

		public SubjectModel GetAllMarksById(Guid id)
		{
			var res = _schoolRepository.GetMarksheetById(id);

			SubjectModel sbm = new();
			sbm = Mapper.ToSubjectModel(res);
			return sbm;
		}

		public List<MarksheetModel> GetMarksheetById(Guid id)
		{
			var res = _schoolRepository.GetMarksheetById(id);
			List<MarksheetModel> marksheet = new();
			foreach (Marksheet m in res)
			{
				marksheet.Add(Mapper.ToMarksheetModel(m));
			}
			return marksheet;
		}

		public List<MarksheetModel> GetMarksheets()
		{
			var tempRes = _schoolRepository.GetMarksheets();
			List<MarksheetModel> marksheets = new();
			foreach(Marksheet m in tempRes)
			{
				marksheets.Add(Mapper.ToMarksheetModel(m));
			}
			return marksheets;
		}

		public List<StudentModel> GetStudents()
		{
			var tempRes =  _schoolRepository.GetStudents();
			List<StudentModel> students = new();
			foreach(StudentMaster student in tempRes)
			{
				students.Add(new StudentModel
				{
					StudentId = student.StudentId,
					StudentName = student.StudentName,
					Class = student.Class
				});
			}
			return students;
		}

		public decimal GetTotalMarksObtained(Guid id)
		{
			return _schoolRepository.GetTotalMarksObtained(id);
		}

		public decimal GetTotalPercentageObtained(Guid id)
		{
			return _schoolRepository.GetTotalPercentageObtained(id);
		}

		public List<StudentClassModel> GetStudentList()
		{
			List<StudentClassModel> res = new();
			var students = _schoolRepository.GetStudents();
			foreach (StudentMaster student in students)
			{
				res.Add(new StudentClassModel
				{
					Name = student.StudentName,
					Class = student.Class,
					TotalMarkObtained = GetTotalMarksObtained(student.StudentId),
					TotalMarks = _schoolRepository.GetTotalMarks(student.StudentId),
					TotalPercentage = GetTotalPercentageObtained(student.StudentId)
				});
			}
			return res;
		}

		public void Add(StudentSubjectModel ssm)
		{
			List<Marksheet> marksheets = Mapper.FromSSMToMarksheet(ssm);
			_schoolRepository.Add(marksheets);
		}

		public void Update(MarksheetUpModel marksheet)
		{
			_schoolRepository.Update(marksheet);
		}
	}
}
