using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFDataEditor
{
    /// <summary>
    /// Логика взаимодействия для NewStudent.xaml
    /// </summary>
    public partial class NewStudent : Window
    {
        public Student Student
        {
            get
            {
                return this.Resources["NewStudent"] as Student;
            }
        }

        public NewStudent()
        {
            InitializeComponent();
        }
    }
}
