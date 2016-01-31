using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace UWAppDependencyObject
{
    //inherit from 
    public class LoadingData : DependencyObject
    {
        //registeration of dependency object
        public static readonly DependencyProperty LoadingMessageProperty = DependencyProperty.Register(
                "LoadingMessage"
                , typeof(string)
                , typeof(LoadingData)
                , new PropertyMetadata(String.Empty)   
            );

        //property rapper
        public string LoadingMessage
        {
            get { return (string)GetValue(LoadingMessageProperty); }
            set { SetValue(LoadingMessageProperty, value); }
        }

        //registeration of dependency object
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
                "IsLoading"
                , typeof(bool)
                , typeof(LoadingData)
                , new PropertyMetadata(false, new PropertyChangedCallback(IsloadingChanged))
            );

        //call back after change for dependency object
        private static void IsloadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LoadingData container = d as LoadingData;
            bool latestIsLoadingValue = (bool)e.NewValue;

            if (!latestIsLoadingValue)
            {
                //do something as message status changed
                new MessageDialog("Loading is complete!").ShowAsync();

            }

        }
    }
}
