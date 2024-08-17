using System;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestDescriptionTableAsset")]
    public class TestDescriptionTableAsset : DescriptionTableAsset<TestDescriptionTableAsset.Entry, TestDescription>
    {
        [Serializable]
        public struct Entry : IDescriptionTableEntry<TestDescription>
        {
            [SerializeField] private Hash128 m_id;
            [SerializeField] private string m_name;
            [SerializeField] private int m_value;

            public GlobalId Id { get { return m_id; } set { m_id = value; } }
            public string Name { get { return m_name; } set { m_name = value; } }
            public int Value { get { return m_value; } set { m_value = value; } }

            public TestDescription Build()
            {
                return new TestDescription(m_value);
            }
        }
    }
}
