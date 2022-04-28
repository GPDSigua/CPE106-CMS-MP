﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace MPGuiVersion
{
    public static class DatabaseConnection
    {
        public static void connectToSQL(out SqlConnection sql_conn, out bool connected, out string message)
        {
            // Try - Except Block, just in case SQL Connection Fails
            try
            {
                // Connection String based on Server Connector by Visual Studio
                string connection_string = "Data Source=ASUS-ACE;Initial Catalog=CMSData;Integrated Security=True";

                // Creates new Connection Object based on connection string
                sql_conn = new SqlConnection(connection_string);

                // Opens the Connection
                sql_conn.Open();

                //MessageBox.Show("Connection with the CMSData was succesfully established");
                connected = true; // Used for testing purposes
                message = "Connected";
            }
            catch (Exception ex)
            {
                // Connection Failed
                sql_conn = null;
                message = $"An Exception has occurred: \n{ex.Message}";
                connected = false;

            }

        }

        public static DataView getEmployees(SqlConnection conn)
        {
            SqlCommand SP_getemployees = new SqlCommand("getAllEmployees", conn);
            SP_getemployees.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter SDA = new SqlDataAdapter(SP_getemployees);
            DataTable DT = new DataTable("Employees");
            SDA.Fill(DT);
            return DT.DefaultView;

        }


        static void getData(bool connected, string table, string column, string new_data, string condition, string value, out SqlDataReader results, SqlConnection sql_conn)
        {
            string sql_string_command = $"SELECT {column} FROM {table} WHERE {condition} = '{value}'";
            SqlCommand sql_command = new SqlCommand(sql_string_command, sql_conn);

            results = sql_command.ExecuteReader();

            if (connected)
            {
                results = null;
                return;
            }

        }

        static void removeData(bool connected, string table, string column, string new_data, out string exception, SqlConnection sql_conn)
        {
            try
            {
                exception = "";
            } catch (Exception ex) {
                exception = ex.Message;

            }
                
        }

        static void insertData(bool connected, string table, string column, string new_data, out string exception, SqlConnection sql_conn)
        {
            try
            {
                string search_comm = $"INSERT INTO {table} VALUES ({new_data})";
                exception = "";
            }
            catch (Exception ex)
            {
                exception = ex.Message;

            }
        }
        static void updateData(bool connected, string table, string column, string new_data, out string exception, SqlConnection sql_conn)
        {
            try
            {
                exception = "";
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
        }

        static void tableInspection(string[] tables, SqlConnection sql_conn)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        static void checkIfTableExists(string table, SqlConnection sql_conn)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}