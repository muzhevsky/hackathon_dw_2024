using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Requests;

public class EfRequestDataSource: EntityFrameworkDataSource, IRequestDataSource
{
    DbSet<RequestDto> Requests;
    public EfRequestDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public RequestDto? SelectById(int id) => Requests.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<RequestDto> SelectByUserId(int userId) => Requests.Where(dto => dto.UserId == userId).ToList();

    public void Insert(RequestDto dto)
    {
        Requests.Add(dto);
        SaveChanges();
    }

    public void UpdateById(int id, Action<RequestDto> updateFunc)
    {
        var updateTarget = Requests.FirstOrDefault(dto => dto.Id == id);
        if (updateTarget == null) throw new Exception("no entity found");
        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = Requests.FirstOrDefault(dto => dto.Id == id);
        if (deleteTarget == null) throw new Exception("no entity found");
        Requests.Remove(deleteTarget);
        SaveChanges();
    }
}