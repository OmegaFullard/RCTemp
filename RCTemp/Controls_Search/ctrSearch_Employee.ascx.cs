using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp.Controls_Search
{
    public partial class ctrEmployee_Search : System.Web.UI.UserControl
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

        }
        public void PopulateSearchControl()
        {
            m_EmpID = int.Parse(txtempid.Text);
        }

    }
}