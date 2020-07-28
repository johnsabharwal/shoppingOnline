using Microsoft.EntityFrameworkCore;
using System;
using Dal;

namespace Services.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public DBContext DbContext { get; set; }
       // public AuditContext AuditContext { get; set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
              .UseInMemoryDatabase(databaseName: "integrative" + DateTime.Now.ToFileTime())
              .Options;
            DbContext = new DBContext(options);

           // DbContext.QuestionSetQuestionMaps.AddRange(new QuestionSetQuestionMapDataBuilder().Object);
            DbContext.SaveChanges();

        }
        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }
        }
    }
}
