using Hackaton_DW_2024.Internal.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Rejections;

public interface IRejectionsDataSource
{
    RejectionDto? SelectById(int id);
    IEnumerable<RejectionDto> SelectByRequestId(int requestId);
    void Insert(RejectionDto dto);
}