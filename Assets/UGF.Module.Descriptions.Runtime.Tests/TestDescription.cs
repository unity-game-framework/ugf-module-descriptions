using UGF.Description.Runtime;

namespace UGF.Module.Descriptions.Runtime.Tests
{
    public struct TestDescription : IDescription
    {
        public int Value { get; }

        public TestDescription(int value)
        {
            Value = value;
        }
    }
}
