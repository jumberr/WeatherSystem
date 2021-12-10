using CCL.Security.Identity;
using Xunit;

namespace BLL.Tests
{
    public class TemplateMethodTest
    {
        [Fact]
        public void TemplateMethod_CreateUser_Equals()
        {
            var user = new User(1, "user", 2);
            user.CreatePerson(out var reg, out var log, out var tutorial);
            Assert.Equal($"{user.Username}{nameof(User)}",  reg );
        }
        
        [Fact]
        public void TemplateMethod_CreateAdmin_Equals()
        {
            var user = new Admin(2, "admin", 3);
            user.CreatePerson(out var reg, out var log, out var tutorial);
            Assert.Equal($"Logged in as {nameof(Admin)}",  log );
        }
        
        [Fact]
        public void TemplateMethod_CreateDirector_Equals()
        {
            var user = new Director(2, "director", 3);
            user.CreatePerson(out var reg, out var log, out var tutorial);
            Assert.Equal($"Watched tutorial for {nameof(Director)}",  tutorial );
        }
    }
}