using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalyst.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyst.Data.Context;
using Moq;
using Catalyst.Data.Entities;
using System.Data.Entity;

namespace Catalyst.Data.Service.Tests
{
    [TestClass()]
    public class CatalystMemberServiceTests
    {
        public CatalystMemberServiceTests()
        {
            Initialize();
        }


        private CatalystMemberService service;
        private void Initialize()
        {
            var expectedMember = new CatalystMember { Id = 1, FirstName = "test1", LastName = "test1" };
            var data = new List<CatalystMember>
            {
                 expectedMember,
                  new CatalystMember { Id = 2, FirstName = "test2", LastName = "test2" },
                   new CatalystMember { Id = 3, FirstName = "test3", LastName = "test3" },
                    new CatalystMember { Id = 4, FirstName = "test4", LastName = "test4" }
            }.AsQueryable();

            var dbSetMock = new Mock<IDbSet<CatalystMember>>();
            dbSetMock.Setup(m => m.Provider).Returns(data.Provider);
            dbSetMock.Setup(m => m.Expression).Returns(data.Expression);
            dbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
            dbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var customDbContextMock = new Mock<CatalystDbContext>();
            customDbContextMock
                .Setup(x => x.DbEntities)
                .Returns(dbSetMock.Object);

            service = new CatalystMemberService(customDbContextMock.Object);

        }

        [TestMethod()]
        public void GetAllTest()
        {

            var members = service.GetAll();
            Assert.AreEqual(4, members.Count);

        }

        [TestMethod()]
        public void SearchTest()
        {
            var members = service.Search("test");
            Assert.AreEqual(4, members.Count);

        }

        [TestMethod()]
        public void CreateTest()
        {
            var members = service.GetAll();
            int count = members.Count;
            CatalystMember member = new CatalystMember { Id = 8, FirstName = "test" + count, LastName = "test" + count };
           Assert.IsFalse(service.Create(member));
           

        }


    }
}