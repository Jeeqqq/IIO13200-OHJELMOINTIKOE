using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9206.Classes;

public partial class G9206_T2 : System.Web.UI.Page
{
    public Employees emps;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            emps = new Employees();
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["tyontekijat"];
            path = Server.MapPath("~/"+path);
            Serialisointi.DeSerialisoiXml(path, ref emps);
            ViewState["emps"] = emps;
        }
        else
        {
            emps = (Employees)ViewState["emps"];
        }
        bindList();
    }

    private void bindList()
    {
        ListView1.DataSource = emps.EmployeeLists;
        ListView1.DataBind();

        List<Employee> vakituiset=emps.EmployeeLists.FindAll(em=>em.Tyosuhde.Equals("vakituinen"));
        int summa = 0;
        foreach (Employee emp in vakituiset)
        {
            summa += emp.Palkka;
        }
        vakituisetYht.InnerText="Vakituisia työntekijöitä yht : "+vakituiset.Count;
        palkkaYht.InnerText = "Vakituisia työntekijöiden palkka yht : " + summa;

    }
}