using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Institutes;

public class EfInstituteDataSource: EntityFrameworkDataSource, IInstituteDataSource
{
    DbSet<InstituteDto> Institutes { get; set; }
    
    public EfInstituteDataSource(ApplicationContext context) : base(context)
    {
        Institutes = context.Institutes;
    }

    public IEnumerable<InstituteDto> SelectAll()
    {
        return Institutes;
    }

    public InstituteDto? SelectById(int id)
    {
        return Institutes.FirstOrDefault(dto => dto.Id == id);
    }
}