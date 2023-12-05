namespace AdventOfCode2023.TestSupport
{

    [AttributeUsage(AttributeTargets.Method)]
    public class AocAnswerExpected : Attribute
    {
        public int TargetValue { get; }

        public AocAnswerExpected(int targetValue)
        {
            TargetValue = targetValue;
        }
    }
}
