using System.IO;
using UnityEngine;

namespace Infrastructure.Services
{
    internal class LoadService : ILoad
    {
        public object Load<TData>(string saveFilePath) where TData : IData
        {
            if (File.Exists(saveFilePath))
            {
                return JsonUtility.FromJson<TData>(File.ReadAllText(saveFilePath));
            }

            return null;
        }
    }
}