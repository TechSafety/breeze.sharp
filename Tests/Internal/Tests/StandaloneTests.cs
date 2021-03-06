using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Breeze.Sharp.Tests {

  [TestClass]
  public class StandaloneTests {

    

    [TestInitialize]
    public void TestInitializeMethod() {
      Configuration.__Reset();
      
    }

    [TestCleanup]
    public void TearDown() {

    }


    [TestMethod]
    public async Task NoClrTypes() {
      
      var serviceName = TestFns.serviceName;
      var ds = new DataService(serviceName);
      try {
        var ms = new MetadataStore();
        await ms.FetchMetadata(ds);
      } catch (Exception e) {
        Assert.IsTrue(e.Message.Contains("Configuration.Instance"), e.Message);
      }

      try {
        var em = new EntityManager(ds);
        await em.FetchMetadata();
      }
      catch (Exception e) {
        Assert.IsTrue(e.Message.Contains("Configuration.Instance"), e.Message);
      }
    }

    

    
  }


    
}
