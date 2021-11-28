using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeocacheAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeocacheAPI.Test
{
  [TestClass]
  public class ItemsControllerTests
  {

    List<Item> testDB = new List<Item> { };
    [TestMethod]
    public void TestMethod_checkActiveListforThrees()
    {
      //Arrange 

      testDB.Add(new Item { Id = 1, Name = "Coins", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default });
      testDB.Add(new Item { Id = 2, Name = "Jewelry", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default });
      testDB.Add(new Item { Id = 3, Name = "Trading Stones", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default });

      Item itemInput = new Item { Id = 4, Name = "Poem", GeocacheId = 1, IsActive = true, StartDate = default, EndDate = default };
      int count = 0;

      //Act
      foreach (var item in testDB)
      {
        if (item.GeocacheId == itemInput.GeocacheId && item.Id != itemInput.Id)
        {
          count++;
        }
      }

      //Assert 
      Assert.AreEqual(3, count);
      testDB.Clear();
    }

    [TestMethod]
    public void TestMethod2_nameCheck()
    {
      //Arrange 
      testDB.Add(new Item { Id = 1, Name = "Coins", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default });
      testDB.Add(new Item { Id = 2, Name = "Jewelry", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default });

      Item userInput = new Item { Id = 4, Name = "coins", GeocacheId = 1, IsActive = true, StartDate = default, EndDate = default };

      //Act
      var result = testDB.Any(e => e.Name.ToLower() == userInput.Name.ToLower());

      //Assert 
      Assert.AreEqual(true, result);
      testDB.Clear();
    }

    [TestMethod]
    public void TestMethod3_toggleActiveInactive()
    {
      //Arrange 

      DateTime testEnd = new DateTime(2018, 5, 26);
      DateTime testDefault = new DateTime(default);
      Item itemInput = new Item { Id = 1, Name = "Coins", GeocacheId = 1, IsActive = false, StartDate = DateTime.Now, EndDate = default };

      if (!itemInput.IsActive)
      {
        itemInput.EndDate = testEnd;
      }
      else
      {
        itemInput.StartDate = DateTime.Now;
        itemInput.EndDate = default;
      }

      //Assert 
      Assert.AreEqual(testEnd, itemInput.EndDate);
      Assert.AreNotEqual(testEnd, testDefault);
      testDB.Clear();

    }

  }


}
