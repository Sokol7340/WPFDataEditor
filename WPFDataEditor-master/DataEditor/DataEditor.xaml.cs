using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xml;

namespace WPFDataEditor
{
    /// <summary>
    /// Логика взаимодействия для DataEditor.xaml
    /// </summary>
    public partial class DataEditor : Window
    {
        StringDataSource _dataSource;
        public StringDataSource dataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                listBox.ItemsSource = value.data;
            }
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public DataEditor()
        {
            InitializeComponent();

            saveFileDialog.DefaultExt = ".xml";
            openFileDialog.DefaultExt = ".xml";
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            openFileDialog.Filter = "XML Files|*.xml|All Files|*.*";

            dataSource = new StringDataSource();
            dataSource.data.Add(new Student("Anna"));
            dataSource.data.Add(new Student("Boris")); 
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //dataSource.data.Add(new Student(Guid.NewGuid().ToString()));
            NewStudent newStudentDialog = new NewStudent();
            newStudentDialog.ShowDialog();
            dataSource.data.Add(newStudentDialog.Student);

            //if (newStudentDialog.ShowDialog() == true)
            //{
            //    dataSource.data.Add(newStudentDialog.Student);
            //}
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            dataSource.data.Remove(listBox.SelectedItem as Student);
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

            if (saveFileDialog.ShowDialog() == true)
            {

                var serializer = new XmlSerializer(typeof(StringDataSource));

                using (XmlWriter fs = XmlWriter.Create(saveFileDialog.FileName))
                {

                    serializer.Serialize(fs, dataSource);

                    Debug.WriteLine("Объект сериализован");
                }
            }
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                var serializer = new XmlSerializer(typeof(StringDataSource));
                using (XmlReader fs = XmlReader.Create(openFileDialog.FileName))
                {
                    
                    dataSource = serializer.Deserialize(fs) as StringDataSource;
                }
            }
        }
    }
}
