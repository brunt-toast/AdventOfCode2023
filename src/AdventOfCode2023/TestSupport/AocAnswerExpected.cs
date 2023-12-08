namespace AdventOfCode2023.TestSupport
{

    [AttributeUsage(AttributeTargets.Method)]
    public class AocAnswerExpected : Attribute
    {
        public long TargetValue { get; }

        public AocAnswerExpected(long targetValue)
        {
            TargetValue = targetValue;
        }
    }
}
