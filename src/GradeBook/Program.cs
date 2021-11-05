using System;  // namespace
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            List<int> grades = new List<int>();
            grades.Add(1);
            grades.Add(10);
            grades.Add(15);

            Console.WriteLine(grades.Count);
          
            
        

            // Console.WriteLine("Hello " + args[0] + "!");  
            // $ string interpolation
            if(args.Length > 0){
                Console.WriteLine($"Hello {args[0]}!");  
            }
            else{
                Console.WriteLine("Hello");
            }


            var numbers = new double[3];
            numbers[0] = 12.4;
            numbers[1] = 1;
            numbers[2] = 10;

            var sum = 0.0;
            var highGrade = double.MinValue; // property
            foreach(double number in numbers){
                if(number > highGrade) highGrade = number;

                sum += number;
            }

            Console.WriteLine($"highest val is {highGrade}");

            Console.WriteLine(sum);
            // array initialization
            var nrs = new double[3] {12.6, 12, 9};
            var nrs2 = new[] {12.6, 12, 9};



            var book = new Book("Al book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            // book.GradeAdded = null; // once its an event, not legal to make null

            book.AddGrade(89.1);

            Book b2 = new Book("book2");
            b2.AddGrade(10.2);
            // b2.grades.Add(1);

            Console.Write("enter a grade: ");
            var input = Console.ReadLine();
            var grade = double.Parse(input);

            Console.WriteLine($"the grade you entered is {grade}");
        }

        static void OnGradeAdded(object sender, EventArgs e){
            Console.WriteLine("grade added");
        }
    }
}
