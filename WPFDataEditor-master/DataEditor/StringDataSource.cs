using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;

namespace WPFDataEditor
{
    public class Student
    {
        public Student() { }
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        //public string 
    }

    [Serializable]
    public class StringDataSource
    {
        public ObservableCollection<Student> data = new ObservableCollection<Student>();
    }
}
