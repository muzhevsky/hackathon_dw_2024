namespace Hackaton_DW_2024.Infrastructure.Repositories;

public interface ICommandExecutor<T1, T2>
{
    T2 Execute(T1 id);
}