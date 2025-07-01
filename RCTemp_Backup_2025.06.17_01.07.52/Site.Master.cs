using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class SiteMaster : MasterPage
    {
        public SiteMaster()
        {
            Load += Page_Load;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}