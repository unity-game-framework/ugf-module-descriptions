using UGF.Description.Runtime;
using UGF.Tables.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    public abstract class DescriptionTableAsset<TTableEntry, TDescription> : DescriptionTableAsset
        where TTableEntry : IDescriptionTableEntry<TDescription>
        where TDescription : IDescription
    {
        [SerializeField] private Table<TTableEntry> m_table = new Table<TTableEntry>();

        public Table<TTableEntry> Table { get { return m_table; } }

        protected override ITable OnGet()
        {
            return m_table;
        }

        protected override void OnSet(ITable table)
        {
            m_table = (Table<TTableEntry>)table;
        }

        protected override IDescriptionTable OnBuild()
        {
            var description = new DescriptionTable<TDescription>();

            for (int i = 0; i < m_table.Entries.Count; i++)
            {
                TTableEntry entry = m_table.Entries[i];

                TDescription entryDescription = entry.Build();

                description.Add(entry.Id, entryDescription);
            }

            return description;
        }
    }
}
