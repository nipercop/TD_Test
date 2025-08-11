using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.DataBase.Interfaces;

namespace CardRogue.DataBase.Interfaces.Loader
{
    public interface IDataLoader
    {
        UniTask LoadAsync<T>(string source, Action<T> onComplete, Action<Exception> onError = null);
    }
}