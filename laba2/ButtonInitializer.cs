﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace laba2
{
    public partial class MainWindow : Window
    {
        public void InitializeButtons()
        {

            foreach (var obj in grid.Children)
            {
                if (obj is Button button)
                {
                    string[] buttonNameSplit = ((string)button.Name).Split('_');
                    if (buttonNameSplit[0] != "skip") AddButtonChars(button);

                    if (buttonNameSplit[0] == "digit")
                    {
                        button.Click += digitBtn_Click;
                        if (button.Content == null) button.Content = buttonNameSplit[1] == "Dot" ? "." : buttonNameSplit[1];
                    }

                    else if (buttonNameSplit[0] == "operation") 
                        button.Click += operationBtn_Click;

                }
            }

        }

        private void AddButtonChars(Button button)
        {
            button.VerticalAlignment = VerticalAlignment.Stretch;
            button.HorizontalAlignment = HorizontalAlignment.Stretch;
            button.Margin = new Thickness(2, 2, 2, 2);
            button.Background = Brushes.White;
            button.BorderBrush = null;
        }
    }
}
