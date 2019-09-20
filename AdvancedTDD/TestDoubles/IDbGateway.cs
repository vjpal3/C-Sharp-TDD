namespace AdvancedTDD.TestDoubles
{
    public interface IDbGateway
    {
        WorkingStatistics GetWorkingStatistics(int id);
    }
}