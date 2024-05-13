using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Requests;

public class EfRequestDataSource : EntityFrameworkDataSource, IRequestDataSource
{
    DbSet<RequestDto> Requests { get; set; }

    public EfRequestDataSource(ApplicationContext context) : base(context)
    {
        Requests = context.Requests;
    }

    public RequestDto? SelectById(int id) => Requests.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<RequestDto> SelectByUserId(int userId) => Requests.Where(dto => dto.UserId == userId);

    public void Insert(RequestDto dto)
    {
        Requests.Add(dto);
        Context.SaveChanges();
    }

    public void UpdateById(int id, Action<RequestDto> updateFunc)
    {
        var updateTarget = Requests.FirstOrDefault(dto => dto.Id == id);
        updateFunc(updateTarget);
        Context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = Requests.FirstOrDefault(dto => dto.Id == id);
        Requests.Remove(deleteTarget);
        Context.SaveChanges();
    }
}