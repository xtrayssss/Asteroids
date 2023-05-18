namespace Infrastructure.Services
{
    public interface ISave
    {
        public void Save<TData>(TData data, string saveFilePath);
    }
}