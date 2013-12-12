using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace G9206.Classes
{
    public class Serialisointi
    {
        #region XmlTiedostoMetodit
        public static void SerialisoiXml(string tiedosto, Harjoitukset ic)
        {
            XmlSerializer xs = new XmlSerializer(ic.GetType());
            TextWriter tw = new StreamWriter(tiedosto);
            try
            {
                xs.Serialize(tw, ic);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                tw.Close();
            }
        }
        public static void DeSerialisoiXml(string filePath, ref Employees emp)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Employees));
            try
            {

                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                emp = (Employees)deserializer.Deserialize(xmlFile);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }
        public static void deSerialisoiKayttajat(string filePath, ref Users kayttajat)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Users));
            try
            {
                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                kayttajat = (Users)deserializer.Deserialize(xmlFile);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public static void deSerialisoiHarjoitukset(string filePath, ref Harjoitukset harkat)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Harjoitukset));
            try
            {
                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                harkat = (Harjoitukset)deserializer.Deserialize(xmlFile);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        #endregion
    }
}