using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TipCalculator.Resources;

namespace TipCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void billAmountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (billAmountTextBox.Text.Length > 0)
            {
                billAmountTextBox.Text = "£" + billAmountTextBox.Text;
            }
            else
            {
                billAmountTextBox.Text = "£0.00";
            }
        }

        private void billAmountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = string.Empty;
        }

        private void billAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            performCalculation();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void performCalculation()
        {
            var selection = myStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            Tip.CalculateTip(billAmountTextBox.Text,double.Parse(selection.Tag.ToString()));
            amountToTipBlock.Text = Tip.TipAmount;
            totalTextBlock.Text = Tip.TotalAmount;

        }

     

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}