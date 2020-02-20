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
using System.Windows.Forms;
using System.Diagnostics;

namespace Sudoku
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public static class GlobalStop
    {
        static bool _stop;

        public static bool Stop
        {
            get
            {
                return _stop;
            }
            set
            {
                _stop = value;
            }
        }
    }

    public partial class MainWindow : Window
    {

        public bool CheckRow(uint row, bool check, uint[,] SudokuData)
        {
            uint numberCount;
            for (uint column = 0; column < 9; column++)
            {
                numberCount = 0;
                for (uint number = 0; number<9; number++)
                {
                    if (SudokuData[row, number] == column+1)
                    {
                        numberCount++;
                    }
                }

                if (numberCount > 1)
                {
                    check = false;
                }

            }
            return check;          
        }

        public bool CheckColumn(uint column, bool check, uint[,] SudokuData)
        {
            uint numberCount;
            for (uint row = 0; row < 9; row++)
            {
                numberCount = 0;
                for (uint number = 0; number < 9; number++)
                {
                    if (SudokuData[number, column] == row + 1)
                    {
                        numberCount++;
                    }
                }

                if (numberCount > 1)
                {
                    check = false;
                }

            }
            return check;
        }

        public bool CheckBox(uint boxRow, uint boxColumn, bool check, uint[,] SudokuData)
        {
            if (boxRow < 3)
            {
                boxRow = 0;
            } else if (boxRow < 6 && boxRow > 2)
            {
                boxRow = 3;
            } else if (boxRow < 9 && boxRow > 5)
            {
                boxRow = 6;
            } else
            {
                check = false;
            }
            if (boxColumn < 3)
            {
                boxColumn = 0;
            }
            else if (boxColumn < 6 && boxColumn > 2)
            {
                boxColumn = 3;
            }
            else if (boxColumn < 9 && boxColumn > 5)
            {
                boxColumn = 6;
            }
            else
            {
                check = false;
            }

            if (check)
            {
                uint numberCount;
                for (uint i = 0; i < 9; i++)
                {
                    numberCount = 0;
                    for (uint m = boxRow; m < boxRow+3; m++)
                    {
                        for (uint n = boxColumn; n< boxColumn+3; n++)
                        {
                            if (SudokuData[m,n] == i + 1)
                            {
                                numberCount++;
                            }
                        }
                    
                    }

                    if (numberCount > 1)
                    {
                        check = false;
                    }
                }
            }
            return check;
        }


        public void ProgrBar(uint m, uint n)
        {
            ProgressBar.Maximum = 81;
            ProgressBar.Value = (m+1)* 9 + (n+1);
        }

        public void printMatrix(uint[,] SudokuData)
        {
            // Print Matrix
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(string.Format("{0} ", SudokuData[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public uint[,] readData()
        {
            uint[,] SudokuData = new uint[9, 9];

            if (!uint.TryParse(A1.Text, out SudokuData[0, 0])) { SudokuData[0, 0] = 0; } else { A1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A2.Text, out SudokuData[0, 1])) { SudokuData[0, 1] = 0; } else { A2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A3.Text, out SudokuData[0, 2])) { SudokuData[0, 2] = 0; } else { A3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A4.Text, out SudokuData[0, 3])) { SudokuData[0, 3] = 0; } else { A4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A5.Text, out SudokuData[0, 4])) { SudokuData[0, 4] = 0; } else { A5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A6.Text, out SudokuData[0, 5])) { SudokuData[0, 5] = 0; } else { A6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A7.Text, out SudokuData[0, 6])) { SudokuData[0, 6] = 0; } else { A7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A8.Text, out SudokuData[0, 7])) { SudokuData[0, 7] = 0; } else { A8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(A9.Text, out SudokuData[0, 8])) { SudokuData[0, 8] = 0; } else { A9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(B1.Text, out SudokuData[1, 0])) { SudokuData[1, 0] = 0; } else { B1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B2.Text, out SudokuData[1, 1])) { SudokuData[1, 1] = 0; } else { B2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B3.Text, out SudokuData[1, 2])) { SudokuData[1, 2] = 0; } else { B3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B4.Text, out SudokuData[1, 3])) { SudokuData[1, 3] = 0; } else { B4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B5.Text, out SudokuData[1, 4])) { SudokuData[1, 4] = 0; } else { B5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B6.Text, out SudokuData[1, 5])) { SudokuData[1, 5] = 0; } else { B6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B7.Text, out SudokuData[1, 6])) { SudokuData[1, 6] = 0; } else { B7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B8.Text, out SudokuData[1, 7])) { SudokuData[1, 7] = 0; } else { B8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(B9.Text, out SudokuData[1, 8])) { SudokuData[1, 8] = 0; } else { B9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(C1.Text, out SudokuData[2, 0])) { SudokuData[2, 0] = 0; } else { C1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C2.Text, out SudokuData[2, 1])) { SudokuData[2, 1] = 0; } else { C2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C3.Text, out SudokuData[2, 2])) { SudokuData[2, 2] = 0; } else { C3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C4.Text, out SudokuData[2, 3])) { SudokuData[2, 3] = 0; } else { C4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C5.Text, out SudokuData[2, 4])) { SudokuData[2, 4] = 0; } else { C5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C6.Text, out SudokuData[2, 5])) { SudokuData[2, 5] = 0; } else { C6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C7.Text, out SudokuData[2, 6])) { SudokuData[2, 6] = 0; } else { C7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C8.Text, out SudokuData[2, 7])) { SudokuData[2, 7] = 0; } else { C8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(C9.Text, out SudokuData[2, 8])) { SudokuData[2, 8] = 0; } else { C9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(D1.Text, out SudokuData[3, 0])) { SudokuData[3, 0] = 0; } else { D1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D2.Text, out SudokuData[3, 1])) { SudokuData[3, 1] = 0; } else { D2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D3.Text, out SudokuData[3, 2])) { SudokuData[3, 2] = 0; } else { D3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D4.Text, out SudokuData[3, 3])) { SudokuData[3, 3] = 0; } else { D4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D5.Text, out SudokuData[3, 4])) { SudokuData[3, 4] = 0; } else { D5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D6.Text, out SudokuData[3, 5])) { SudokuData[3, 5] = 0; } else { D6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D7.Text, out SudokuData[3, 6])) { SudokuData[3, 6] = 0; } else { D7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D8.Text, out SudokuData[3, 7])) { SudokuData[3, 7] = 0; } else { D8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(D9.Text, out SudokuData[3, 8])) { SudokuData[3, 8] = 0; } else { D9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(E1.Text, out SudokuData[4, 0])) { SudokuData[4, 0] = 0; } else { E1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E2.Text, out SudokuData[4, 1])) { SudokuData[4, 1] = 0; } else { E2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E3.Text, out SudokuData[4, 2])) { SudokuData[4, 2] = 0; } else { E3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E4.Text, out SudokuData[4, 3])) { SudokuData[4, 3] = 0; } else { E4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E5.Text, out SudokuData[4, 4])) { SudokuData[4, 4] = 0; } else { E5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E6.Text, out SudokuData[4, 5])) { SudokuData[4, 5] = 0; } else { E6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E7.Text, out SudokuData[4, 6])) { SudokuData[4, 6] = 0; } else { E7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E8.Text, out SudokuData[4, 7])) { SudokuData[4, 7] = 0; } else { E8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(E9.Text, out SudokuData[4, 8])) { SudokuData[4, 8] = 0; } else { E9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(F1.Text, out SudokuData[5, 0])) { SudokuData[5, 0] = 0; } else { F1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F2.Text, out SudokuData[5, 1])) { SudokuData[5, 1] = 0; } else { F2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F3.Text, out SudokuData[5, 2])) { SudokuData[5, 2] = 0; } else { F3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F4.Text, out SudokuData[5, 3])) { SudokuData[5, 3] = 0; } else { F4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F5.Text, out SudokuData[5, 4])) { SudokuData[5, 4] = 0; } else { F5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F6.Text, out SudokuData[5, 5])) { SudokuData[5, 5] = 0; } else { F6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F7.Text, out SudokuData[5, 6])) { SudokuData[5, 6] = 0; } else { F7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F8.Text, out SudokuData[5, 7])) { SudokuData[5, 7] = 0; } else { F8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(F9.Text, out SudokuData[5, 8])) { SudokuData[5, 8] = 0; } else { F9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(G1.Text, out SudokuData[6, 0])) { SudokuData[6, 0] = 0; } else { G1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G2.Text, out SudokuData[6, 1])) { SudokuData[6, 1] = 0; } else { G2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G3.Text, out SudokuData[6, 2])) { SudokuData[6, 2] = 0; } else { G3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G4.Text, out SudokuData[6, 3])) { SudokuData[6, 3] = 0; } else { G4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G5.Text, out SudokuData[6, 4])) { SudokuData[6, 4] = 0; } else { G5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G6.Text, out SudokuData[6, 5])) { SudokuData[6, 5] = 0; } else { G6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G7.Text, out SudokuData[6, 6])) { SudokuData[6, 6] = 0; } else { G7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G8.Text, out SudokuData[6, 7])) { SudokuData[6, 7] = 0; } else { G8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(G9.Text, out SudokuData[6, 8])) { SudokuData[6, 8] = 0; } else { G9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(H1.Text, out SudokuData[7, 0])) { SudokuData[7, 0] = 0; } else { H1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H2.Text, out SudokuData[7, 1])) { SudokuData[7, 1] = 0; } else { H2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H3.Text, out SudokuData[7, 2])) { SudokuData[7, 2] = 0; } else { H3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H4.Text, out SudokuData[7, 3])) { SudokuData[7, 3] = 0; } else { H4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H5.Text, out SudokuData[7, 4])) { SudokuData[7, 4] = 0; } else { H5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H6.Text, out SudokuData[7, 5])) { SudokuData[7, 5] = 0; } else { H6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H7.Text, out SudokuData[7, 6])) { SudokuData[7, 6] = 0; } else { H7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H8.Text, out SudokuData[7, 7])) { SudokuData[7, 7] = 0; } else { H8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(H9.Text, out SudokuData[7, 8])) { SudokuData[7, 8] = 0; } else { H9.FontWeight = FontWeights.Bold; }

            if (!uint.TryParse(I1.Text, out SudokuData[8, 0])) { SudokuData[8, 0] = 0; } else { I1.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I2.Text, out SudokuData[8, 1])) { SudokuData[8, 1] = 0; } else { I2.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I3.Text, out SudokuData[8, 2])) { SudokuData[8, 2] = 0; } else { I3.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I4.Text, out SudokuData[8, 3])) { SudokuData[8, 3] = 0; } else { I4.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I5.Text, out SudokuData[8, 4])) { SudokuData[8, 4] = 0; } else { I5.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I6.Text, out SudokuData[8, 5])) { SudokuData[8, 5] = 0; } else { I6.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I7.Text, out SudokuData[8, 6])) { SudokuData[8, 6] = 0; } else { I7.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I8.Text, out SudokuData[8, 7])) { SudokuData[8, 7] = 0; } else { I8.FontWeight = FontWeights.Bold; }
            if (!uint.TryParse(I9.Text, out SudokuData[8, 8])) { SudokuData[8, 8] = 0; } else { I9.FontWeight = FontWeights.Bold; }


            //SudokuData[0, 0]

            return SudokuData;
        }

        public void displayData(uint[,] SudokuData)
        {
            A1.Text = SudokuData[0, 0].ToString();
            A2.Text = SudokuData[0, 1].ToString();
            A3.Text = SudokuData[0, 2].ToString();
            A4.Text = SudokuData[0, 3].ToString();
            A5.Text = SudokuData[0, 4].ToString();
            A6.Text = SudokuData[0, 5].ToString();
            A7.Text = SudokuData[0, 6].ToString();
            A8.Text = SudokuData[0, 7].ToString();
            A9.Text = SudokuData[0, 8].ToString();

            B1.Text = SudokuData[1, 0].ToString();
            B2.Text = SudokuData[1, 1].ToString();
            B3.Text = SudokuData[1, 2].ToString();
            B4.Text = SudokuData[1, 3].ToString();
            B5.Text = SudokuData[1, 4].ToString();
            B6.Text = SudokuData[1, 5].ToString();
            B7.Text = SudokuData[1, 6].ToString();
            B8.Text = SudokuData[1, 7].ToString();
            B9.Text = SudokuData[1, 8].ToString();

            C1.Text = SudokuData[2, 0].ToString();
            C2.Text = SudokuData[2, 1].ToString();
            C3.Text = SudokuData[2, 2].ToString();
            C4.Text = SudokuData[2, 3].ToString();
            C5.Text = SudokuData[2, 4].ToString();
            C6.Text = SudokuData[2, 5].ToString();
            C7.Text = SudokuData[2, 6].ToString();
            C8.Text = SudokuData[2, 7].ToString();
            C9.Text = SudokuData[2, 8].ToString();

            D1.Text = SudokuData[3, 0].ToString();
            D2.Text = SudokuData[3, 1].ToString();
            D3.Text = SudokuData[3, 2].ToString();
            D4.Text = SudokuData[3, 3].ToString();
            D5.Text = SudokuData[3, 4].ToString();
            D6.Text = SudokuData[3, 5].ToString();
            D7.Text = SudokuData[3, 6].ToString();
            D8.Text = SudokuData[3, 7].ToString();
            D9.Text = SudokuData[3, 8].ToString();

            E1.Text = SudokuData[4, 0].ToString();
            E2.Text = SudokuData[4, 1].ToString();
            E3.Text = SudokuData[4, 2].ToString();
            E4.Text = SudokuData[4, 3].ToString();
            E5.Text = SudokuData[4, 4].ToString();
            E6.Text = SudokuData[4, 5].ToString();
            E7.Text = SudokuData[4, 6].ToString();
            E8.Text = SudokuData[4, 7].ToString();
            E9.Text = SudokuData[4, 8].ToString();

            F1.Text = SudokuData[5, 0].ToString();
            F2.Text = SudokuData[5, 1].ToString();
            F3.Text = SudokuData[5, 2].ToString();
            F4.Text = SudokuData[5, 3].ToString();
            F5.Text = SudokuData[5, 4].ToString();
            F6.Text = SudokuData[5, 5].ToString();
            F7.Text = SudokuData[5, 6].ToString();
            F8.Text = SudokuData[5, 7].ToString();
            F9.Text = SudokuData[5, 8].ToString();

            G1.Text = SudokuData[6, 0].ToString();
            G2.Text = SudokuData[6, 1].ToString();
            G3.Text = SudokuData[6, 2].ToString();
            G4.Text = SudokuData[6, 3].ToString();
            G5.Text = SudokuData[6, 4].ToString();
            G6.Text = SudokuData[6, 5].ToString();
            G7.Text = SudokuData[6, 6].ToString();
            G8.Text = SudokuData[6, 7].ToString();
            G9.Text = SudokuData[6, 8].ToString();

            H1.Text = SudokuData[7, 0].ToString();
            H2.Text = SudokuData[7, 1].ToString();
            H3.Text = SudokuData[7, 2].ToString();
            H4.Text = SudokuData[7, 3].ToString();
            H5.Text = SudokuData[7, 4].ToString();
            H6.Text = SudokuData[7, 5].ToString();
            H7.Text = SudokuData[7, 6].ToString();
            H8.Text = SudokuData[7, 7].ToString();
            H9.Text = SudokuData[7, 8].ToString();

            I1.Text = SudokuData[8, 0].ToString();
            I2.Text = SudokuData[8, 1].ToString();
            I3.Text = SudokuData[8, 2].ToString();
            I4.Text = SudokuData[8, 3].ToString();
            I5.Text = SudokuData[8, 4].ToString();
            I6.Text = SudokuData[8, 5].ToString();
            I7.Text = SudokuData[8, 6].ToString();
            I8.Text = SudokuData[8, 7].ToString();
            I9.Text = SudokuData[8, 8].ToString();

        }

        public void paintGUI(uint m, uint n, uint cycle, uint[,] SudokuData, Stopwatch stopWatch)
        {
            mText.Text = m.ToString();
            nText.Text = n.ToString();
            CyclesText.Text = cycle.ToString();
            displayData(SudokuData);
            ProgrBar(m, n);

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            timeBox.Text = elapsedTime;

            System.Windows.Forms.Application.DoEvents();
        }

        public MainWindow()
        {
            InitializeComponent();
            debugCanvas.Visibility = Visibility.Collapsed;
            stopButton.Visibility = Visibility.Collapsed;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            

            //uint[,] SudokuData = new uint[9, 9] {   {0,0,6,7,0,0,0,4,0},
            //                                        {1,2,0,9,0,0,0,8,0},
            //                                        {0,0,7,0,3,0,9,0,0},
            //                                        {0,0,0,6,0,3,0,7,5},
            //                                        {0,0,9,0,0,0,3,0,0},
            //                                        {8,6,0,5,0,1,0,0,0},
            //                                        {6,0,1,0,2,0,4,0,0},
            //                                        {0,4,0,0,0,6,0,2,9},
            //                                        {0,3,0,0,0,7,6,0,0}
            //                                     };

            uint[,] SudokuData = new uint[9, 9];
            SudokuData = readData();

            uint[,] SudokuDataNew = new uint[9, 9];
            SudokuDataNew = SudokuData.Clone() as uint[,];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            GlobalStop.Stop = false;
            stopButton.Visibility = Visibility.Visible;

            uint m = 0; // row
            uint n = 0; // column
            uint cycle = 0;
            bool check = false;
            bool run = true;
            bool backtrack = false;

            // Loop
            while (!GlobalStop.Stop)
            {
                if (SudokuData[m,n] == 0) // if field empty
                {
                    backtrack = false;
                    SudokuDataNew[m, n]++;
                    if (SudokuDataNew[m, n] > 9) // if number is invalid reset number and go to last position
                    {
                        backtrack = true;
                        SudokuDataNew[m, n] = 0;
                        if (n == 0)
                        {
                            n = 8;
                            m--;
                        }
                        else
                        {
                            n--;
                        }

                    }
                    else // if number valid
                    {
                        // Check plausability
                        check = true;
                        check = CheckRow(m, check, SudokuDataNew); 
                        check = CheckColumn(n, check, SudokuDataNew);
                        check = CheckBox(m, n, check, SudokuDataNew);

                        StatusText.Text = check.ToString();

                        if (check) // if plausible go to next position
                        {
                            n++;
                            if (n == 9)
                            {
                                n = 0;
                                m++;
                            }
                            if (m == 9)
                            {
                                GlobalStop.Stop = true;
                            }
                        } // else restart loop
                    }
                    
                } else { // if field full 
                    if (!backtrack) // skip position
                    {
                        n++;
                        if (n == 9)
                        {
                            n = 0;
                            m++;
                        }
                        if (m == 9)
                        {
                            GlobalStop.Stop = true;
                        }
                    }
                    else // go to last position
                    {
                        if (n == 0)
                        {
                            n = 8;
                            m--;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    
                }

                cycle++;
                if((bool)cycleBox.IsChecked)
                {
                    paintGUI(m, n, cycle, SudokuDataNew, stopWatch);
                }
                
            }

            stopWatch.Stop();
            stopButton.Visibility = Visibility.Collapsed;
            paintGUI(m, n, cycle, SudokuDataNew, stopWatch);
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalStop.Stop = true;
        }
    }
}
