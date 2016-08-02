using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MotorInsuranceCalculator
{
    enum Occumpation
    {
        Chauffeur,
            Accountant
    }
  

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        double policy = 500;
        double Chauffeur = 0.10;
        double Accountant = 0.10;
        double age2125 = 0.20;
        double age2675 = 0.10;
        double claimOneYear = 0.20;
        double claimTwoFiveYear = 0.10;
        double tempPolicy;
        string DriverName;
        int counter = 0;
        private int _errors = 0;
        private Driver _driver = new Driver();
        public event PropertyChangedEventHandler PropertyChanged;

        // method for checking validation to check if there has been any changes
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public Window1()
        {
            
            tempPolicy = policy;
            DataContext = this;
            InitializeComponent();
            // styled grid in xaml
            grid_EmployeeData.DataContext = _driver;
           

        }

        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //checking if texboxes are filled out
            e.CanExecute = _errors == 0;
            e.Handled = true;
        }

        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _driver = new Driver();
            grid_EmployeeData.DataContext = _driver;
            e.Handled = true;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;
        }
        // Calculation for Claim in the last year
        public void claimOneYearMethod ()
            {
            
            tempPolicy = (tempPolicy + tempPolicy * claimOneYear);
            txtPolicy.Text = tempPolicy.ToString();

           

           
        }
        // calculation fie claim in last 2 to 5 years
        public void claimTwoFiveYearMethod ()
        {
            tempPolicy = (tempPolicy + tempPolicy * claimTwoFiveYear);
            txtPolicy.Text = tempPolicy.ToString();
        }
        // method for driver age between 21 and 25
        public void driverAge2125()
        {
            tempPolicy = (tempPolicy + tempPolicy * age2125);
            txtPolicy.Text = tempPolicy.ToString();

        }
        // adding list to occupation comboBox
        private void cmbOccupation_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> occupation = new List<string>();
            occupation.Add(Occumpation.Chauffeur.ToString());
            occupation.Add(Occumpation.Accountant.ToString());
           

            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = occupation;

            // ... Make the first item selected.
         // adding list to number of claims comboBox
        }
        private void cbxNoClaims_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> claim = new List<string>();
            claim.Add("0 ");
            claim.Add("1");
            claim.Add("2");
            claim.Add("3");
            claim.Add("4");
            claim.Add("5");


            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = claim;
            comboBox.SelectedIndex = 0;
        }
        // switch when a item is selected in the list of of claims comboBox
        private void cbxNoClaims_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                switch (cbxNoClaims.SelectedItem.ToString())
                {
                    case "1":
                        dpkClaim1.IsEnabled = true;
                        dpkClaim2.IsEnabled = false;
                        dpkClaim3.IsEnabled = false;
                        dpkClaim4.IsEnabled = false;
                        dpkClaim5.IsEnabled = false;
                        dpkClaim2.SelectedDate = null;
                        dpkClaim3.SelectedDate = null;
                        dpkClaim4.SelectedDate = null;
                        dpkClaim5.SelectedDate = null;

                        break;
                    case "2":
                        dpkClaim2.IsEnabled = true;
                        dpkClaim1.IsEnabled = true;
                        dpkClaim3.IsEnabled = false;
                        dpkClaim4.IsEnabled = false;
                        dpkClaim5.IsEnabled = false;
                        dpkClaim3.SelectedDate = null;
                        dpkClaim4.SelectedDate = null;
                        dpkClaim5.SelectedDate = null;
                        break;
                    case "3":
                        dpkClaim1.IsEnabled = true;
                        dpkClaim2.IsEnabled = true;
                        dpkClaim3.IsEnabled = true;
                        dpkClaim4.IsEnabled = false;
                        dpkClaim5.IsEnabled = false;
                        dpkClaim4.SelectedDate = null;
                        dpkClaim5.SelectedDate = null;
                        break;
                    case "4":
                        dpkClaim1.IsEnabled = true;
                        dpkClaim2.IsEnabled = true;
                        dpkClaim3.IsEnabled = true;
                        dpkClaim4.IsEnabled = true;
                        dpkClaim5.IsEnabled = false;
                        dpkClaim5.SelectedDate = null;

                        break;

                    case "5":
                        dpkClaim1.IsEnabled = true;
                        dpkClaim2.IsEnabled = true;
                        dpkClaim3.IsEnabled = true;
                        dpkClaim4.IsEnabled = true;
                        dpkClaim5.IsEnabled = true;

                        break;
                    default:
                        dpkClaim1.IsEnabled = false;
                        dpkClaim1.SelectedDate = null;
                        dpkClaim2.IsEnabled = false;
                        dpkClaim2.SelectedDate = null;
                        dpkClaim3.IsEnabled = false;
                        dpkClaim3.SelectedDate = null;
                        dpkClaim4.IsEnabled = false;
                        dpkClaim4.SelectedDate = null;
                        dpkClaim5.IsEnabled = false;
                        dpkClaim5.SelectedDate = null;
                        break;
                }
            }
            catch
            {
                DriverName = tbxName.Text;
                MessageBox.Show("Driver has more than 2 claims: " + DriverName);
            }
            DriverName = tbxName.Text;
            if (cbxNoClaims.SelectedItem.ToString() == "3" || cbxNoClaims.SelectedItem.ToString() == "4" || cbxNoClaims.SelectedItem.ToString() == "5")
            {
                MessageBox.Show("Driver has more than 2 claims: " + DriverName);
                cbxNoClaims.SelectedValue = "2";
              
            }
           
               
            


        }


        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            

            // making a tempPolicy to equal the policy so each calculation doesn't overwrite the previos calculation
            tempPolicy = policy;

            // calculation for Occupation Chauffeur
            try {
                if (cmbOccupation.SelectedItem.ToString() == Occumpation.Chauffeur.ToString())
                {

                    tempPolicy = (tempPolicy + tempPolicy * Chauffeur);
                    txtPolicy.Text = tempPolicy.ToString();
                }
                // calculation for Accountant Chauffeur
                else if (cmbOccupation.SelectedItem.ToString() == Occumpation.Accountant.ToString())
                {
                    tempPolicy = (tempPolicy - tempPolicy * Accountant);
                    txtPolicy.Text = tempPolicy.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                
            }




            DateTime birthDate = Convert.ToDateTime(dpkDOB.SelectedDate);

            if (birthDate.Age().Years() > 21 && birthDate.Age().Years() < 26)
            {
                driverAge2125();
                
            }
            else if (birthDate.Age().Years() > 26 && birthDate.Age().Years() < 76)
            {
                tempPolicy = (tempPolicy - tempPolicy * age2675);
                txtPolicy.Text = tempPolicy.ToString();
            }
            // Code for claim within the last year.
            DateTime Claim1 = Convert.ToDateTime(dpkClaim1.SelectedDate);
            DateTime Claim2 = Convert.ToDateTime(dpkClaim2.SelectedDate);
            DateTime Claim3 = Convert.ToDateTime(dpkClaim3.SelectedDate);
            DateTime Claim4 = Convert.ToDateTime(dpkClaim4.SelectedDate);
            DateTime Claim5 = Convert.ToDateTime(dpkClaim5.SelectedDate);

          
            // if driver has had a claim in the last year from the start policy
            DateTime StartPolicy = Convert.ToDateTime(dpkStartDateOfPolicy.SelectedDate);
            if ((StartPolicy - Claim1).Years() < 1)
            {
                claimOneYearMethod();
            }

            if (Claim1 > DateTime.Now)
            {
                MessageBox.Show("Claim 1 Date cannot be in the future");
            }
            if ((StartPolicy - Claim2).Years() < 1)
            {
                claimOneYearMethod();
            }
            if (Claim2 > DateTime.Now)
            {
                MessageBox.Show("Claim 2 Date cannot be in the future");
            }

            if ((StartPolicy - Claim3).Years() < 1)
            {
                claimOneYearMethod();
            }
            if (Claim3 > DateTime.Now)
            {
                MessageBox.Show("Claim 3 Date cannot be in the future");
            }
            if ((StartPolicy - Claim4).Years() < 1)
            {
                claimOneYearMethod();
            }
            if (Claim4 > DateTime.Now)
            {
                MessageBox.Show("Claim 4 Date cannot be in the future");
            }
            if ((StartPolicy - Claim5).Years() < 1)
            {
                claimOneYearMethod();
            }
            if (Claim5 > DateTime.Now)
            {
                MessageBox.Show("Claim 5 Date cannot be in the future");
            }
            // if driver has had a claim in the last 2 to 5 years
            if ((StartPolicy - Claim1).Years() >2 && (StartPolicy - Claim1).Years() <6)
            {
                claimTwoFiveYearMethod();
            }
            if ((StartPolicy - Claim2).Years() > 2 && (StartPolicy - Claim2).Years() < 6)
            {
                claimTwoFiveYearMethod();
            }
            if ((StartPolicy - Claim3).Years() > 2 && (StartPolicy - Claim3).Years() < 6)
            {
                claimTwoFiveYearMethod();
            }
            if ((StartPolicy - Claim4).Years() > 2 && (StartPolicy - Claim4).Years() < 6)
            {
                claimTwoFiveYearMethod();
            }
            if ((StartPolicy - Claim5).Years() > 2 && (StartPolicy - Claim5).Years() < 6)
            {
                claimTwoFiveYearMethod();
            }





            // ading drivers name to the listBox
            if (this.tbxName.Text != "")
            {
                lstDrivers.Items.Add(this.tbxName.Text);
                this.tbxName.Focus();
                this.tbxName.Clear();
                
            }
            else
            {
                MessageBox.Show("Please enter a name to add");
                this.tbxName.Focus();
            }
           
            if (this.txtPolicy.Text != "")
            {
                lstPolicy.Items.Add(this.txtPolicy.Text);
                this.txtPolicy.Focus();
                
            }
            foreach (var listbox in lstPolicy.Items)
            {
                if (lstPolicy.Items.Count > 0)
                {

                   
                    policy = (policy - policy + tempPolicy);
                    txtPolicy.Text = policy.ToString();
                }
            }

            decimal sum = 0;

            for (int i = 0; i < lstPolicy.Items.Count; i++)
            {
                sum += Convert.ToDecimal(lstPolicy.Items[i].ToString());

            }

            //for (int i=0; i < dpkClaim1.SelectedDate; i++)

            tbkTotalPolicy.Text = ("Total Policy is : £"+ (sum.ToString("F")));

            // if listBox has 5 drivers in it disable add driver button and show a message box
            if (lstPolicy.Items.Count == 5)
            {
                MessageBox.Show("Maximum drivers is 5");
                btnAddDriver.IsEnabled = false;
               
            }
            if(dpkDOB.SelectedDate == null)
            {
                MessageBox.Show("Date Of Birth must be entered");
            }

          

            
            


        }

        private void dpkStartDateOfPolicy_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {// show messageBox if start date of policy is in the future
            if (dpkStartDateOfPolicy.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Start Date of policy");
                dpkStartDateOfPolicy.SelectedDate = null;
                btnAddDriver.IsEnabled = false;
            }
            if (dpkStartDateOfPolicy.SelectedDate == null)
            {
                btnAddDriver.IsEnabled = false;
            }
            else
                btnAddDriver.IsEnabled = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {// disable button if fields are empty
            if (dpkStartDateOfPolicy.SelectedDate == null || dpkDOB .SelectedDate==null)
            {
                btnAddDriver.IsEnabled = false;
            }
            
            else
                btnAddDriver.IsEnabled = true;
        }

        private void dpkDOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //message box if driver is under 21
            DateTime birthDate = Convert.ToDateTime(dpkDOB.SelectedDate);
            DriverName = tbxName.Text;
            if (birthDate.Age().Years() < 21)
            {

                MessageBox.Show("Age of Youngest Driver: " + DriverName);
                
                btnAddDriver.IsEnabled = false;

            }
            // message box if driver is over 75
          else  if (birthDate.Age().Years() > 75)
            {

                MessageBox.Show("Age of Oldest Driver: " + DriverName);
                dpkDOB.SelectedDate = null;
                btnAddDriver.IsEnabled = false;

            }


            else
                btnAddDriver.IsEnabled = true;
        }
        // exit program
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
