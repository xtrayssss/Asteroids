using MonoBehaviours;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        public Game Game { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Game = new Game();
        }
    }
}