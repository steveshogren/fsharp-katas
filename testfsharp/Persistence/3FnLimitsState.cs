using System;

namespace Persistence
{
    public class MarginCallService
    {
        // Fn Injection Only Injects Necessary State

        AgreementRepository.FindAll agreementRepo_findall;
        AgreementRepository.Save agreementRepo_save;
        MarginCallRepository.FindCriteria marginRepo_findcriteria;

        public SaveResponse SaveAgreements(List<Agreement> agreements) {}
        public List<Agreement> FindAgreements(FindRequest f){}
    }
}
