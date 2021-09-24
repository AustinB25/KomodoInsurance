using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers
{
    public class DevRepo
    {
        public readonly List<Developer> _developers = new List<Developer>();
        private int _idCount = default;
        //Create a Developer
        public bool CreateDeveloper(Developer developer)
        {
            if (developer == null)
            {
                return false;
            }
            developer.iD = ++_idCount;
            _developers.Add(developer);
            return true;
        }
        //Read -- See all devs in a list and as individuals
        public List<Developer> SeeAllDevs()
        {
            return _developers;
        }
        public Developer GetDevById(int id)
        {
            foreach(Developer dev in _developers)
            {
                if(dev.iD == id)
                {
                    return dev;
                }
            }
                return null;
        }
        //Update a specific Dev
        public bool UpdateDeveloper(int devId, Developer dev)
        {
            Developer exsistingDev = this.GetDevById(devId);
            if (exsistingDev == null)
            {
                return false;
            }
            exsistingDev.FirstName = dev.FirstName;
            exsistingDev.LastName = dev.LastName;
            exsistingDev.HasPluralSightAccess = dev.HasPluralSightAccess;
            return true;
        }
        //Delete a Dev
        public bool DeleteDev(int devId)
        {
            Developer exsistingDev = this.GetDevById(devId);
            if (exsistingDev == null)
            {
                return false;
            }
            int initialdevCount = _developers.Count;
            _developers.Remove(exsistingDev);
                 
            return initialdevCount > _developers.Count;
            
        }
    }
}
