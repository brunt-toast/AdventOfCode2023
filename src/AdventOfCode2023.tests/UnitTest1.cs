using AdventOfCode2023.TestSupport;
using System.Reflection;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CheckAnswers()
        {
            Type answerInterface = typeof(IAocAnswer);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(answerInterface.IsAssignableFrom)
                .Where(x => !x.IsInterface);

            foreach (Type t in types)
            {
                List<MethodInfo> testableMethods = t.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(AocAnswerExpected), false).Length > 0)
                    .ToList();

                foreach (MethodInfo methodInfo in testableMethods)
                {
                    AocAnswerExpected attribute = methodInfo.GetCustomAttributes().First(a => a is AocAnswerExpected) as AocAnswerExpected;
                    object classInstance = Activator.CreateInstance(t, null);
                    Assert.AreEqual(attribute.TargetValue, methodInfo.Invoke(classInstance, null),
                        $"Assertion failed in {t.Namespace}.{t.Name}.{methodInfo.Name}");
                }
            }
        }
    }
}
