using GoBHHC.Repository;
using NUnit.Framework;

namespace GoBHHC.Tests {

    [SetUpFixture]
    public abstract class BaseTestFixture {

        protected IListMgrRepository _repository;

        [OneTimeSetUp]
        public void GlobalSetup() {
            _repository = RepositoryFactory.GetRepository(ListMgrEnvironment.Test);
        }
    }
}