using System;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModule : ApplicationModule<DescriptionModuleDescription>, IDescriptionModule
    {
        IDescriptionModuleDescription IDescriptionModule.Description { get { return Description; } }

        public DescriptionModule(DescriptionModuleDescription description, IApplication application) : base(description, application)
        {
        }

        public T Get<T>(GlobalId id) where T : class, IDescription
        {
            return (T)Get(id);
        }

        public IDescription Get(GlobalId id)
        {
            return TryGet(id, out IDescription description) ? description : throw new ArgumentException($"Description not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(GlobalId id, out T description) where T : class, IDescription
        {
            if (TryGet(id, out IDescription result))
            {
                description = (T)result;
                return true;
            }

            description = default;
            return false;
        }

        public bool TryGet(GlobalId id, out IDescription description)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            return Description.Descriptions.TryGetValue(id, out description);
        }
    }
}
