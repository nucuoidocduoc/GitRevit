using GitRevit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.Services
{
    public class RepositoryServices
    {
        public RepositoryServices()
        {
        }

        public IEnumerable<RevitElementModel> GetElementCorrespondOtherDrawing(Predicate<RevitElementModel> Conditional = null)
        {
            IEnumerable<RevitElementModel> elements = new List<RevitElementModel>();

            foreach (RevitElementModel element in elements) {
                if (Conditional != null && Conditional(element)) {
                    yield return element;
                }
                else {
                    yield return element;
                }
            }
        }

        public void CreateNewElementToOtherDrawing(RevitElementModel elementInOrigin, string nameDrawingCurrent)
        {
        }

        public void CreateNewElement(RevitElementModel elementInOrigin)
        {
        }

        public string CreateNewVersion(string commonId, ElementVersionModel elementVersionModel)
        {
            return "Id after create new";
        }

        public bool ChangePropsElement<T, M>(T ele, string nameProp, M newValue)
        {
            foreach (var prop in ele.GetType().GetProperties()) {
                if (prop.Name.Equals(nameProp)) {
                    if (prop.GetValue(ele).GetType() == newValue.GetType()) {
                        prop.SetValue(ele, newValue);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ImplementEditOnServer(string commonId, ElementVersionModel elementVersionModel)
        {
            CreateNewVersion(commonId, elementVersionModel);
            return true;
        }

        public void CreateNewRevision()
        {
            // Tìm tất cả các element có trạng thái k bị delete trong drawing
            // Lấy tất cả các version mới nhất của mỗi element đó
            // convert =>json string
            // Tiến hành tạo Revision.
        }

        public bool DeleteElementOnLocal(RevitElementModel elementInOrigin)
        {
            return true;
        }

        public bool CreateElementOnLocal(RevitElementModel elementInOrigin)
        {
            return true;
        }
    }
}