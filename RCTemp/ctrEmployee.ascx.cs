using Microsoft.VisualBasic;
using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RCTemp.xsRCTemp;

namespace RCTemp
{
    public partial class ctrEmployee : System.Web.UI.UserControl
    {

        private int m_EmpID = 0;

        public int EmpID
        {
            get
            {
                return m_EmpID;
            }
            set
            {
                m_EmpID = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            clsRCTemp theEmployee = new clsRCTemp();
            EmployeesDataTable tblEmployee = new EmployeesDataTable();

            try
            {
                if (Request.Form["ctl00$MainContent$ctrSearch_Employee$btnSearch"] == "Search")
                    ctrHiddebField.Value = Convert.ToString(m_EmpID);
                if ((Page.IsPostBack) & this.lblSearchResult.Text.Length > 0)

                    tblEmployee = (EmployeesDataTable)theEmployee.GetEmployees(EmpID);


                else

                    tblEmployee = (EmployeesDataTable)theEmployee.GetEmployeeList();

                this.lblSearchResult.Text = tblEmployee.Rows.Count.ToString();
                this.grdEmployee.DataSource = tblEmployee.DefaultView;
                this.grdEmployee.DataBind();
            }

            catch (Exception)
            {
                throw;
            }
        }

        private string ConvertSortDirection(GridViewSortEventArgs e)
        {

            ViewState.Add("columnname", e.SortExpression);

            if (ViewState["direction"] is null)
            {
                ViewState.Add("direction", "asc");
            }
            else
            {
                ViewState["direction"] = Interaction.IIf(ViewState["direction"].ToString().ToLower() == "desc", "asc", "desc");
            }

            return ViewState["direction"].ToString();

        }
        public void CreateExcelFiles()
        {

            try
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Employee_Information.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                var sw = new StringWriter();
                var hw = new HtmlTextWriter(sw);
                this.grdEmployee.AllowPaging = false;
                this.grdEmployee.DataBind();

                for (int y = 0; y <= 12; y++)
                    this.grdEmployee.HeaderRow.Cells[y].Style.Add("background-color", "#cfdbe6");

                for (int x = 0, loopTo = this.grdEmployee.Rows.Count - 1; x <= loopTo; x++)
                {

                    for (int y = 0; y <= 12; y++)
                    {
                        if (x % 2 > 0)
                            this.grdEmployee.Rows[x].Cells[y].Style.Add("background-color", "#e0ebea");
                    }

                }

                this.grdEmployee.Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                this.grdEmployee.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }





            catch (Exception)
            {
                throw;
            }
        }

        protected void grdEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (!(ViewState["columnname"] == null | ViewState["direction"] == null))
                {

                    DataView m_DataView = (DataView)this.grdEmployee.DataSource;

                    if (m_DataView != null)
                    {

                        m_DataView.Sort = ViewState["columnname"].ToString() + " " + ViewState["direction"].ToString();
                        this.grdEmployee.DataSource = m_DataView;

                    }
                }

                this.grdEmployee.PageIndex = e.NewPageIndex;
                this.grdEmployee.DataBind();
            }

            catch (Exception)
            {
                throw;
            }
        }

        protected void grdEmployee_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {

                DataView m_Dataview = (DataView)this.grdEmployee.DataSource;

                if (m_Dataview != null)
                {

                    m_Dataview.Sort = e.SortExpression + " " + ConvertSortDirection(e);
                    this.grdEmployee.DataSource = m_Dataview;
                    this.grdEmployee.DataBind();

                }
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}