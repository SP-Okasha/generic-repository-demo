using AutoMapper;
using AutoMapper.Configuration.Conventions;
using GRPT.Model.Dto;
using GRPT.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Helper
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            #region Employee Profiles
            CreateMap<Employee, EmployeeRequestModel>().ReverseMap();
            CreateMap<Employee, EmployeeResponseModel>()
                    .ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Dept.DeptName))
                    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.EmpName))
                    .ReverseMap();


            #endregion

            #region DataList Mappings

            CreateMap<Employee, DropdownDtoModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.EmpName} ({src.EmpCode})"))
                .ReverseMap();

            CreateMap<Department, DropdownDtoModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DeptName))
                .ReverseMap();

            #endregion

        }
    }
}
