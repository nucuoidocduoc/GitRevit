using GitRevit.Model;
using GitRevit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.RequestProcessing
{
    // input data from local to sync with server
    public class ServerSyncData : ISyncData
    {
        private IEnumerable<RevitElementModel> _elementsFromLocal;
        private IEnumerable<RevitElementModel> _elementsFromServer;
        private RepositoryServices _repository = new RepositoryServices();

        public ServerSyncData(IEnumerable<RevitElementModel> elementsFromLocal)
        {
            _elementsFromLocal = elementsFromLocal;
        }

        public void SyncLocalOverrideServer()
        {
            SyncNewElement();
            SyncDeleteElement();
            SyncEditedElement();
            _repository.CreateNewRevision();
        }

        public void SyncDeleteElement()
        {
            var elementsMissingFromLocal = CommonProcessing.RetreiveDeletedLocalElement(_elementsFromLocal, _elementsFromServer);
            foreach (RevitElementModel element in elementsMissingFromLocal) {
                var elementsCorrespodOtherDrawing = _repository.GetElementCorrespondOtherDrawing(x => x.CommonId == "this is commonId");
                foreach (var elementCorres in elementsCorrespodOtherDrawing) {
                    _repository.ChangePropsElement(elementCorres, "Status", "Deleting");
                }
                _repository.ChangePropsElement(element, "Status", "Deleted");
            }
            // xu li tiep voi version + revision
        }

        public void SyncEditedElement()
        {
            var elements = CommonProcessing.RetreiveElementEditedOnLocal(_elementsFromLocal);
            foreach (var element in elements) {
                _repository.ImplementEditOnServer(element.CommonId, null);
            }
        }

        public void SyncNewElement()
        {
            var newElement = CommonProcessing.RetreiveNewElementFromLocal(_elementsFromLocal);

            foreach (var elem in _elementsFromLocal) {
                _repository.CreateNewElement(elem);
                _repository.CreateNewElementToOtherDrawing(elem, "current drawing");
                _repository.CreateNewVersion(elem.CommonId, null);
            }
            // xu li tiep voi version
        }

        public void SyncNoChangeElement()
        {
            // xu li tiep voi version + revision
            throw new NotImplementedException();
        }
    }
}