using GRPT.Model.Common;
using GRPT.Model.Dto;
using GRPT.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GRPT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : BaseController
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        /// <summary>
        /// Get name,id pair of employee records
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployeeDataList")]
        public async Task<ApiResponseModel> GetEmployeeDataList()
        {
            return GetResponse(await _commonService.GetDataList(Helper.Utility.DataListType.Employee));
        }

        /// <summary>
        /// Get name,id pair of department records
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDepartmentDataList")]
        public async Task<ApiResponseModel> GetDepartmentDataList()
        {
            return GetResponse(await _commonService.GetDataList(Helper.Utility.DataListType.Department));
        }
    }
}
