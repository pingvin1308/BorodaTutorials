using BorodaTutorials.Application;
using BorodaTutorials.Core.Repositories;
using BorodaTutorials.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BorodaTutorials.Tests.TestServiceTests
{

    /// <summary>
    /// 
    /// Valid use cases:
    /// 1) Test without questions
    /// 2) Question with text answer
    /// 3) Question with one correct answer
    /// 4) Question with several correct answers
    /// 
    /// Invalid use cases:
    /// 1) Create throws ArgumentNullException for test argument
    /// 
    /// </summary>
    [TestFixture]
    public class CreateTests
    {
        private TestsService _testsService;
        private Test _test;
        private Mock<ITestRepository> _repository;
        private Expression<Action<ITestRepository>> _saveExpression;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<ITestRepository>();
            _testsService = new TestsService(_repository.Object);

            _test = new Test
            {
                Name = Guid.NewGuid().ToString()
            };

            _saveExpression = x => x.Save(It.Is<Test>(y => y.Name == _test.Name));
        }

        [Test]
        public void Create_TestWithoutQuestions_ShouldReturnsTestResult()
        {
            // arrange
            _repository
                .Setup(_saveExpression)
                .Verifiable("You should call ITestRepository.Save to save created test");

            // act
            var result = _testsService.Create(_test);

            // assert
            _repository.Verify(_saveExpression, Times.Once);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
        }


        [Test]
        public void Create_TextAnswer_ShouldReturnsTestResult()
        {
            // arrange
            var question = new Question
            {
                Name = "TestName",
                Answer = "Test"
            };

            _test.Questions = new[]
            {
                question
            };

            var flow = _repository
                .Setup(x => x.Save(It.Is<Test>(y => y.Name == _test.Name && y.Questions.All(q => q.Name == question.Name && q.Answer == question.Answer))));
            
            flow.Verifiable("You should call ITestRepository.Save to save created test");

            // act
            var result = _testsService.Create(_test);

            // assert
            _repository.Verify();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Create_OneCorrectAnswer_ShouldReturnsTestResult()
        {
            //arrange

            //act
            
            //assert
        }

        [Test]
        public void Create_SeveralCorrectAnswers_ShouldReturnsTestResult()
        {
            //arrange


            //act


            //assert
        }

        [Test]
        public void Create_NullTestArgument_ShouldThowsArgumentNullException()
        {

        }
    }
}
