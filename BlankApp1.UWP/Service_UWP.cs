using BlankApp1.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Xamarin.Forms;

[assembly: Dependency(typeof(Service_UWP))]
namespace BlankApp1.UWP
{
    class Service_UWP : IService
    {
        public async Task NewWindow()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Windows.UI.Xaml.Controls.Frame frame = new Windows.UI.Xaml.Controls.Frame();
                frame.Navigate(typeof(MainPage));
                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);

        }
    }
}
