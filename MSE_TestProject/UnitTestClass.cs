using Microsoft.EntityFrameworkCore;
using MSE_ClassLibrary;

namespace MSE_TestProject
{
    [TestClass]
    public class SearchServiceTests
    {
        private DbContextOptions<MovieDB>? options;

        [TestInitialize]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<MovieDB>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // neue DB je Test
                .Options;

            using var db = new MovieDB(options);
            MovieDB.SeedData(db);
        }

        [TestMethod]
        public void Test_SearchService()
        {
            using var db = new MovieDB(options);
            var service = new SearchService(db);
            var result = service.PerformSearch("o");

            Assert.AreEqual(13, result.TotalCount);
        }

        [TestMethod]
        public void Test_SearchService_Finds_Film()
        {
            using var db = new MovieDB(options);
            var service = new SearchService(db);
            var result = service.PerformSearch("flow");

            Assert.AreEqual(1, result.FilmCount);
        }

        [TestMethod]
        public void Test_SearchService_Finds_Year()
        {
            using var db = new MovieDB(options);
            var service = new SearchService(db);
            var result = service.PerformSearch("20");

            Assert.AreEqual(4, result.YearCount);
        }

        [TestMethod]
        public void Test_SearchService_Finds_Sync()
        {
            using var db = new MovieDB(options);
            var service = new SearchService(db);
            var result = service.PerformSearch("ben");

            Assert.AreEqual(1, result.SyncCount);
        }

        [TestMethod]
        public void Test_SearchService_Finds_Actor()
        {
            using var db = new MovieDB(options);
            var service = new SearchService(db);
            var result = service.PerformSearch("leo");

            Assert.AreEqual(1, result.ActCount);
        }

        [TestMethod]
        public void Test_SearchService_Finds_Director()
        {
            using var db = new MovieDB(options);
            var service = new SearchService(db);
            var result = service.PerformSearch("cam");

            Assert.AreEqual(1, result.DirCount);
        }

    }
}

