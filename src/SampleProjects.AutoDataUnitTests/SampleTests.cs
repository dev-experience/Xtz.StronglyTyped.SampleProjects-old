using NUnit.Framework;
using Xtz.StronglyTyped.BuiltinTypes.AutoFixture;
using Xtz.StronglyTyped.BuiltinTypes.Company;

namespace SampleProjects.AutoDataUnitTests
{
    public class SampleTests
    {
        [Test]
        // `StrongAutoDataAttribute` to auto-inject arguments
        [StrongAutoData]
        public void CompanyNameTest(
            // Argument is auto-populated by respective custom Bogus faker
            CompanyName companyName)
        {
            // Act

            // Implicit conversion test from `CompanyName` to `string`
            string companyNameString = companyName;


            // Assert

            Assert.AreEqual(companyName.Value, companyNameString);
        }
    }
}