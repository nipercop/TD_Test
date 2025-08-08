using System;
using System.Threading.Tasks;
using Game.DataBase.Interfaces;

namespace CardRogue.DataBase.Interfaces.Loader
{
    public interface IDataLoader
    {
        Task<IDataBase> LoadAsync(string source, Action<IDataBase> onComplete, Action<Exception> onError = null);
    }
}