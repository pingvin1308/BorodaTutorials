using System.ComponentModel.DataAnnotations;

namespace BorodaTutorials.Core.Services
{
    /// <summary>
    /// This class is used for working with tests
    /// </summary>
    public interface ITestsService
    {
        /// <summary>
        /// 
        /// Summary:
        ///     
        ///     This method is used for creating test
        /// 
        /// Parameters:
        ///     
        ///     test - represent test with draft status
        /// 
        /// </summary>
        TestResult Create(Test test);

        /// <summary>
        /// 
        /// </summary>
        void Delete();

        /// <summary>
        /// 
        /// </summary>
        void Generate();

        /// <summary>
        /// 
        /// </summary>
        void Get();

        /// <summary>
        /// 
        /// </summary>
        void Update();
    }

    public class TestResult
    {
        public bool IsSuccess { get; set; }
    }

    public class Test
    {
        [Required]
        public string Name { get; set; }
        public Question[] Questions { get; set; }
    }

    public class Question
    {
        public string Name { get; set; }
        public string Answer { get; set; }
    }
}