namespace Infrastructure.Services
{
    public interface ILoad
    {
        public object Load<TData>(string saveFilePath) where TData : IData;
    }
}