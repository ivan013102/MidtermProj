using MidtermClassLibrary.Models;

namespace MidtermClassLibrary.DataStructures
{
    public class ClassNode
    {
        public ClassStudent Data { get; set; }
        public ClassNode Next { get; set; }
        public ClassNode Prev { get; set; }
        public ClassNode(ClassStudent student)
        {
            Data = student;
            Next = null;
            Prev = null;
        }
    }
}