using BorodaTutorials.Core.Repositories;
using BorodaTutorials.Core.Services;
using System;

namespace BorodaTutorials.Application
{
    /// <inheritdoc cref="ITestsService"/>
    public class TestsService : ITestsService
    {
        private readonly ITestRepository _testRepository;

        public TestsService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public TestResult Create(Test test)
        {
            _testRepository.Save(test);

            return new TestResult
            {
                IsSuccess = true
            };
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Generate()
        {
            throw new NotImplementedException();
        }
    }
}
