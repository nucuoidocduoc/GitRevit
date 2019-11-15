using GitRevit.Model;
using GitRevit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.RequestProcessing
{
    // Input data from server
    public class LocalSyncData : ISyncData
    {
        private IEnumerable<RevitElementModel> _elementsBelongDrawingOnServer;
        private IEnumerable<RevitElementModel> _elementsOnLocal;
        private RepositoryServices _repository = new RepositoryServices();

        public LocalSyncData()
        {
        }

        public void SyncDeleteElement()
        {
            var elementQueueDeletingOnserver = CommonProcessing.RetreiveQueueDeletingElementOnServer(_elementsBelongDrawingOnServer);
            foreach (RevitElementModel element in elementQueueDeletingOnserver) {
                var elemFind = _elementsOnLocal.FirstOrDefault(x => x.ElementId == element.ElementId);
                if (elemFind != null) {
                    _repository.DeleteElementOnLocal(elemFind);
                }
            }
            // xu li tiep voi version + revision
        }

        public void SyncEditedElement()
        {
            // bao conflict neu co
            throw new NotImplementedException();
        }

        public void SyncNewElement()
        {
            var elementQueueCreatingOnserver = CommonProcessing.RetreiveQueueCretingElementOnServer(_elementsBelongDrawingOnServer);
            foreach (RevitElementModel element in elementQueueCreatingOnserver) {
                var elemFind = _elementsOnLocal.FirstOrDefault(x => x.ElementId == element.ElementId);
                if (elemFind != null) {
                    _repository.CreateElementOnLocal(elemFind);
                }
            }
            // xu li tiep voi version + revision
        }

        public void SyncNoChangeElement()
        {
            // xu li tiep voi version + revision
            throw new NotImplementedException();
        }
    }
}