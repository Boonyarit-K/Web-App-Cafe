using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Controller;
using WebApp.Repositories;

namespace WebApp
{
    public partial class _Default : BasePage
    {
        CafeRepository cafeRepo = new CafeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
    }
}