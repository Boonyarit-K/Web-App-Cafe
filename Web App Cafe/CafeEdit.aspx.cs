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
    public partial class CafeEdit : BasePage
    {
        CafeRepository cafeRepo = new CafeRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }
        }
        void setData()
        {
            try
            {
                string paramId = Request["id"];
                int id = 0;
                if (string.IsNullOrEmpty(paramId) || !int.TryParse(paramId, out id))
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                else
                {
                    id = int.Parse(paramId);
                }
                var data = cafeRepo.getMenuById(id);
                if (data.Tables[0].Rows.Count == 0)
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                var row = data.Tables[0].Rows[0];
                txtTitle.Text = row["Menu"].ToString();
                txtSize.Text = row["Size"].ToString();
                txtPrice.Text = row["Price"].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                string paramId = Request["id"];
                int id = 0;
                if (string.IsNullOrEmpty(paramId) || !int.TryParse(paramId, out id))
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                else
                {
                    id = int.Parse(paramId);
                }
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    showAlertError("alertTitleErr", "กรุณากรอกชื่อภาพยนต์");
                    return;
                }
                if (string.IsNullOrEmpty(txtSize.Text))
                {
                    showAlertError("alertDurErr", "กรุณากรอกขนาด");
                    return;
                }
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    showAlertError("alertDurErr", "กรุณากรอกราคา");
                    return;
                }
                var menu = new MenuModel()
                {
                    id = id,
                    title = txtTitle.Text,
                    size = txtSize.Text,
                    price = int.Parse(txtPrice.Text)
                };
                cafeRepo.updateMenu(menu);
                Response.Redirect("~/CafeList.aspx");
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
    }
}