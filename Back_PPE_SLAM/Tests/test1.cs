using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM_PPE_SLAM;
using System;
using Model; 

namespace Tests
{
    [TestClass]
    public class test1
    {
        [TestMethod]
        public void TestSpecialites()
        {
            data_model orm = new data_model();

            departement dep = orm.departements.Find(69);
            string dep_nom = dep.nom_dep;

            departement dep2 = new departement
            {
                id_dep = 69,
                nom_dep = "Rhône",
                reg_dep = "Auvergne-Rhône-Alpes"
            };

            Assert.AreEqual(dep2.nom_dep, dep_nom);
        }

        public void TestDepartements()
        {

        }

        public void TestMedecins()
        {

        }
    }
}
