using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Employee
/// </summary>
/// 
namespace G9206.Classes
{
    
    [Serializable()]
    [XmlRoot("tyontekijat")]
    public class Employees
    {
        public Employees()
        {
            EmployeeLists = new List<Employee>();
        }
        [XmlElement("tyontekija")]
        public List<Employee> EmployeeLists { get; set; }
    }
    [Serializable()]
    public class Employee
    {
        [XmlElement("etunimi")]
        public string Etunimi { get; set; }
        [XmlElement("sukunimi")]
        public string Sukunimi { get; set; }
        [XmlElement("tyosuhde")]
        public string Tyosuhde { get; set; }
        [XmlElement("numero")]
        public int Numero { get; set; }
        [XmlElement("palkka")]
        public int Palkka { get; set; }

	    public Employee()
	    {

	    }
    }
}