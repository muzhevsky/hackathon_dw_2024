namespace Hackaton_DW_2024.Data.Converters;

public interface IConverter<T1,T2>
{
    T2 Convert(T1 convertable);
}