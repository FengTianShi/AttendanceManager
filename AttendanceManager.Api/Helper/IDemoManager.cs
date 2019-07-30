using AttendanceManager.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceManager.Api.Helper
{
    public interface IDemoManager
    {
        Task<PersonInfoModel> QueryPersonInfoByIdAsync(int id);
        Task<IList<PersonInfoModel>> QueryAllPersonInfoAsync();
    }
}
