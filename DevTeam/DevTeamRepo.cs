using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DevTeamRepo
    {
        public List<DeveloperTeams> _devTeams = new List<DeveloperTeams>();
        private int idCounter = default;

        //Create a Team
        public bool CreateATeam(DeveloperTeams devTeam)
        {
            if (devTeam == null)
            {
                return false;
            }
            devTeam.TeamId = ++idCounter;
            _devTeams.Add(devTeam);
            return true;
        }
        //Read -- See all the teams in the repo
        public List<DeveloperTeams> SeeAllTeams()
        {
            return _devTeams;
        }
        public DeveloperTeams FindDevTeamById(int id)
        {
            foreach (DeveloperTeams devTeam in _devTeams)
            {
                if (devTeam.TeamId == id)
                {
                    return devTeam;
                }
            }
            return null;
        }
        //Update a specific Team
        public bool UpdateATeamRepo(int id, DeveloperTeams newDevTeam)
        {
            DeveloperTeams exsistingTeam = this.FindDevTeamById(id);
            if (exsistingTeam == null)
            {
                return false;
            }
            exsistingTeam.TeamName = newDevTeam.TeamName;
            return true;
        }
        //Delete a Team
        public bool DeleteATeam(int id)
        {
            DeveloperTeams exsistingTeam = this.FindDevTeamById(id);
            if (exsistingTeam == null)
            {
                return false;
            }
            int initialDevTeamCount = _devTeams.Count;
            _devTeams.Remove(exsistingTeam);
            return true;
        }
    }
}
