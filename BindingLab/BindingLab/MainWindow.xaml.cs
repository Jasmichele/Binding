﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;

namespace BindingLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Emp> employee = new List<Emp>();

        public MainWindow()
        {
            InitializeComponent();
            ReadFile();
            listView.ItemsSource = employee;
        }

        private void textBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Emp newEmp = new Emp();

            newEmp.EmpId1 = textBoxId.Text;
            newEmp.EmpName1 = textBoxName.Text;
            newEmp.Addr1 = textBoxaddr.Text;
            newEmp.City1 = textBoxCity.Text;
            newEmp.State1 = textBoxState.Text;

            employee.Add(newEmp);

            textBoxId.Clear();
            textBoxName.Clear();
            textBoxaddr.Clear();
            textBoxCity.Clear();
            textBoxState.Clear();

            listView.ItemsSource = null;
            listView.ItemsSource = employee;
        }
        
        private void save()
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\myfiles\\star.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("SuperCompany");

                foreach(Emp e in employee)
                {
                    writer.WriteStartElement("Employee");

                    writer.WriteElementString("EmployeeId", e.EmpId1);
                    writer.WriteElementString("EmployeeName", e.EmpName1);
                    writer.WriteElementString("Address", e.Addr1);
                    writer.WriteElementString("City", e.City1);
                    writer.WriteElementString("State", e.State1);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            save();
        }

        public void ReadFile()
        {
            if (File.Exists("C:\\myfiles\\star.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("C:\\myfiles\\star.xml");
                XmlNode supNode = doc.DocumentElement.SelectSingleNode("/SuperCompany");
                
                foreach(XmlNode child in supNode.ChildNodes)
                {
                    Emp e1 = new Emp();

                    foreach (XmlNode granchild in child.ChildNodes)
                    {
                        switch (granchild.Name)
                        {
                            case "EmployeeId":
                                {
                                    e1.EmpId1 = granchild.InnerText;
                                    break;
                                }
                            case "EmployeeName":
                                {
                                    e1.EmpName1 = granchild.InnerText;
                                    break;
                                }
                            case "Address":
                                {
                                    e1.Addr1 = granchild.InnerText;
                                    break;
                                }
                            case "City":
                                {
                                    e1.City1 = granchild.InnerText;
                                    break;
                                }
                            case "State":
                                {
                                    e1.State1 = granchild.InnerText;
                                    break;
                                }
                        }
                    }
                    employee.Add(e1);
                }
            }
        }

        public void FileNotFound()
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\myfiles\\star.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("SuperCompany");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

    }
}
