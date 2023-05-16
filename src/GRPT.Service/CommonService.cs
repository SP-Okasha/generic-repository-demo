using AutoMapper;
using GRPT.Model.Common;
using GRPT.Model.Dto;
using GRPT.Repository;
using GRPT.Repository.Database;
using GRPT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GRPT.Helper.Utility;

namespace GRPT.Service
{
    public class CommonService: ICommonService
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper _mapper;

        public CommonService(IGenericRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<IEnumerable<DropdownDtoModel>>> GetDataList(DataListType listType)
        {
            IEnumerable<DropdownDtoModel> dataList = listType switch
            {
                DataListType.Employee => _mapper.Map<IEnumerable<DropdownDtoModel>>(await _repository.GetAllAsync<Employee>()),
                DataListType.Department => _mapper.Map<IEnumerable<DropdownDtoModel>>(await _repository.GetAllAsync<Department>()),
                _ => new List<DropdownDtoModel>()
            };

            return new ServiceResponse<IEnumerable<DropdownDtoModel>>(dataList, $"{listType} data list");
        }
    }
}
