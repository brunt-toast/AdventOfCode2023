using AdventOfCode2023.TestSupport;
using System.Reflection;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Timer
    {
        [TestMethod]
        public void TimeFunctions()
        {
            StringWriter disposableStringWriter = new();
            TextWriter defaultOut = Console.Out;

            Type answerInterface = typeof(IAocAnswer);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(answerInterface.IsAssignableFrom)
                .Where(x => !x.IsInterface)
                .OrderBy(x => x.Namespace)
                .ThenBy(x => x.Name);

            foreach (Type t in types)
            {
                List<MethodInfo> testableMethods = t.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(AocAnswerExpected), false).Length > 0)
                    .ToList();

                foreach (MethodInfo methodInfo in testableMethods)
                {
                    AocAnswerExpected attribute = methodInfo.GetCustomAttributes().First(a => a is AocAnswerExpected) as AocAnswerExpected;
                    object classInstance = Activator.CreateInstance(t, null);

                    DateTime start = DateTime.Now;

                    Console.SetOut(disposableStringWriter);
                    double ms = TimeFunction(methodInfo, classInstance);
                    Console.SetOut(defaultOut);
                    Console.WriteLine($"{classInstance.GetType().Namespace}.{classInstance.GetType().Name}: {ms}ms");
                }
            }
        }

        private static double TimeFunction(MethodInfo methodInfo, object classInstance)
        {
            DateTime start = DateTime.Now;
            methodInfo.Invoke(classInstance, null);
            return (DateTime.Now - start).TotalMilliseconds;
        }
    }
}
