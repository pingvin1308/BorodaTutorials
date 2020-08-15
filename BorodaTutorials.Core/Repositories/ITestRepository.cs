using BorodaTutorials.Core.Services;

namespace BorodaTutorials.Core.Repositories
{
    public interface ITestRepository
    {
        void Save(Test test);
        void Update();
        void Get();
        void Delete();
    }
}
