namespace Nintex.Data.Migrations
{
    using Nintex.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Nintex.Data.TinyUrlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Nintex.Data.TinyUrlContext context)
        {
            IList<TinyUrl> urls = new List<TinyUrl>();
            urls.Add(new TinyUrl() {
                LongUrl = "http://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx",
                ShortUrl = "testing",
                Segment = "2e7358",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now });
            context.TinyUrls.AddRange(urls);
            base.Seed(context);
        }
    }
}
