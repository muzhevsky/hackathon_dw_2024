using Hackaton_DW_2024.Internal.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Requests;

public interface IRequestDataSource
{
    RequestDto? SelectById(int id);
    IEnumerable<RequestDto> SelectByUserId(int userId);
    void Insert(RequestDto dto);
    void UpdateById(int id, Action<RequestDto> updateFunc);
    void DeleteById(int id);
}