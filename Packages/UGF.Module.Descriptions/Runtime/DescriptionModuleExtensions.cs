using System;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public static class DescriptionModuleExtensions
    {
        public static T GetFromTable<T>(this IDescriptionModule descriptionModule, GlobalId id) where T : IDescription
        {
            return TryGetFromTable(descriptionModule, id, out T description) ? description : throw new ArgumentException($"Description not found by the specified id: '{id}'.");
        }

        public static bool TryGetFromTable<T>(this IDescriptionModule descriptionModule, GlobalId id, out T description) where T : IDescription
        {
            if (descriptionModule == null) throw new ArgumentNullException(nameof(descriptionModule));
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            var descriptionTable = descriptionModule.Provider.Get<IDescriptionTable<T>>();

            return descriptionTable.TryGet(id, out description);
        }

        public static T GetFromTable<T>(this IDescriptionModule descriptionModule, GlobalId descriptionTableId, GlobalId id) where T : IDescription
        {
            return TryGetFromTable(descriptionModule, descriptionTableId, id, out T description) ? description : throw new ArgumentException($"Description not found by the specified description table id and id: '{descriptionTableId}', '{id}'.");
        }

        public static bool TryGetFromTable<T>(this IDescriptionModule descriptionModule, GlobalId descriptionTableId, GlobalId id, out T description) where T : IDescription
        {
            if (descriptionModule == null) throw new ArgumentNullException(nameof(descriptionModule));
            if (!descriptionTableId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(descriptionTableId));
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            var descriptionTable = descriptionModule.Provider.Get<IDescriptionTable<T>>(descriptionTableId);

            return descriptionTable.TryGet(id, out description);
        }

        public static T Get<T>(this IDescriptionModule descriptionModule, GlobalId groupId, GlobalId id) where T : class, IDescription
        {
            return (T)Get(descriptionModule, groupId, id);
        }

        public static IDescription Get(this IDescriptionModule descriptionModule, GlobalId groupId, GlobalId id)
        {
            return TryGet(descriptionModule, groupId, id, out IDescription description) ? description : throw new ArgumentException($"Description not found by the specified group and id: '{groupId}', '{id}'.");
        }

        public static bool TryGet<T>(this IDescriptionModule descriptionModule, GlobalId groupId, GlobalId id, out T description) where T : class, IDescription
        {
            if (TryGet(descriptionModule, groupId, id, out IDescription result))
            {
                description = (T)result;
                return true;
            }

            description = default;
            return false;
        }

        public static bool TryGet(this IDescriptionModule descriptionModule, GlobalId groupId, GlobalId id, out IDescription description)
        {
            if (descriptionModule == null) throw new ArgumentNullException(nameof(descriptionModule));
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            if (descriptionModule.Get<DescriptionGroup>(groupId).Descriptions.TryGetValue(id, out GlobalId descriptionId))
            {
                description = descriptionModule.Get(descriptionId);
                return true;
            }

            description = default;
            return false;
        }
    }
}
