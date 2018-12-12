using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testx
{
    class Program
    {
        static void Main(string[] args)
        {
            //var studentList = new List<Student>();
            List<Student> studentList = new List<Student>();
            Student sl = new Student();
            sl.Name = "韦庆怀";
            sl.Class = "软件二班";
            studentList.Add(sl);

            sl = new Student();
            sl.Name = "怀";
            sl.Class = "软件二班";
            studentList.Add(sl);

            foreach (var item in studentList)
            {
                Console.WriteLine("姓名: {0}, 班级: {1}", item.Name, item.Class);
            }
            
        }
    }
}
