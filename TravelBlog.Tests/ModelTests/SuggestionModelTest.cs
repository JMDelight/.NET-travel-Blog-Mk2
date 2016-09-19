using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelsBlog.Models;
using Xunit;

namespace TravelBlog.Tests
{
    public class SuggestionModelTest
    {
        [Fact]
        public void GetDestinationTest()
        {
            //Arrange
            var suggestion = new Suggestion();
            //Act
            suggestion.Destination = "test";
            var result = suggestion.Destination;

            //Assert
            Assert.Equal("test", result);
        }
        [Fact]
        public void GetDetailDescriptionFromSuggestion()
        {
            //Arrange
            Detail testDetail = new Detail();
            testDetail.Description = "testText";
            Suggestion testSuggestion = new Suggestion();
            testSuggestion.SuggestionId = 1;
            testSuggestion.Details = new List<Detail>();
            testSuggestion.Details.Add(testDetail);
            testDetail.DetailId = 1;
            testDetail.SuggestionId = 1;
            var result = testSuggestion.Details.ToList()[0].Description;
            //Assert
            Assert.Equal("testText", result);
            
        }
    }
}
