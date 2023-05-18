using System.IO;
using UnityEngine;

namespace Infrastructure.Services
{
    internal class SaveService : ISave
    {
        public void Save<TData>(TData data, string saveFilePath) => 
            File.WriteAllText(saveFilePath, JsonUtility.ToJson(data));
    }
}