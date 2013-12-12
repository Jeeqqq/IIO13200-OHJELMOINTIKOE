using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9206.Classes;

public partial class G9206_T3a : System.Web.UI.Page
{
    private Harjoitukset harkat;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            harkat = new Harjoitukset();
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["harjoitukset"];
            path = Server.MapPath("~/" + path);
            try
            {
                Serialisointi.deSerialisoiHarjoitukset(path, ref harkat);
                bindListBox();
                lblInfo.Text = "harjoituksia yht : "+harkat.harkat.Count;
            }
            catch
            {
                
                lblInfo.Text = "Ei ole vielä harjoituksia!";
            }
            ViewState["harkat"] = harkat;
        }
        else
        {
            harkat = (Harjoitukset)ViewState["harkat"];
        }
        if (Session["UserAuthentication"] != null)
        {

            LoginWindow.Visible = false;
            btnLogout.Visible = true;
            uusiHarjoitus.Visible = true;
            listViewContainer.Visible = true;
            txtKayttaja.Text = (string)Session["UserAuthentication"];
        }
        else
        {
            Session["UserAuthentication"] = null;
            lblInfo.Text = null;
            listViewContainer.Visible = false;
            uusiHarjoitus.Visible = false ;
            LoginWindow.Visible = true;
            btnLogout.Visible = false;
        }
        bindList();
    }

    private void bindListBox()
    {
        List<string> kayttajat = new List<string>();
        kayttajat.Add("Kaikki");
        foreach (Harjoitus h in harkat.harkat)
        {
            string nimi = h.Nimi;
            if (!kayttajat.Contains(nimi))
            {
                kayttajat.Add(nimi);
            }
        }

        ListBox1.DataSource = kayttajat;

        ListBox1.DataBind();
    }
    private void bindList()
    {
        harkat.harkat = harkat.harkat.OrderBy(h => h.Pvm).ToList(); ;
        ListView1.DataSource = harkat.harkat;
        ListView1.DataBind();

        double summa = 0;
        foreach (Harjoitus h in harkat.harkat)
        {
            summa += h.Kilometrit;
        }
        yhtKm.InnerText = "Kilometrejä yhteensä : "+ summa;
    }
    protected void LoginWindow_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string username=LoginWindow.UserName.ToString();
        string pass=LoginWindow.Password.ToString();
        if (authenticateUser(username,pass))
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
    }
    protected void LoginWindow_LoginError(object sender, EventArgs e)
    {
        Session["UserAuthentication"] = null;
    }
    protected void LoginWindow_LoggedIn(object sender, EventArgs e)
    {
        Session["UserAuthentication"] = LoginWindow.UserName.ToString();
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["UserAuthentication"] = null;
        Response.Redirect(Request.RawUrl);
    }
    private bool authenticateUser(string userName, string passWord)
    {
        Users kayttajat = new Users();
        string path = System.Web.Configuration.WebConfigurationManager.AppSettings["users"];
        path = Server.MapPath("~/" + path);
        Serialisointi.deSerialisoiKayttajat(path, ref kayttajat);
        string saltedHashStringUserName = SaltHashString(userName);
        string saltedHashStringPassword = SaltHashString(passWord);
        

        for (int i = 0; i < kayttajat.kayttajat.Count; i++)
        {
            if (saltedHashStringUserName == kayttajat.kayttajat[i].UserName && saltedHashStringPassword == kayttajat.kayttajat[i].Password)
            {
                return true;
            }
        }
        return false;
    }

    private string SaltHashString(string str)
    {

        byte[] saltBytes = new byte[] { 12, 254, 62, 6, 7, 42, 2, 96 };
        byte[] saltedHashBytesStr= new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(str));

        return Convert.ToBase64String(saltedHashBytesStr);
    }
    private void createUsers()
    {
        Users kayttajat = new Users();
        kayttajat.kayttajat.Add(new User("Musti", SaltHashString("Musti"),SaltHashString("salasana")));
        kayttajat.kayttajat.Add(new User("Tero", SaltHashString("Tero"), SaltHashString("salis123")));
        kayttajat.kayttajat.Add(new User("Iivo", SaltHashString("Iivo"), SaltHashString("qwerty")));
        kayttajat.kayttajat.Add(new User("Ville", SaltHashString("Ville"), SaltHashString("asd123")));

        string path = System.Web.Configuration.WebConfigurationManager.AppSettings["users"];
        //Serialisointi.SerialisoiXml(path, kayttajat);
    }
    protected void btnUusi_Click(object sender, EventArgs e)
    {
        string nimi = txtKayttaja.Text,km=txtKilometrit.Text,pvm=txtPvm.Text;
        lblInfo.Text="";
        if (!regexString(nimi,"nimi"))
        {
            lblInfo.Text = "Nimen pitää olla 1 -15 merkkiä pitkä ja sisältää vain kirjaimia!";
        }
        if (!regexString(km, "kilometrit"))
        {
            lblInfo.Text = "Kilometrit saavat sisältää vain numeroita ja pilkkuja";
        }
        if (!regexString(pvm, "pvm"))
        {
            lblInfo.Text = "Pitää olla validi päivämäärä";
        }
        if (lblInfo.Text =="")
        {
            Harjoitus h=new Harjoitus();
            h.Nimi=nimi;
            h.Kilometrit=Double.Parse(km);
            h.Pvm=pvm;
            harkat.harkat.Add(h);
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["harjoitukset"];
            path = Server.MapPath("~/" + path);
            try
            {
                Serialisointi.SerialisoiXml(path, harkat);
                lblInfo.Text = "Harjoitus lisätty";
                bindList();
                bindListBox();
            }
            catch
            {
                lblInfo.Text = "Harjoituksen lisääminen epäonnsitui";
            }
        }
       

    }
    public bool regexString(string tarkistettava, string kohde)
    {
        Regex regNimi = new Regex(@"^[a-zA-Z]{1,15}$");
        Regex regkilometrit = new Regex(@"^[0-9,]{1,9}$");
        DateTime date = new DateTime();
        switch (kohde)
        {
           
            case "nimi":
                return regNimi.IsMatch(tarkistettava);
            case "kilometrit":
                return regkilometrit.IsMatch(tarkistettava);
            case "pvm":
                return DateTime.TryParse(tarkistettava, out date);
            default:
                return false;
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ListBox1.SelectedIndex > 0)
        {
            filterHarkat(ListBox1.SelectedValue);
        }
        else
        {

            bindList();
        }
    }

    private void filterHarkat(string p)
    {
        List<Harjoitus> harj=harkat.harkat.FindAll(h=>h.Nimi==p);
        ListView1.DataSource = harj;
        ListView1.DataBind();
        double summa = 0;
        foreach (Harjoitus h in harj)
        {
            summa += h.Kilometrit;
        }
        yhtKm.InnerText = "Kilometrejä yhteensä : " + summa;
    }
}