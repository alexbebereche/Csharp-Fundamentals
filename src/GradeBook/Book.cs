using System.Collections.Generic;
using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); // convention when events: 2 param

    public class Book // basic is internal: can only be used in the project
    {
        // have to be explicit, cant use var
        // List<double> grades;
        private List<double> grades; // = new List<double>();
        // public string Name; // public member, uppercase

        // when reading the property, invoke the getter
        private string name;
        // public string Name{
        //     get{
        //         return name;
        //     }
        //     set{
        //         if(!string.IsNullOrEmpty(value)){
        //             name = value; // value is an implicit value
        //         }
        //     }
        // }

        public event GradeAddedDelegate GradeAdded; 


        // auto-property
        public string Name{
            get; set; //private set; // any op that wants to write...
        }  // might be different in serialization...
        // in older versions, we only could store it in a field...


        // readonly string category = "Science"; // can only initialize or change in the constructor
        public const string CATEGORY = "Science"; // now can't change it anymore
        // no need to have a property
        // const are treated like static members of the class
        public Book(string name){
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(double grade){
            grades.Add(grade);
            if(GradeAdded != null){
                // if its null, no one is listening
                GradeAdded(this, new EventArgs());  // i am the sender
            }
        }

        public double ShowStatistics(){
            var sum = 0.0;
            foreach(double grade in grades){
                sum += grade;
            }

            if(grades.Count > 0){
                return sum / grades.Count;
            }
            else{
                return 0;
            }
        }
    
    }
}