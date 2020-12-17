using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Controller;
using WebApp.Repositories;

namespace WebApp
{
    public partial class CafeAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CafeRepository cafeRepo = new CafeRepository();
                MenuModel data = new MenuModel()
                {
                    title = txtTitle.Text,
                    size = txtSize.Text,
                    price = int.Parse(txtPrice.Text)
                };
                cafeRepo.insertMenu(data);
                ClientScript.RegisterStartupScript(GetType(), "alertSuccess", "showAlertSuccess('Insert Success!!');", true);
            }
            catch (SqlException sqlEx)
            {
                ClientScript.RegisterStartupScript(GetType(), "alertSqlErr", "showAlertError('" + sqlEx.Message + "');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alertErr", "showAlertError('" + ex.Message + "');", true);
            }
        }
    }
}