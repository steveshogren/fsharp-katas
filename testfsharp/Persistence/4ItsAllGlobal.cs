using System;

namespace Persistence
{
    public class MarginCallService
    {
        // The argument that "Ninject container is global state", but it is always global state,
        // constructor injection doesn't limit or change that in any way
        // we practically never construct a class with dependencies, we always actually use the empty constructor
        public MarginCallService (IAgreementRepository agreementRepo, IMarginCallRepository marginCallRepo) {}
        // which dependencies do I mock?
        public SaveResponse SaveAgreements(List<Agreement> agreements) {}
        public List<Agreement> FindAgreements(FindRequest f){}
    }
}
