using GoBHHC.Repository;
using GoBHHC.Shared.Models;
using NUnit.Framework;

namespace GoBHHC.Tests {

    [TestFixture]
    public class Tests : BaseTestFixture {

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void GetList() {
            var listMgrItemsList = _repository.GetListMgrItems();
            Assert.GreaterOrEqual(listMgrItemsList.Count, 4);
        }

        [Test]
        public void AddItem() {

            const string DESC = "NEW ITEM DESCRIPTION";

            var listMgrItem = _repository.AddListMgrItem(new ListMgrItem() {
                Description = DESC
            });

            Assert.AreEqual(listMgrItem.Description, DESC);
        }

        [Test]
        public void DeleteItem() {
            const string DESC = "NEW ITEM DESCRIPTION";

            var listMgrItem = _repository.AddListMgrItem(new ListMgrItem() {
                Description = DESC
            });

            Assert.AreEqual(listMgrItem.Description, DESC);

            var affectedRows = _repository.DeleteListMgrItem(listMgrItem.ListMgrID);

            Assert.AreEqual(affectedRows, 1);
        }

        [Test]
        public void UpdateItem() {
            const string DESC = "NEW ITEM DESCRIPTION";
            const string DESC2 = "NEW ITEM DESCRIPTION PART DEUX";

            var listMgrItem = _repository.AddListMgrItem(new ListMgrItem() {
                Description = DESC
            });

            Assert.AreEqual(listMgrItem.Description, DESC);

            listMgrItem.Description = DESC2;

            _repository.UpdateListMgrItem(listMgrItem);

            var listMgrItem2 = _repository.GetListMgrItem(listMgrItem.ListMgrID);

            Assert.AreEqual(listMgrItem2.Description, DESC2);
        }
    }
}