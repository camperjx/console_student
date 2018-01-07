using System;
namespace _Homework
{
    public class Course
    {
        public int cid { get; set; }
		public int maxStudent = 1;
		public string className;
		public int credit = 3;

		public Course(string name)
		{
			this.className = name;
		}

        public override string ToString()
        {
            return string.Format("[Course] - name: " + className + " credit: " + credit + " maxStudent: " + maxStudent);
        }
    }
}
