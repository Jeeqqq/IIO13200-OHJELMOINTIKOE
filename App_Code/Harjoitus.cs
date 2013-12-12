using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace G9206.Classes
{
    [Serializable()]
    [XmlRoot("Harjoitukset")]
    public class Harjoitukset
    {
        [XmlElement("Harjoitus")]
        public List<Harjoitus> harkat { get; set; }

        public Harjoitukset()
        {
            harkat = new List<Harjoitus>();
        }
    }

    [Serializable()]
public class Harjoitus
{
    [XmlElement("Nimi")]
    public string Nimi { get; set; }
    [XmlElement("Kilometrit")]
    public double Kilometrit { get; set; }
    [XmlElement("Pvm")]
    public string Pvm { get; set; }
	public Harjoitus()
	{
		
	}
}
}