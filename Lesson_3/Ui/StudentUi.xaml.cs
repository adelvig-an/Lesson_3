﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson_3.Ui
{
    /// <summary>
    /// Логика взаимодействия для StudentUi.xaml
    /// </summary>
    public partial class StudentUi : UserControl
    {
        public StudentUi()
        {
            InitializeComponent();
        }

        private void dgStudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
