using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CounterApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnInitialVal_Clicked(object sender, EventArgs e)
        {
            if (Int32.TryParse(count.Text, out int tempVal))
            {
                setCountLabel("init");
            }
            else
            {
                lblError.Text = "Please enter a number";
            }

            
        }

        private void BtnCountUp_Clicked(object sender, EventArgs e)
        {
            setCountLabel("add");
        }

        private void BtnCountDown_Clicked(object sender, EventArgs e)
        {
            setCountLabel("sub");
        }

        void setCountLabel(string op)
        {
            lblError.Text = "";

            if(Int32.TryParse(lblCount.Text, out int val))
            {

                // Check the type of operation passed in
                if (op == "add")
                {
                    lblCount.Text = $"{val + 1}";
                } else if (op == "sub")
                {
                    lblCount.Text = $"{val - 1}";
                } else if (op == "init")
                {
                    lblCount.Text = count.Text;
                    count.Text = "";
                }

            }
            else
            {
                lblError.Text = "Count not convert string to int";
            }
        }
    }
}
