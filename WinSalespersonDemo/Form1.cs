using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSalespersonDemo
{
    public partial class Form1 : Form
    {
        //instance variables
        Point _createBtnOriginalLocation; 
        private string _operationType;
        private const string REALESTATE="RealEstate";
        private const string GIRSCOUT = "GirlScout";
        private RealEstateSalesperson _realEstateSalesperson;
        private GirlScout _girlScout;
        private Validate _validate;

        //constructor
        public Form1()
        {
            InitializeComponent();
            _createBtnOriginalLocation = CreateBtn.Location;
            _validate = new Validate();
        }

        //form load method
        private void Form1_Load(object sender, EventArgs e)
        {
            var size = new System.Drawing.Size();//new size object
            size.Height = this.Height/3; //set the height property of size obj
            size.Width = this.Width;//set the width property of size obj
            panel2.Visible = false; //set the visibility property to false
            panel3.Visible = false;//set the visibility property to false
            panel4.Visible = false;//set the visibility property to false
            this.Size = size; //set the size of the form to the value of size
            MakeSaleBtn.Enabled = false;
        }

        //create real estate button is press
        private void CreateRealEstateBtn_Click(object sender, EventArgs e)
        {
            SetControls();//method call to make controls visible or disable

            //set the image of the imgaBox control
            imageBox.Image = WinSalespersonDemo.Properties.Resources.salesperson_clipart_1_300x200;

            //show the CommissionRateLbl
            CommissionRateLbl.Show();

            //show the  CommisionRateTextBox
            CommisionRateTextBox.Show();

            //hide panel6 
            panel6.Hide();

            //show panel5
            panel5.Show();

            //set the location property of createBtn
            CreateBtn.Location =_createBtnOriginalLocation;

            //disabled the button that trigger this event
            ((Button)sender).Enabled = false;

            //instance variable assignment
            _operationType = REALESTATE;

            //enable the  CreateGirlScoutBtn button
            CreateGirlScoutBtn.Enabled = true;
            SaleSpeechLbl.Text = "";
            SummaryLbl.Text = "";
            MakeSaleBtn.Enabled = false;
        }

        private void SetControls()
        {
            this.Height = this.Height * 3;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;          
        }

        private void CreateGirlScoutBtn_Click(object sender, EventArgs e)
        {
            SetControls();
            CommissionRateLbl.Hide();
            CommisionRateTextBox.Hide();
            panel5.Hide();
            panel6.Location = panel5.Location;
            panel6.Visible = true;
            CreateBtn.Location = CommisionRateTextBox.Location;
            _operationType = GIRSCOUT;
            ((Button)sender).Enabled = false;
            CreateRealEstateBtn.Enabled = true;
            imageBox.Image = WinSalespersonDemo.Properties.Resources.girlsScout;
            SaleSpeechLbl.Text = "";
            SummaryLbl.Text = "";
            MakeSaleBtn.Enabled = false;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            bool isValid; //determine if validation is successful

            switch (_validate.Name(FirstnameTextBox.Text,LastNameTextBox.Text))
            {
                case false: //first and last name did not validate successfully
                    MessageBox.Show("First and last names are require"); //show message dialog
                    break; //breake out of the switch statement

                case true: //first and last names validated successfully

                    //the value of _operationType equals the value of REALESTATE
                    if (_operationType == REALESTATE)
                    {
                        try
                        {

                            //validate commissionRate
                            isValid = _validate.CommisionRate(Convert.ToDouble(CommisionRateTextBox.Text));

                            //commissionRate is valid
                            if (isValid)
                            {
                                //new instance of RealEstateSalesperson
                                _realEstateSalesperson = new RealEstateSalesperson(Convert.ToDouble(CommisionRateTextBox.Text),FirstnameTextBox.Text,LastNameTextBox.Text);

                                //set the text property
                                SaleSpeechLbl.Text = _realEstateSalesperson.SalesSpeech();

                                MakeSaleBtn.Enabled = true;
                            }

                            ////commission rate is not valid
                            else
                            {
                                //show message box
                                MessageBox.Show("Commision rate is require and must be a positive number");
                            }
                        }

                        //program encounter error
                        catch (FormatException ex)
                        {
                            //show message dialog
                            MessageBox.Show("Commission rate must be an integer");
                        }
                       
                    }

                    //the value of _operationType equals the value of GIRSCOUTT
                    else if (_operationType == GIRSCOUT)
                    {      
                        //new instance of Girscout            
                            _girlScout = new GirlScout(0, FirstnameTextBox.Text, LastNameTextBox.Text);
                        
                        //set the text property
                        SaleSpeechLbl.Text = _girlScout.SalesSpeech();
                        MakeSaleBtn.Enabled = true;
                    }
                    break;//break out of the switch statement
            }
            
        }

        //make sales button is press
        private void MakeSaleBtn_Click(object sender, EventArgs e)
        {
            bool isValid;

            //the value of _operationType equals the value of REALESTATE
            if (_operationType == REALESTATE)
            {
                try
                {
                    double houseValue = Convert.ToDouble(HouseValueTextBox.Text);
                    isValid = _validate.HouseValue(houseValue);
                    if (isValid)
                    {
                        _realEstateSalesperson.TotalValueSold = houseValue;
                        _realEstateSalesperson.MakeSale();
                        SummaryLbl.Text = _realEstateSalesperson.Summary();
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("House value must be a valid number");
                }
               
            }

            //the value of _operationType equals the value of GIRSCOUTT
            else if (_operationType == GIRSCOUT)
            {
                try
                {
                    isValid = _validate.NumberOfBoxes(Convert.ToInt16(NumberOfBoxesTxt.Text));
                    if (isValid)
                    {
                        _girlScout.NumberOfCookiesBoxesSold = Convert.ToInt16(NumberOfBoxesTxt.Text);
                        _girlScout.MakeSale();
                        SummaryLbl.Text = _girlScout.Summary;
                    }
                    else
                    {
                        MessageBox.Show("Number of boxes is require");
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Number of boxes must be a valid number");
                }
              
            }
        }

        //exit button is press
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //exit the application
            this.Close();
        }

        
    }
}
