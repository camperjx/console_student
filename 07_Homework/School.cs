using System;
using System.Collections.Generic;

namespace _Homework
{
	public class School
	{
		private const int FEE_PER_CREDIT = 1000;
		private List<Student> students;
		private List<Course> courses;
		private List<CourseToStudent> courseToStudents;

		public School()
		{
			this.students = new List<Student>();
			this.courses = new List<Course>();
			this.courseToStudents = new List<CourseToStudent>();
		}

		public void addCourse(string name)
		{
            //TODO:Add course
            this.courses.Add(new Course(name));

		}

		public void addStudent(string name, int creditLimited)
		{
            //TODO:Add student
            this.students.Add(new Student(name, creditLimited));
		}

		public void enrollStudentToCourse(int courseIndex, int studentIndex)
		{
			if (checkStudentCanEnroll(students[studentIndex], courses[courseIndex]))
			{
                //TODO:Insert the record in courseToStudents
                Student s = students[studentIndex];
                Course c = courses[courseIndex];
                CourseToStudent cs = new CourseToStudent(c, s);
                courseToStudents.Add(cs);
			}
			else
			{
				Console.WriteLine("Student " + students[studentIndex].name + "can not enroll");
			}
		}

		private bool checkStudentCanEnroll(Student student, Course course)
		{
			//Check course max student 
			return (checkCourseCanTakeStudent(course) && checkStudentCanTakeCourse(student, course));

		}

		private bool checkCourseCanTakeStudent(Course course)
		{
			List<Student> studentsInCourse = getStudentsFromCourse(course);
			return (studentsInCourse.Count < course.maxStudent);
		}

		private bool checkStudentCanTakeCourse(Student student, Course courseWillEnrolled)
		{
			List<Course> courseStudentTaking = getCourseFromStudent(student);
			int maxCredit = student.creditLimited;
			int studentCredit = 0;
			foreach (Course course in courseStudentTaking)
			{
				studentCredit = studentCredit + course.credit;
			}
			return (studentCredit + courseWillEnrolled.credit) <= maxCredit;
		}

		
        public void printStudent()
		{
			//TODO:print all Student
            foreach(Student s in this.students){
                Console.WriteLine(s.ToString());
            }
		}
		
        public void printCourse()
		{
			//TODO:print all Course
            foreach(Course c in this.courses){
                Console.WriteLine(c.ToString());
            }
		}

		public void removeStudent(int studentIdx)
		{
            //TODO:Remove student from course

            //remove student from 'coursetostudent'

            //remove student from 'students'
            students.RemoveAt(studentIdx);
		}

		public void removeCourse(int courseIdx)
		{


            //TODO: Remove course 
            //remove course from 'coursetostudent'
            foreach(CourseToStudent cs in courseToStudents){
                if (cs.course.cid == courses[courseIdx].cid) {
                    courseToStudents.RemoveAt(courseIdx);
                }
            }
            //remove from courses
            courses.RemoveAt(courseIdx);
		}
       
		private List<Student> getStudentsFromCourse(Course course)
		{
            //TODO:Get the student list from course
            int cid_arg = course.cid;
            List<Student> slist = new List<Student>();
            foreach(CourseToStudent cs in courseToStudents){
                if(cs.course.cid == cid_arg){
                    slist.Add(cs.student);
                }

            }

            return slist;
		}

		private List<Course> getCourseFromStudent(Student student)
		{
			//TODO:Get the course list from studemt

            int sid_arg = student.sid;
            List<Course> clist = new List<Course>();
            foreach (CourseToStudent cs in courseToStudents)
            {
                if (cs.student.sid == sid_arg)
                {
                    clist.Add(cs.course);
                }

            }

            return clist;
			
		}

		public void printCourseWithCourseIndex(int courseIndex)
		{
			Course selectedCourse = courses[courseIndex];
			int count = 0;
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				if (courseToStudents[i].course == selectedCourse)
				{
					Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
					count++;
				}
			}
			Console.WriteLine("The total student of " + selectedCourse.className + " : " + count);
		}

		public void printCourseWithStudentIndex(int studentIdx)
		{
			Student selectedStudent = students[studentIdx];
			int count = 0;
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				if (courseToStudents[i].student == selectedStudent)
				{
					Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
					count++;
				}
			}
			Console.WriteLine("The total course of " + selectedStudent.name + " enrolled is " + count);

		}

		public void printCourseToStudent()
		{
			for (int i = 0; i < courseToStudents.Count; i++)
			{
				Console.WriteLine((i + 1) + "." + courseToStudents[i].course.className + " - " + courseToStudents[i].student.name);
			}
		}
	}
}
