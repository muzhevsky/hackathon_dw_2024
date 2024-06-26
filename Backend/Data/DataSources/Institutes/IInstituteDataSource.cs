﻿using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

namespace Hackaton_DW_2024.Data.DataSources.Institutes;

public interface IInstituteDataSource
{
    IEnumerable<InstituteDto> SelectAll();
    InstituteDto? SelectById(int id);
}