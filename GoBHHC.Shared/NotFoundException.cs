using System;
using System.Collections.Generic;
using System.Text;

namespace GoBHHC.Shared {

    public class NotFoundException : Exception {
        public override string Message => "Requested item was not found";
    }
}
