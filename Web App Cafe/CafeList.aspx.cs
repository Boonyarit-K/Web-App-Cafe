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
    public partial class CafeList : BasePage
    {
        CafeRepository cafeRepo = new CafeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDataMenu();
            }
        }

        void bindDataMenu()
        {
            gvCafe.DataSource = cafeRepo.getCafeList();
            gvCafe.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var btnDelete = (Button)sender;
                var row = (GridViewRow)btnDelete.NamingContainer;
                int id = int.Parse(row.Cells[0].Text);
                cafeRepo.deleteMenu(id);
                bindDataMenu();
                showAlertSuccess("alertDelSuccess", "Delete success!!");
            }
            catch (SqlException sqlEx)
            {
                showAlertError("alertSqlErr", sqlEx.Message);
            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("~/CafeEdit.aspx?id=" + id);
        }
    }
}