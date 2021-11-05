namespace GradeBook
{

    public class Notebook : NamedObject
    {
        // reference to the base class
        public Notebook(string name) : base(name)
        {

        }
    }

    public abstract class BookAbstract : NamedObject
    {
        protected BookAbstract(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        // virtual keyword in case you want to override
    }
    public class Manual : BookAbstract, IBook
    {
        // reference to the base class
        public Manual(string name) : base(name)
        {

        }

        public event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {

        }


    }

    public interface IBook
    {
        void AddGrade(double grade); // no need to make public
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}