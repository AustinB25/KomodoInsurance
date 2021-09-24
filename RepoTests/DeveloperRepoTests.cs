using Developers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RepoTests
{
    [TestClass]
    public class DeveloperRepoTests
    {
        private DevRepo _devrepo = new DevRepo();        
    [TestInitialize]
    public void Arrange()
        {
            var devSeed = new Developer("Jay", "Culter", true);
            _devrepo.CreateDeveloper(devSeed);            
         }
        [TestMethod]
        public void CreateDeveloper_DeveloperIsNull_ReturnFalse()
        {
            Developer testDev = null;         
            bool result = _devrepo.CreateDeveloper(testDev);           
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateDeveloper_DeveloperIsNotNull_ReturnTrue()
        {
            var dev1 = new Developer("Jay", "Cutler", true);
            bool result = _devrepo.CreateDeveloper(dev1);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetDevById_DeveloperExsists_ReturnDeveloper()
        {
            int id = 1;
            Developer result = _devrepo.GetDevById(id);
            Assert.AreEqual(result.iD, id);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetDevById_DeveloperDoesNotExsist_ReturnNull()
        {
            int id = 50;
            Developer result = _devrepo.GetDevById(id);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void UpdateDeveloper_DeveloperDoesNotExsist_ReturnFalse()
        {
            int id = 95;
            Developer updateDeveloper = new Developer("Eric", "Hightower", false);
            bool result = _devrepo.UpdateDeveloper(id, updateDeveloper);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void UpdateDeveloper_DeveloperDoesExsist_ReturnTrue()
        {
            int id = 1;
            Developer updateDeveloper = new Developer("Eric", "Hightower", false);
            bool result = _devrepo.UpdateDeveloper(id, updateDeveloper);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateDeveloper_DeveloperDoesExsist_ProperitiesUpdate()
        {
            int id = 1;
            Developer updateDeveloper = new Developer("Eric", "Hightower", false);            
            _devrepo.UpdateDeveloper(id, updateDeveloper);
            var dev = _devrepo.GetDevById(id);            
            Assert.AreEqual("Eric", dev.FirstName);
            Assert.AreEqual("Hightower", dev.LastName);
            Assert.IsFalse(dev.HasPluralSightAccess);            
        }
        [TestMethod]
        public void DeleteDev_DeveloperDoesNotExsist_ReturnFalse()
        {
            int id = 5;
            bool result = _devrepo.DeleteDev(id);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteDev_DeveloperDoesExsist_ReturnTrue()
        {
            int id = 1;
            bool result = _devrepo.DeleteDev(id);
            Assert.IsTrue(result);
        }
    }
    
}
