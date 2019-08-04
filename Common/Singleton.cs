// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Reflection;

namespace Common
{
    public class Singleton<T> where T : class
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                OnInit();

                return _instance;
            }
        }

        protected Singleton()
        {
        }

        private static void OnInit()
        {
            if (_instance != null)
                return;
            lock (typeof(T))
            {
                _instance = typeof(T).InvokeMember(typeof(T).Name,
                    BindingFlags.CreateInstance |
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic,
                    null, null, null) as T;
            }
        }
    }
}