using StudentPerformance.Entity.Models;
using StudentPerformance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.Business.Common
{
	public static class Mapper
	{
		public static SubjectModel ToSubjectModel(List<Marksheet> m)
		{
			SubjectModel sbm = new();
			sbm.English = m[0].MarksObtained;
			sbm.Hindi = m[1].MarksObtained;
			sbm.Maths = m[2].MarksObtained;
			sbm.Science = m[3].MarksObtained;
			return sbm;
		}

		public static MarksheetModel ToMarksheetModel(Marksheet m)
		{
			MarksheetModel res = new();

			res.MarksheetId = m.MarksheetId;
			res.StudentId = m.StudentId;
			res.Sub = m.Sub;
			res.MarksObtained = $"{m.MarksObtained}/{m.TotalMark}";

			return res;
		}

		public static List<Marksheet> FromSSMToMarksheet(StudentSubjectModel ssm)
		{
			var english = new Marksheet
			{
				StudentId = ssm.StudentId,
				MarksheetId = Guid.NewGuid(),
				Sub = "English",
				MarksObtained = ssm.English,
				TotalMark = 100
			};
			var hindi = new Marksheet
			{
				StudentId = ssm.StudentId,
				MarksheetId = Guid.NewGuid(),
				Sub = "Hindi",
				MarksObtained = ssm.Hindi,
				TotalMark = 100
			};
			var science = new Marksheet
			{
				StudentId = ssm.StudentId,
				MarksheetId = Guid.NewGuid(),
				Sub = "Science",
				MarksObtained = ssm.Science,
				TotalMark = 100
			};
			var maths = new Marksheet
			{
				StudentId = ssm.StudentId,
				MarksheetId = Guid.NewGuid(),
				Sub = "Maths",
				MarksObtained = ssm.Maths,
				TotalMark = 100
			};

			List<Marksheet> marksheet =new() { english, hindi, maths, science };

			return marksheet;
		}
	}
}
