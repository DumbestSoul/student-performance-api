using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPerformance.Business.Contract;
using StudentPerformance.Entity.Models;
using StudentPerformance.ViewModel;

namespace StudentPerformance.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentPerformanceController : ControllerBase
	{
		private readonly ISchoolBusiness _schoolBusiness;
        public StudentPerformanceController(ISchoolBusiness schoolBusiness)
        {
			_schoolBusiness = schoolBusiness;
        }

		[HttpGet("Students")]
		public IActionResult GetStudents()
		{
			var res = _schoolBusiness.GetStudents();
			return Ok(res);
		}

		[HttpGet("Marksheets")]
		public IActionResult GetMarksheets()
		{
			var res = _schoolBusiness.GetMarksheets();
			return Ok(res);
		}

		[HttpGet("Marksheets/{id}")]
		public IActionResult GetMarksheetById(Guid id)
		{
			var res = _schoolBusiness.GetMarksheetById(id);
			if (res == null) return BadRequest();
			return Ok(res);
		}

		[HttpGet("Marksheets/GetSubjectMarks/{id}")]
		public IActionResult GetAllMarksById(Guid id)
		{
			var res = _schoolBusiness.GetAllMarksById(id);
			return Ok(res);
		}

		[HttpGet("Marksheets/GetTotalMarksObtained/{id}")]
		public IActionResult GetTotalMarksObtained(Guid id)
		{
			return Ok(_schoolBusiness.GetTotalMarksObtained(id));
		}

		[HttpGet("Marksheets/GetTotalPercentageObtained/{id}")]
		public IActionResult GetTotalPercentageObtained(Guid id)
		{
			return Ok(_schoolBusiness.GetTotalPercentageObtained(id));
		}

		[HttpGet("GetStudentList")]
		public IActionResult GetStudentList()
		{
			return Ok(_schoolBusiness.GetStudentList());
		}

		[HttpPost("AddMarks")]
		public IActionResult Add([FromBody] StudentSubjectModel ssm)
		{
			_schoolBusiness.Add(ssm);
			return Created("AddMarks", ssm);
		}

		[HttpPut("UpdateMarks")]
		public IActionResult Update([FromBody] MarksheetUpModel m)
		{
			_schoolBusiness.Update(m);
			return Ok("Data Updated");
		}

	}
}
