using System;

namespace Persistence
{
    public class MarginCallService
    {
        // The argument of "not needing to read the fn"
        public MarginCallService (IAgreementRepository agreementRepo, IMarginCallRepository marginCallRepo) {}
        // which dependencies do I mock?
        public SaveResponse SaveAgreements(List<Agreement> agreements) {}
        public List<Agreement> FindAgreements(FindRequest f){}
    }
}
