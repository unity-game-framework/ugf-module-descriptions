using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.Tables.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    public abstract class DescriptionTableAsset<TTableEntry, TDescription> : DescriptionAsset
        where TTableEntry : IDescriptionTableEntry<TDescription>
        where TDescription : IDescription
    {
        [SerializeField] private List<TableAsset> m_tables = new List<TableAsset>();

        public List<TableAsset> Tables { get { return m_tables; } }

        protected override IDescription OnBuild()
        {
            var description = new DescriptionTable<TDescription>();

            for (int i = 0; i < m_tables.Count; i++)
            {
                TableAsset tableAsset = m_tables[i];

                var table = (ITable<TTableEntry>)tableAsset.Get();

                for (int e = 0; e < table.Entries.Count; e++)
                {
                    TTableEntry entry = table.Entries[e];

                    TDescription entryDescription = entry.Build();

                    description.Add(entry.Id, entryDescription);
                }
            }

            return description;
        }
    }
}
