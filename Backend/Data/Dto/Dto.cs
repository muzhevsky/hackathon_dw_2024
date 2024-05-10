using Newtonsoft.Json;

namespace Hackaton_DW_2024.Data.Dto;

public class Dto
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}