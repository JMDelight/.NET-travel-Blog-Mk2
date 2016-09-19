using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelsBlog.Controllers;
using TravelsBlog.Models;
using Xunit;

namespace TravelBlog.Tests
{
    public class SuggestionControllerTest
    {
        Mock<ISuggestionRepository> mock = new Mock<ISuggestionRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Suggestions).Returns(new Suggestion[]
            {
                new Suggestion {SuggestionId = 1, Destination = "Wash the dog",
                Votes = 3},
                new Suggestion {SuggestionId = 2, Destination = "Do the dishes", Votes = 1 },
                new Suggestion {SuggestionId = 3, Destination = "Sweep the floor", Votes = 5 }
            }.AsQueryable());
        }
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            DbSetup();
            SuggestionsController controller = new SuggestionsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);

        }
    }
}
