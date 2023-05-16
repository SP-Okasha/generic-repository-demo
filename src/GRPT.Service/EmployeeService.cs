using AutoMapper;
using GRPT.Helper;
using GRPT.Model.Common;
using GRPT.Model.Dto;
using GRPT.Repository;
using GRPT.Repository.Database;
using GRPT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IGenericRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all employee records
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<EmployeeResponseModel>>> GetAllEmployees()
        {
            var data = await _repository.GetAllAsync<Employee>(
                x => x.Dept,
                y => y.Manager);


            var response = _mapper.Map<IEnumerable<EmployeeResponseModel>>(data);
            return new ServiceResponse<IEnumerable<EmployeeResponseModel>>(response, $"{response.Count()} Employee records found!");

        }

        /// <summary>
        /// Get employee record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<EmployeeResponseModel>> GetEmployee(int id)
        {
            var data = await _repository.GetAsync<Employee>(x => x.Id == id,
                y => y.Dept,
                z => z.Manager);

            if (data == null)
                return new ServiceResponse<EmployeeResponseModel>($"Employee's record not found!");

            var response = _mapper.Map<EmployeeResponseModel>(data);
            return new ServiceResponse<EmployeeResponseModel>(response, $"{response.EmpName} Employee records found!");
        }

        /// <summary>
        /// Add new employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<EmployeeResponseModel>> AddEmployee(EmployeeRequestModel employee)
        {
            if (await _repository.IsExistsAsync<Employee>(x => x.EmpName == employee.EmpName && x.EmpCode == employee.EmpCode))
                return new ServiceResponse<EmployeeResponseModel>("This employee already exists!");

            var applicationUser = new ApplicationUser
            {
                Username = employee.EmpName,
                PasswordHash = Utility.EncryptPassword(employee.EmpCode),
                RoleRid = 1,
                CreatedBy = employee.CreatedBy,
            };


            await _repository.AddAsync(applicationUser, applicationUser.CreatedBy);
            await _repository.SaveChangesAsync();

            var dbObject = _mapper.Map<Employee>(employee);
            dbObject.Id = applicationUser.Id;
            await _repository.AddAsync(dbObject, dbObject.CreatedBy);
            await _repository.SaveChangesAsync();

            return new ServiceResponse<EmployeeResponseModel>(_mapper.Map<EmployeeResponseModel>(dbObject), "Employee record has been added successfully!");
        }

        /// <summary>
        /// Update employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<EmployeeResponseModel>> UpdateEmployee(EmployeeRequestModel employee)
        {
            if (await _repository.IsExistsAsync<Employee>(x => x.Id != employee.Id && x.EmpName == employee.EmpName && x.EmpCode == employee.EmpCode))
                return new ServiceResponse<EmployeeResponseModel>("This employee already exists!");

            var dbObject = await _repository.GetAsync<Employee>(x => x.Id == employee.Id);
            if (dbObject is null)
                return new ServiceResponse<EmployeeResponseModel>("Employee not found!");

            _mapper.Map(employee, dbObject);
            await _repository.Update(dbObject, dbObject.UpdatedBy);
            await _repository.SaveChangesAsync();


            return new ServiceResponse<EmployeeResponseModel>(_mapper.Map<EmployeeResponseModel>(dbObject), "Employee record has been updated successfully!");
        }


        /// <summary>
        /// Delete employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> DeleteEmployee(int id)
        {
            var dbObject = await _repository.GetAsync<Employee>(x => x.Id == id);
            if (dbObject is null)
                return new ServiceResponse<bool>("Employee not found!");

            await _repository.Delete(dbObject);
            await _repository.SaveChangesAsync();

            return new ServiceResponse<bool>(true, "Employee record deleted successfully!");

        }
    }
}
