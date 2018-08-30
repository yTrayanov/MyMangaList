using Microsoft.EntityFrameworkCore;
using MyMangaList.Data;
using System;

namespace MyMangaList.Test.Mocks
{
    public static class MockDbContext
    {
        public static MyMangaListContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MyMangaListContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            return new MyMangaListContext(options);

        }
    }
}
