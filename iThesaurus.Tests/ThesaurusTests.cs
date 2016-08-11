using iThesaurus.Domain.Abstract;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace iThesaurus.Tests
{
    [TestClass]
    public class ThesaurusTests
    {
        [TestMethod]
        public void Synonyms_can_be_added_and_returned()
        {
            // Arrange
            var unityContainer = new UnityContainer();
            UnityConfig.ConfigureContainer(unityContainer);
            var thesaurus = unityContainer.Resolve<IThesaurus>();

            // Act
            string newWord = "awesome";
            string synonym = "amazing";
            thesaurus.AddSynonyms(newWord, new[] { synonym });

            // Assert
            var synonyms = thesaurus.GetSynonyms(newWord);
            Assert.IsTrue(synonyms.Contains(synonym));
        }
    }
}
