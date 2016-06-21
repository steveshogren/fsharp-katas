using System;

namespace Persistence
{
    public class MarginCallService
    {
        // Class Injection Brings Unnecessary State

        //IAgreementRepository agreementRepo (FindAll, FindById, Save, )
        //IMarginCallRepository marginCallRepo (FindAll, FindById, Save, )

        public MarginCallService (IAgreementRepository agreementRepo, IMarginCallRepository marginCallRepo) {}

        public SaveResponse SaveAgreements(List<Agreement> agreements) {}
        public List<Agreement> FindAgreements(FindRequest f){}
    }
}
