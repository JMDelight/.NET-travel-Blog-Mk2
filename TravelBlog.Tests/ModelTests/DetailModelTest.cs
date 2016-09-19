using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelsBlog.Models;
using Xunit;

namespace TravelBlog.Tests
{
    public class DetailModelTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            Detail testDetail = new Detail();
            testDetail.Description = "Test";
            var result = testDetail.Description;
            //Assert
            Assert.Equal("Test", result);
        }

    }
}
