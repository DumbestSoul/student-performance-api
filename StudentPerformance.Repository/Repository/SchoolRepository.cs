using StudentPerformance.Entity.Models;
using StudentPerformance.Repository.Contract;
using StudentPerformance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.Repository.Repository
{
	public class SchoolRepository : ISchoolRepository
	{
		private readonly SchoolContext _schoolContext;
        public SchoolRepository(SchoolContext schoolContext)
        {
			_schoolContext = schoolContext;
        }

		public List<Marksheet> GetMarksheetById(Guid id)
		{
			var res = _schoolContext.Marksheets
				.Where(p => p.StudentId == id)
				.OrderBy(p=>p.Sub)
				.ToList();

			return res;
		}

		public List<Marksheet> GetMarksheets()
		{
			var res = _schoolContext.Marksheets.ToList();
			return res;
		}

		public List<StudentMaster> GetStudents()
		{
			var res = _schoolContext.StudentMasters.ToList();
			return res;
		}

		public decimal GetTotalMarksObtained(Guid id)
		{
			var res = _schoolContext.Marksheets
				.Where(p=>p.StudentId==id)
				.Sum(p => p.MarksObtained);
			return res;
		}

		public decimal GetTotalPercentageObtained(Guid id)
		{
			var totalObtainedMarks = GetTotalMarksObtained(id);
			var totalMarks = _schoolContext.Marksheets.Where(p => p.StudentId == id).Sum(p => p.TotalMark);
			if (totalMarks == 0) return 0;

			var res =  (totalObtainedMarks * 100) / totalMarks;
			return (decimal) res;
		}

		public decimal GetTotalMarks(Guid id)
		{
			var totalMarks = _schoolContext.Marksheets.Where(p => p.StudentId == id).Sum(p => p.TotalMark);
			return totalMarks==null ? 0 : (decimal) totalMarks;
		}

		public void Add(List<Marksheet> marksheets)
		{
			foreach(Marksheet marksheet in marksheets)
			{
				_schoolContext.Marksheets.Add(marksheet);
				_schoolContext.SaveChanges();
			}
		}

		public void Update(MarksheetUpModel marksheet)
		{
			var newmarksheet = _schoolContext.Marksheets.First(p => p.MarksheetId == marksheet.MarksheetId);
			if (newmarksheet == null) return;

			newmarksheet.MarksObtained = marksheet.NewMarks;
			_schoolContext.Update(newmarksheet);
			_schoolContext.SaveChanges();
		}
	}
}
