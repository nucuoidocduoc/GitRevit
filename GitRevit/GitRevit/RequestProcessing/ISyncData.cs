using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRevit.RequestProcessing
{
    public interface ISyncData
    {
        void SyncNewElement();

        void SyncDeleteElement();

        void SyncEditedElement();

        void SyncNoChangeElement();
    }
}