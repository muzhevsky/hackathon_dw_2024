using Hackaton_DW_2024.Data.Dto.Events;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Statuses;

public class CachedEventStatusesDataSource: IEventStatusesDataSource
{
    Dictionary<int, EventStatusDto> _statuses = new();
    IEventStatusesDataSource _wrappedDataSource;

    public CachedEventStatusesDataSource(IEventStatusesDataSource wrappedDataSource)
    {
        _wrappedDataSource = wrappedDataSource;
        var statuses = _wrappedDataSource.SelectAll();
        foreach (var s in statuses)
        {
            _statuses.Add(s.Id, s);
        }
    }

    public IEnumerable<EventStatusDto> SelectAll() =>
        _statuses.Select(kv => kv.Value);

    public EventStatusDto? SelectById(int id)
    {
        if (_statuses.TryGetValue(id, out var result))
        {
            return result;
        }

        return _wrappedDataSource.SelectById(id) ?? throw new Exception("no entity found");
    }
}