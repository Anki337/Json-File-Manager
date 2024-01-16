using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Reflection;
using Xunit.Sdk;

namespace JsonFileManager.TEST
{
    public class ManagerTest
    {
        // Har en dictionary, F�r en json fil tillbaka
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

        [Fact]
        public void CreateJsonFromDict_NullDict_ShouldThrowArgumentNullException()
        {
            // Given 
            Dictionary<string, object> dict = new();
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentNullException>();

        }
        [Fact]
        public void CreateJsonFromDict_NullValue_ShouldThroNullReferenceException()
        {
            // Given 
            Dictionary<string, object> dict = new()
            {
                {"Name", "Gandalf"},
                {"Age", null},
                {"Profession", "Wizard"}
            };
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<NullReferenceException>();

        }
        [Fact]
        public void WriteJsonToFile_ValidJson_ShouldWriteJsonToFile()
        {
            // Given 
            // DummyJson data
            object obj = new { Name = "Gandalf", Age = 3000, Profession = "Wizard" };
            string json = JsonConvert.SerializeObject(obj);
            string fileName = "test.json";
            Manager manager = new();

            // When
            manager.WriteJsonToFile(json, "test.json");

            // Then
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            // h�mta inneh�llet i filen
            string fileContent = File.ReadAllText(filePath);
            // Testa om filecontent �r samma som json, is�fall har vi lyckats skriva till filen och sedan l�st ifr�n den
            fileContent.Should().BeEquivalentTo(json);

        }

        [Fact]
        public void WriteJsonToFile_InvalidJson_ShouldThrowJsonReaderException()
        {
            // Given 
            // DummyJson data
            string invalidJson = "test that should fail since this is not Json format";
            string fileName = "test.json";
            Manager manager = new();

            // When
            Action test = () => manager.WriteJsonToFile(invalidJson, fileName);

            // Then
            test.Should().Throw<JsonReaderException>();

        }
        
    }
}