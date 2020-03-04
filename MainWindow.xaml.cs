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

namespace WriteABook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBabyNames_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string yearToLookFor = "2003";

                System.IO.StreamReader sr =
                    new System.IO.StreamReader("ontario_top_baby_names_male_1917-2016_english.txt");
                string output = "";
                string line;
                int positionOfFirstComma = -1;
                int positionOfSecondComma = -1;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    //MessageBox.Show(line);
                    positionOfFirstComma = line.IndexOf(",");
                   // MessageBox.Show(positionOfFirstComma.ToString());
                    string year = line.Substring(0, positionOfFirstComma);

                    if (year == yearToLookFor)
                    {
                        positionOfSecondComma = line.IndexOf(",", positionOfFirstComma + 1);
                        if (line.Substring(positionOfFirstComma + 1, positionOfSecondComma - positionOfFirstComma - 1) 
                            == "DAFFY")
                        {
                            
                            MessageBox.Show(line);
                            MessageBox.Show(line.Substring(positionOfFirstComma + 1, positionOfSecondComma - positionOfFirstComma - 1));
                        }

                    }
                   // MessageBox.Show("year: " + line.Substring(0, positionOfFirstComma));
                }
                lblOutput.Content = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
