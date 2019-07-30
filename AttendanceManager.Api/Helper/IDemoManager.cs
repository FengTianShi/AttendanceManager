using AttendanceManager.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceManager.Api.Helper
{
    public interface IDemoManager
    {
        Task<IList<PersonInfoModel>> QueryAllPersonInfoAsync();
        Task<PersonInfoModel> QueryPersonInfoByIdAsync(int id);
        Task<bool> InsertPersonInfoAsync(PersonInfoModel person);
        Task<bool> UpdatePersonInfoByIdAsync(PersonInfoModel person);
        Task<bool> DeletePersonInfoByIdAsync(int id);

    }
}
