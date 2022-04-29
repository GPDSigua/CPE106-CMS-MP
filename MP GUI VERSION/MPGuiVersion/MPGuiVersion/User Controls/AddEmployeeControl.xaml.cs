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

using System.Data;
using System.Data.SqlClient;

namespace MPGuiVersion.User_Controls
{
    /// <summary>
    /// Interaction logic for AddEmployeeControl.xaml
    /// </summary>
    public partial class AddEmployeeControl : UserControl
    {
        public AddEmployeeControl()
        {
            InitializeComponent();
        }

        private void AddEmployeeProfileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee ret = new Employee
            {
                FirstName = firstName.Text,
                MiddleName = middleName.Text,
                LastName = lastName.Text,
                Suffix = suffix.Text,
                Sex = sex.Text,
                Department = department.Text,
                Position = position.Text,
                EmailAddress = emailAddress.Text,
                Salary = Convert.ToDouble(salary.Text),
                EmployeeID = Convert.ToInt32(employeeID.Text)
            };

            SqlConnection conn;
            string message;
            bool state;
            DatabaseConnection.connectToSQL(out conn, out state, out message);
            DatabaseConnection.addEmployees(conn, ret);
            DatabaseConnection.disconnectSQL(conn, out state);
        }

        private void AddHealthRecordBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RestFieldsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
