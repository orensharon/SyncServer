﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    class UsersDAL : DB
    {

        /*
         * From a given username and password make attemp to login
         * If username and password incorrect - return -1 otherwise return user id
         */   
        public int Login(string username, string password)
        {
            
            string sqlString;
            SqlDataReader rdr;

           
            // SQL query
            sqlString = @"SELECT user_id
                                FROM Users
                                WHERE username = '" + username + "' AND password = '" + password +"'";
            
            // Execute query
            rdr = executeQuery(sqlString);


            // Handle returns items from database
            if (rdr.Read())
            {
                // TODO: make sure user realy exists
                return Convert.ToInt32(rdr["user_id"]);
            }

            // User doesn't exist
            return -1;
        }


        public bool SignIn(string username, string password)
        {
            // TODO: check if database already has a username such as given. If exist return false
            // If not exist then create a new record with username and password, make login, save season and return true
            return true;
        }
    }
}
