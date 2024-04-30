using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentPerformance.Entity.Models;
using StudentPerformance.ViewModel;

namespace StudentPerformance.Business.Common
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
            CreateMap<Marksheet, MarksheetModel>();
            CreateMap<Marksheet, MarksheetModel>().ReverseMap();

            CreateMap<StudentMaster, StudentModel>();
            CreateMap<StudentMaster, StudentModel>().ReverseMap();
        }
	}
}
