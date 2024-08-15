using UnityEngine;

namespace UGF.Module.Descriptions.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestDescriptionTableAsset")]
    public class TestDescriptionTableAsset : DescriptionTableAsset<TestTableAsset.Entry, TestDescription>
    {
    }
}
