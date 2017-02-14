using Microsoft.VisualStudio.TestTools.UnitTesting;
using XF.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.WebApi.Tests
{
    [TestClass()]
    public class ExtensionMethodsTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var d = GetDictionary();
            int i = d.Get<int>("a");
            Assert.AreEqual(i, 1);
            DateTime tDate = d.Get<DateTime>("b");
            Assert.AreEqual(tDate, DateTime.Parse("2014-05-01"));
        }

        [TestMethod()]
        public void GetAsStringTest()
        {

        }

        [TestMethod()]
        public void TrySetTest()
        {

        }

        [TestMethod()]
        public void ToXmlStringTest()
        {

        }


        private Dictionary<string,object> GetDictionary()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("a", 1);
            d.Add("b", DateTime.Parse("2014-05-01"));
            d.Add("C", 50.5M);
            d.Add("d", new Guid("704BBA75-DD09-440C-A230-79F0F0B881B3"));
            return d;
        }
    }
}