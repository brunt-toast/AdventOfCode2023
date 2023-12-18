using AdventOfCode2023.TestSupport;
using System.Reflection;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class FileMatchingTest
    {
        [TestMethod]
        public void EnsureFilesMatch()
        {
            Type answerInterface = typeof(IAocAnswer);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(answerInterface.IsAssignableFrom)
                .Where(x => !x.IsInterface);

            Assert.IsTrue(types.All(FileNameMatchesFullyQualifiedName));
        }

        private static bool FileNameMatchesFullyQualifiedName(Type t)
        {
            object? instance = Activator.CreateInstance(t);
            FieldInfo? fieldInfo = t.GetField("_stream", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fieldInfo is null) return false;


            StreamReader? streamReader = (StreamReader)fieldInfo.GetValue(instance)!;
            if (streamReader.BaseStream is not FileStream fileStream) return false;

            string? folderName = t.Namespace?.Split(".").Last();
            string targetFile = @$"{folderName}\input.txt";

            bool isMatch = fileStream.Name.EndsWith(targetFile);

            if (!isMatch)
            {
                Console.WriteLine($"The input file for {folderName} doesn't seem to match the namespace.");
            }

            return isMatch;
        }
    }
}
