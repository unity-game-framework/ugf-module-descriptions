﻿using System;
using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Group", order = 2000)]
    public class DescriptionGroupAsset : DescriptionAsset
    {
        [SerializeField] private List<Entry> m_descriptions = new List<Entry>();

        public List<Entry> Descriptions { get { return m_descriptions; } }

        [Serializable]
        public struct Entry
        {
            [AssetId(typeof(DescriptionAsset))]
            [SerializeField] private GlobalId m_key;
            [AssetId(typeof(DescriptionAsset))]
            [SerializeField] private GlobalId m_value;

            public GlobalId Key { get { return m_key; } set { m_key = value; } }
            public GlobalId Value { get { return m_value; } set { m_value = value; } }
        }

        protected override IDescription OnBuild()
        {
            var description = new DescriptionGroup();

            for (int i = 0; i < m_descriptions.Count; i++)
            {
                Entry entry = m_descriptions[i];

                if (!entry.Key.IsValid()) throw new ArgumentException("Value should be valid.", nameof(entry.Key));
                if (!entry.Value.IsValid()) throw new ArgumentException("Value should be valid.", nameof(entry.Value));

                description.Descriptions.Add(entry.Key, entry.Value);
            }

            return description;
        }
    }
}
