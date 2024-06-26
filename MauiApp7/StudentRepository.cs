﻿using MauiApp7.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp7
{
    public class StudentRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Student>();
        }

        public StudentRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewStudent(string name)
        {
            int result = 0;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = conn.Insert(new Student { Name = name });

                StatusMessage = string.Format("Record added (Name: {1})", result, name);
           
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add{0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Student> GetSection()
        {
            try
            {
                Init();
                return conn.Table<Student>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Student>();
        }
    }
}
