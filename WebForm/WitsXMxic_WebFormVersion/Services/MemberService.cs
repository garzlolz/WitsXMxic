using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using WitsXMxic_WebFormVersion.DBModels;

namespace WitsXMxic_WebFormVersion.Services
{
    public class MemberService
    {
        private WitsXMxicEntities DB;

        public MemberService()
        {
        }

        public async Task<List<TeamMember>> GetTeamMembers()
        {
            DB = new WitsXMxicEntities();
            List<TeamMember> teamMembers = new List<TeamMember>();
            var members = await DB.hank_teams
                 .Select(h => new
                 {
                     Id = h.id,
                     Name = h.name,
                     Age = h.age,
                     Birth = h.birth
                 })
                 .ToListAsync();

            foreach (var member in members)
            {
                TeamMember data = new TeamMember();

                data.Id = member.Id;
                data.Name = member.Name;
                data.Age = member.Age;
                data.Birth = member.Birth.ToString("yyyy/MM/dd");

                teamMembers.Add(data);
            }

            return teamMembers;
        }

        public async Task<TeamMember> GetTeamMember(int id)
        {
            DB = new WitsXMxicEntities();
            TeamMember data = new TeamMember();

            var member = await DB.hank_teams
                .Select(h => new
                {
                    Id = h.id,
                    Name = h.name,
                    Age = h.age,
                    Birth = h.birth
                })
                .FirstOrDefaultAsync(h => h.Id == id);

            data.Id = member.Id;
            data.Name = member.Name;
            data.Age = member.Age;
            data.Birth = member.Birth.ToString("yyyy/MM/dd");

            return data;
        }

        public async Task<bool> CreateOrUpdate(hank_teams request)
        {
            try
            {
                DB = new WitsXMxicEntities();
                hank_teams team;

                if (request.id != 0)
                {
                    team = await DB.hank_teams.FindAsync(request.id);
                }
                else
                {
                    team = new hank_teams();
                }

                team.birth = request.birth;
                team.name = request.name;
                team.age = request.age;

                if (request.id == 0)
                {
                    DB.hank_teams.Add(team);
                }

                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public async Task Delete(int memberId)
        {
            DB = new WitsXMxicEntities();
            var member = await DB.hank_teams.FindAsync(memberId);

            DB.hank_teams.Remove(member);
            await DB.SaveChangesAsync();
        }
    }
}