using GRPT.Model.Common;
using GRPT.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GRPT.Helper.Utility;

namespace GRPT.Service.Interfaces
{
    
    public interface ICommonService
    {
        /// <summary>
        /// Get the name,id pair of records
        /// </summary>
        /// <param name="listType"></param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<DropdownDtoModel>>> GetDataList(DataListType listType);
    }
}
