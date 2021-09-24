using Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DeveloperTeams
    {
        public DeveloperTeams() { }
        public DeveloperTeams(List<Developer> team, string teamName)
        {
            Team = team;
            TeamName = teamName;
        }

        public List<Developer> Team { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }
    }
}
