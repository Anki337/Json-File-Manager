using FluentAssertions;
using Newtonsoft.Json;
using System.Reflection;
using Xunit.Sdk;

namespace JsonFileManager.TEST
{
    public class ManagerTest
    {
        // Har en dictionary, Får en json fil tillbaka
        [Fact]
        public void CreateJsonFromDict_ShouldReturnJson()
        {
            // Given 
            Dictionary<string, object> dict = new() 
            {
                {"Name", "Gandalf"},
                {"Age", 3000},
                {"Profession", "Wizard"}
            };

            Manager manager = new();

            // When

            string expectedJson = JsonConvert.SerializeObject(dict);

            string actualJson = manager.CreateJsonFromDict(dict);

            // Then

            actualJson.Should().NotBeNull();
            actualJson.Should().BeEquivalentTo(expectedJson);

        }
        [Fact]
        public void CreateJsonFromDict_EmptyDict_ShouldThrowArgumentException()
        {
            // Given 

            Dictionary<string, object> dict = new();
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentException>();

            

        }
        
    }
}