using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UtilityBills_marco
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadProvinces();
        }

        // Resets all fields to be empty and hides resLabel
        private void On_Reset_Clicked(object sender, EventArgs e)
        {
            daytimeUsage.Text = "";
            eveningUsage.Text = "";

            renewableUsed.IsToggled = false;
            renewableUsed.IsEnabled = true; // making sure that the switch is enabled, in case it isn't

            // Not reseting the text in the res label and layout since the text will be updated the next time it's made visible
            resLabel.IsVisible = false;
            chargesLayout.IsVisible = false;

            // Resetting the picker
            provincePicker.SelectedIndex = -1;
        }

        private void On_Calculate_Clicked(object sender, EventArgs e)
        {

            // Check to make sure that all entry fields have valid values (won't accept decimal values, find a way to see if double or floats are accepted
            if(double.TryParse(daytimeUsage.Text, out double daytime) && double.TryParse(eveningUsage.Text, out double evening))  {


                // Check to see if tempVals are less than 0
                if (daytime < 0 || evening < 0)
                {
                    // Hide the layout, in case the user did not reset the fields after a calculation
                    chargesLayout.IsVisible = false;
                    setResultLabel("Please make sure that the usage values are not less than 0", Color.Red, Color.White);
                }

                else
                {
                    

                    // See if the province picker was left empty. If it is, display an error message and return
                    if(provincePicker.SelectedIndex == -1)
                    {
                        // Hide the layout, in case the user did not reset the fields after a calculation
                        chargesLayout.IsVisible = false;
                        setResultLabel("Please Select a Province", Color.Red, Color.White);
                        return;
                    }

                    double taxPercentage = getTaxForSelectedProvince();

                    // find if renewable energy was used
                    bool isRenewableUsed = false;

                    if(renewableUsed.IsToggled == true)
                    {
                        isRenewableUsed = true;
                    }
                    else
                    {
                        isRenewableUsed = false;
                    }

                    // do math
                    double costOfDaytimeUsage = 0.314 * daytime;
                    double costOfEveningUsage = 0.186 * evening;
                    double totalUsage = costOfDaytimeUsage + costOfEveningUsage;
                    double salesTax = totalUsage * taxPercentage;

                    double rebateAmount = 0;

                    // if renewable energy was used, then provide a tax rebate of 9.5%
                    if (isRenewableUsed)
                    {
                        rebateAmount = totalUsage *  0.095;
                    }

                    // Rounding all charges to 2 decimal places
                    daytimeChargesLabel.Text = $"Daytime Usage Charges: ${costOfDaytimeUsage:F2}";
                    eveningChargesLabel.Text = $"Evening Usage Charges: ${costOfEveningUsage:F2}";
                    totalChargesLabel.Text = $"Total Charges: ${totalUsage:F2}";
                    // removing the decimal in the tax percentage
                    taxLabel.Text = $"Sales Tax ({taxPercentage * 100})%: ${salesTax:F2}";

                    if (rebateAmount != 0)
                    {
                        enviromentalRebateLabel.Text = $"Environmental Rebate: -${rebateAmount:F2}";
                    }
                    else
                    {
                        enviromentalRebateLabel.Text = $"Environmental Rebate: $0";
                    }


                    double totalBillAmount = totalUsage + salesTax - rebateAmount;

                    chargesLayout.IsVisible = true;
                    //Set the result label
                    setResultLabel($"You Must Pay: ${totalBillAmount:F2}", Color.Yellow, Color.Black);
                }
            }
            else
            {
                // Hide the layout, in case the user did not reset the fields after a calculation
                chargesLayout.IsVisible = false;
                setResultLabel("You must enter valid usage values", Color.Red, Color.White);
            }
        }

        private void LoadProvinces()
        {
            List<String> provinces = new List<String>
            {
                "AB",
                "BC",
                "ON",
                "NL"
            };

            provincePicker.ItemsSource = provinces;
        }

        private void provincePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (provincePicker.SelectedIndex != -1)
            {
                string selectedProvince = provincePicker.SelectedItem.ToString();

                // If BC was selected set the toggle to be active and disable it from being changed
                if (selectedProvince == "BC")
                {
                    renewableUsed.IsToggled = true;
                    renewableUsed.IsEnabled = false;
                }
                // Otherwise, make sure that it is enabled
                else
                {
                    renewableUsed.IsEnabled = true;
                }
            }
        }

        private double getTaxForSelectedProvince()
        {
            double tax = 0;

            string selectedProvince = provincePicker.SelectedItem.ToString();

            if (selectedProvince == "AB")
            {
                tax = 0;
            }
            else if (selectedProvince == "BC")
            {
                tax  = 0.12;
            }
            else if (selectedProvince == "ON")
            {
                tax = 0.13;
            }
            else if (selectedProvince == "NL")
            {
                tax = 0.15;
            }

            return tax;
        }

        // Recieves text and colour and makes the label visible
        private void setResultLabel(String text, Color color, Color textColor)
        {
            resLabel.Text = text;
            resLabel.BackgroundColor = color;
            resLabel.TextColor = textColor;
            resLabel.IsVisible = true;
        }

    }
}
