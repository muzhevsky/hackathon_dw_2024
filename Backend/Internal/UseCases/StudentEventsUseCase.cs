using Hackaton_DW_2024.Data.DataSources.Events;
using Hackaton_DW_2024.Data.DataSources.UsersAndEvents;

namespace Hackaton_DW_2024.Internal.UseCases;

public class StudentEventsUseCase
{
    IUsersAndEventsDataSource _usersAndEventsDataSource;
    
    public void Subscribe(int userId, int eventId)
    {
        
    }
}