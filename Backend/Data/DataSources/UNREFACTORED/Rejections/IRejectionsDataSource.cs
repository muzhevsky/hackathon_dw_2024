using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Rejections;

public interface IRejectionsDataSource
{
    RejectionDto? SelectById(int id);
    IEnumerable<RejectionDto> SelectByRequestId(int requestId);
    void Insert(RejectionDto dto);
}