using GRPT.Model.Common;
using GRPT.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GRPT.WebApp.Controllers
{
    public class CommonController : BaseController
    {
        public CommonController(IOptions<ApplicationSettingsModel> options) : base(options) { }

        
        public async Task<JsonResult> GetEmployeeDataList()
        {
            return GetResult<IEnumerable<DropdownDtoModel>>(await SendRequestAsync(ApiEndpoint.DataList.Employees));
        }

        public async Task<JsonResult> GetDepartmentDataList()
        {
            return GetResult<IEnumerable<DropdownDtoModel>>(await SendRequestAsync(ApiEndpoint.DataList.Departments));
        }
    }
}
