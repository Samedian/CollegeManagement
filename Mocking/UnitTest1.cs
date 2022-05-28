using CollegeManagementEntity;
using CollegeManagementRepository;
using CollegeManagementService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Mocking
{
    [TestClass]
    public class UnitTest1
    {
        private static Mock<IStudentRepo> mock = new Mock<IStudentRepo>();
        private static StudentSer save;

        [ClassInitialize]
        public static void BeforeClass(TestContext testContext)
        {
            save = new StudentSer(mock.Object);

        }

        [TestMethod]
        public async Task TestMethod1Async()
        {

            mock.Setup(x => x.AddStudent(It.IsAny<StudentEntity>())).ReturnsAsync(true);
            bool result = await save.AddStudent(It.IsAny<StudentEntity>());

            Assert.IsTrue(result);


        }


    }
}
