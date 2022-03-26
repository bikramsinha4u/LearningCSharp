using System;
using System.Text.RegularExpressions;

namespace LearningCSharp
{
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        public Student(string name)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(name))
                throw new InvalidStudentNameException($"Invalid Student Name: {name}");

        }
    }

    // Use at least the three common constructors when creating your own exception classes:
    // the parameterless constructor,
    // a constructor that takes a string message, and
    // a constructor that takes a string message and an inner exception.
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException() { }

        public InvalidStudentNameException(string message)
            : base(String.Format(message))
        {

        }

        public InvalidStudentNameException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
