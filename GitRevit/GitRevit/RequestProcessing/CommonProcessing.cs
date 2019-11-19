using GitRevit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.RequestProcessing
{
    public static class CommonProcessing
    {
        public static IEnumerable<RevitElementModel> RetreiveNewElementFromLocal(IEnumerable<RevitElementModel> elementsFromLocalRevit)
        {
            // Element chưa tồn tại Id trên timeline của drawing tương ứng
            // Tạo element trên drawing đó với init commonId, Mỗi khi có 1 drawing khác sysnc thì sẽ tạo các element trên revit và trên server
            // và được add commonId
            foreach (RevitElementModel element in elementsFromLocalRevit) {
                yield return element;
            }
        }

        public static IEnumerable<RevitElementModel> RetreiveNewElementFromServer(List<RevitElementModel> elementsFromLocalRevit)
        {
            // Element chưa tồn tại Id trên timeline của drawing tương ứng
            // Tạo element trên drawing đó với init commonId, Mỗi khi có 1 drawing khác sysnc thì sẽ tạo các element trên revit và trên server
            // và được add commonId
            foreach (RevitElementModel element in elementsFromLocalRevit) {
                yield return element;
            }
        }

        public static IEnumerable<RevitElementModel> RetreiveDeletedLocalElement(IEnumerable<RevitElementModel> elementsFromLocalRevit, IEnumerable<RevitElementModel> elementsFromServer)
        {
            // Nếu element đã tồn tại trên server mà tìm trong element local revit đẩy lên mà không có => element đó đã bị delete ở local,
            //và ta phải delete trên server với tất cả các element tương ứng (có cùng commonId) sẽ ở trạng thái deleted
            foreach (RevitElementModel element in elementsFromLocalRevit) {
                yield return element;
            }
        }

        public static IEnumerable<RevitElementModel> RetreiveQueueDeletingElementOnServer(IEnumerable<RevitElementModel> elementsFromServer)
        {
            // Nếu element đã tồn tại trên server đang ở trạng thái deleted(1 trong 3 element ở 3 bộ môn với commonId tương ứng) thì sẽ tiến hành áp chế ghi đè
            // delete ở dưới local
            foreach (RevitElementModel element in elementsFromServer) {
                yield return element;
            }
        }

        public static IEnumerable<RevitElementModel> RetreiveQueueCretingElementOnServer(IEnumerable<RevitElementModel> elementsFromServer)
        {
            // Nếu element đã tồn tại trên server đang ở trạng thái deleted(1 trong 3 element ở 3 bộ môn với commonId tương ứng) thì sẽ tiến hành áp chế ghi đè
            // delete ở dưới local
            foreach (RevitElementModel element in elementsFromServer) {
                yield return element;
            }
        }

        public static IEnumerable<RevitElementModel> RetreiveElementEditedOnLocal(IEnumerable<RevitElementModel> elementsFromServer)
        {
            // Nếu element đã tồn tại trên server đang ở trạng thái deleted(1 trong 3 element ở 3 bộ môn với commonId tương ứng) thì sẽ tiến hành áp chế ghi đè
            // delete ở dưới local
            foreach (RevitElementModel element in elementsFromServer) {
                yield return element;
            }
        }
    }
}