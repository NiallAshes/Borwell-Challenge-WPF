using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeContent
// Original Task assignement can be found via this link: https://borwell.com/career/ , under 'Software Engineering Jobs'
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// --> I.e. What interactions occur within the main window of the
    ///   program and what code causes these interactions to occur.
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Calculator_Click(object sender, RoutedEventArgs e)
        {
            // --> Sorting the contents of the first text-box as Length
            // --> This is the least efficient format for the process
            string sLengthValue;
            double dLengthValue;
            bool bLengthSuccess = false;

            sLengthValue = textBox_LengthInput.Text;
            bLengthSuccess = double.TryParse(sLengthValue, out dLengthValue);
            
            if (!bLengthSuccess)
            {
                Label_LengthError.Content = "Please enter a valid numerical Length value" ;
            }
            
            else if (bLengthSuccess)
            {
                Label_LengthError.Content = "." ;
            }



            // --> Sorting the contents of the second text-box as Width
            // --> This is a more efficient format for the process as it
            //    uses far less lines of code and is still clear to read
            double dWidthValue = 0;

            string sWidthValue = textBox_WidthInput.Text;
            double.TryParse(sWidthValue, out dWidthValue);

            if (dWidthValue == 0)
            {
                Label_WidthError.Content = "Please enter a valid numerical Width value";
            }

            else
            {
                Label_WidthError.Content = ".";
            }


            
            // --> Sorting the contents of the third text-box as Height
            // --> This is the same as it was for the Width
            // --> A far more efficient route to take would have been using
            //    a method / function that works across all three values
            double dHeightValue = 0;

            string sHeightValue = textBox_HeightInput.Text;
            double.TryParse(sHeightValue, out dHeightValue);

            if (dHeightValue == 0)
            {
                Label_HeightError.Content = "Please enter a valid numerical Height value";
            }

            else
            {
                Label_HeightError.Content = ".";
            }




                //  CALCULATIONS

            // --> Calculating the area of the floor in the room
            double AreaOfFloor = (dWidthValue * dLengthValue);

            // --> Calculating the combined Surface Area of all the walls in the room
            double WallSurfaceArea = ((2 * (dLengthValue * dHeightValue)) + (2 * (dWidthValue * dHeightValue)));

            // --> Calculating the amount of paint required given that the average surface
            //    area coverage for paint is 10 metres squared per litre (according to Homebase)
            double PaintNeeded = (WallSurfaceArea / 10);

            // --> Calculating the total Volume of the room
            double RoomVolume = (dLengthValue * dWidthValue * dHeightValue);




                //  RESULTS (OUTPUT)

            // --> Given an invalid input, these error messages appear
            if (Label_LengthError.Content != "." | Label_WidthError.Content != "." | Label_HeightError.Content != ".")
            {
                Label_AreaFinal.Content = ("Failure - Please check the values entered");
                Label_PaintRequiredFinal.Content = ("Failure - Please check the values entered");
                Label_VolumeFinal.Content = ("Failure - Please check the values entered");
            }

            // --> Outputting the values for the user
            else
            {
                Label_AreaFinal.Content = (AreaOfFloor + " metres squared");
                Label_PaintRequiredFinal.Content = ((Math.Round(PaintNeeded, 3)) + " litres squared");
                Label_VolumeFinal.Content = (RoomVolume + " metres cubed");
            }
        }
    }
}
