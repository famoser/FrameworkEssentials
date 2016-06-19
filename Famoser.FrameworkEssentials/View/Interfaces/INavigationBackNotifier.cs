using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.View.Interfaces
{
    public interface INavigationBackNotifier
    {
        void HandleNavigationBack(object message);
    }
}
