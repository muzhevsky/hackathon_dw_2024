﻿using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.FileSystem;

public interface IFileSystem
{
    void Write(FileDto file);
    FileDto Read(string fileName);
}