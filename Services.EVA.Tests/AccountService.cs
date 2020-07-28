using Dal;
using Dal.Entities;
using Dal.Implementation;
using Dal.Interface;
using Moq;
using Services.Tests.Fixtures;
using StructureMap;
using Xunit;

namespace Services.Tests
{
    public class AccountService : IClassFixture<DatabaseFixture>, IClassFixture<ContainerFixture>
    {
        private readonly DBContext _auditContext;
        public IContainer _container;
        private static bool isConfigured = false;
       

        public AccountService(DatabaseFixture databaseFixture,
            ContainerFixture containerFixture)
        {
            _auditContext = databaseFixture.DbContext;
            _container = containerFixture.Container;
            if (!isConfigured)
            {
                isConfigured = true;
                var emailSenderService = new Mock<IEmailSenderService>();
                _container.Configure(x => x.For<IEmailSenderService>().Use(emailSenderService.Object));
            }
        }

        [Fact]
        public void Company_Login()
        {
          
            _auditContext.Companys.Add(new Company()
            {
                Name = "George",
                Address = "24,Black street",
                ContactNumber = "9803482335",
                OwnerName = "George",
                Password = "123456",
                EmailAddress = "George@yahoo.com"
            });
            _auditContext.SaveChanges();
            var userService = new UserService(_auditContext);
            var data = userService.CompanyLogin("George@yahoo.com", "123456");
            Assert.NotNull(data);
            Assert.Equal("George", data.Name);
        }
    }
}
