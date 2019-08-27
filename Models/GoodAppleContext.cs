using Microsoft.EntityFrameworkCore;

namespace GoodApple.Models {
    public class GoodAppleContext : DbContext {
        public GoodAppleContext(DbContextOptions options): base(options) {}
    }
}