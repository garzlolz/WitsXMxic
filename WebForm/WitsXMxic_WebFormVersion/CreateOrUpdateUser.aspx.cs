using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WitsXMxic_WebFormVersion.DBModels;
using WitsXMxic_WebFormVersion.Services;

namespace WitsXMxic_WebFormVersion
{
    public partial class CreateOrUpdateUser : Page
    {
        private MemberService memberService;
        public CreateOrUpdateUser()
        {
            memberService = new MemberService();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    // 如果有傳入 id 參數，表示是編輯模式
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    var member = await memberService.GetTeamMember(id);
                    this.lblId.Text = id.ToString();
                    this.lblId.Visible = false;
                    this.txtAge.Text = member.Age.ToString();
                    this.txtName.Text = member.Name;
                    this.lblTitle.Text = "編輯團員";
                    this.txtBirth.Text = member.Birth;
                }
                else
                {
                    this.lblTitle.Text = "新增團員";
                }
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            hank_teams hank_Team = new hank_teams();

            if (!lblId.Text.IsNullOrWhiteSpace())
            {
                hank_Team.id = Convert.ToInt32(lblId.Text);
            }

            hank_Team.name = txtName.Text;
            hank_Team.age = Convert.ToInt32(txtAge.Text);
            hank_Team.birth = Convert.ToDateTime(txtBirth.Text);

            var res = await memberService.CreateOrUpdate(hank_Team);

            Response.Redirect("HankTeams.aspx", false); // 將 endResponse 設置為 false
            Context.ApplicationInstance.CompleteRequest(); // 結束當前要求而不中止執行緒
            return;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HankTeams.aspx");
        }
    }
}