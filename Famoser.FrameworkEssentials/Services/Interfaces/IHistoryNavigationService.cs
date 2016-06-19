using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.View.Interfaces;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IHistoryNavigationService
    {
        /// <summary>
        /// The key indicating the root page
        /// </summary>
        string RootPageKey { get; }

        /// <summary>
        /// a key indicating that the current page is unknown
        /// </summary>
        string UnknownPageKey { get; }

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        string CurrentPageKey { get; }

        /// <summary>
        /// If possible, instructs the navigation service to discard the current page and display the previous page on the navigation stack.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Instructs the navigation service to display a new page corresponding to the given key.
        /// Configure the service first with Configure
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page that should be displayed.</param>
        /// <param name="navigationBackNotifier">the object to be notified when navigating back</param>
        /// <param name="notifyObject">the object to be send when navigating back</param>
        void NavigateTo(string pageKey, INavigationBackNotifier navigationBackNotifier = null, object notifyObject = null);

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// </summary>
        void Configure(string key, Type pageType);
    }
}
