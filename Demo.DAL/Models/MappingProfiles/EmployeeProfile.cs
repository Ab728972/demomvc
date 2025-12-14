using AutoMapper;
using Demo.DAL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Demo.PL.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, Employee>().ReverseMap();
        }
    }
    CreateMap<EmployeeViewModel, Employee>().ReverseMap();
}