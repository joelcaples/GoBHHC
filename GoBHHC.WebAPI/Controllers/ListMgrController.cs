using System.Collections.Generic;
using GoBHHC.Repository;
using GoBHHC.Shared;
using GoBHHC.Shared.Interfaces;
using GoBHHC.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoBHHC.WebAPI.Controllers {

    [ApiController]
    [Route("api/ListMgr")]
    public class ListMgrController : ControllerBase {

        private readonly ILogger<ListMgrController> _logger;
        private readonly IListMgrRepository _repository;

        public ListMgrController(ILogger<ListMgrController> logger) {
            _logger = logger;
            _repository = RepositoryFactory.GetRepository();
        }

        // https://localhost:44363/api/ListMgr
        [HttpGet]
        public IEnumerable<IListMgrItem> GetListMgrItems() {
            return _repository.GetListMgrItems();
        }

        [HttpPost]
        public ActionResult<IListMgrItem> AddListMgrItem(ListMgrItem listMgrItem) {

            var result = _repository.AddListMgrItem(listMgrItem);

            if (result is ListMgrItem)
                return (ListMgrItem)result;

            return BadRequest();
        }

        [HttpDelete("{listMgrID}")]
        public IActionResult DeleteListMgrItem(int listMgrID) {
            try {
                _repository.DeleteListMgrItem(listMgrID);
            } catch (NotFoundException) {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{listMgrID}")]
        public ActionResult<IListMgrItem> GetListMgrItem(int listMgrID) {

            var result = _repository.GetListMgrItem(listMgrID);

            if (result is ListMgrItem)
                return (ListMgrItem)result;

            return BadRequest();
        }

        [HttpPut("{listMgrID}")]
        public IActionResult UpdateListMgrItem(int listMgrID, ListMgrItem listMgrItem) {

            if (listMgrID != listMgrItem.ListMgrID) {
                return BadRequest();
            }

            try {
                _repository.UpdateListMgrItem(listMgrItem);
            } catch (NotFoundException) {
                return NotFound();
            }

            return Ok();
        }
    }
}
