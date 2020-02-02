using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModule : IApplicationModule
    {
        IDescriptionModuleDescription Description { get; }
        IReadOnlyDictionary<string, IDescription> Descriptions { get; }

        void Add(string id, IDescription description);
        void Remove(string id);
        T GetDescription<T>(string id) where T : IDescription;
        bool TryGetDescription<T>(string id, out T description) where T : IDescription;
        T Load<T>(string assetName) where T : IDescription;
        IDescription Load(string assetName, Type assetType);
        Task<T> LoadAsync<T>(string assetName) where T : IDescription;
        Task<IDescription> LoadAsync(string assetName, Type assetType);
    }
}
