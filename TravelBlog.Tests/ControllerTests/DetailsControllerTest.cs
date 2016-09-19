using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelsBlog.Controllers;
using TravelsBlog.Models;
using Xunit;

namespace TravelBlog.Tests.ControllerTests
{
    public class DetailsControllerTest
    {
        Mock<IDetailRepository> mock = new Mock<IDetailRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Details).Returns(new Detail[]
            {
                new Detail { DetailId = 1, SuggestionId = 1, Description = "Wash the dog" },
                new Detail { DetailId = 2, SuggestionId = 2, Description = "Do the dishes" },
                new Detail { DetailId = 3, SuggestionId = 3, Description = "Sweep the floor" }
            }.AsQueryable());
        }
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            DbSetup();
            DetailsController controller = new DetailsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);

        }
    }
}
