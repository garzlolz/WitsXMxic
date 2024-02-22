using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WitsXMxic_WebFormVersion.Services;

namespace WitsXMxic_WebFormVersion
{
    public partial class HankTeams : System.Web.UI.Page
    {
        private List<TeamMember> teamMembers = new List<TeamMember>();
        private MemberService memberService;

        public HankTeams()
        {
            memberService = new MemberService();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var members = await memberService.GetTeamMembers();
                teamMembers.AddRange(members);
                BindData();
            }
        }

        private void BindData()
        {
            GridView1.DataSource = teamMembers;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int memberId = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"CreateOrUpdateUser.aspx?id={memberId}");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = ((TextBox)row.FindControl("txtName")).Text;
            int age = Convert.ToInt32(((TextBox)row.FindControl("txtAge")).Text);

            // 更新模擬資料
            TeamMember member = teamMembers.Find(m => m.Id == id);
            if (member != null)
            {
                member.Name = name;
                member.Age = age;
            }

            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected async void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int memberId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            await memberService.Delete(memberId);

            Response.Redirect("HankTeams.aspx");
            Context.ApplicationInstance.CompleteRequest(); // 結束當前要求而不中止執行緒
            return;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateOrUpdateUser.aspx");
        }

    }

    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birth { get; set; } 
    }
}
