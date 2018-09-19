using FizzWare.NBuilder;
using Xm.Trial.Models.Data;

namespace Xm.Trial.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            var authors = Builder<Author>.CreateListOfSize(10)
                                         .All()
                                         .With(a => a.Name = Faker.Name.FullName())
                                         .With(a => a.Avatar = $"https://api.adorable.io/avatars/128/{a.Name}.png")
                                         .With(a => a.Registered = DateTimeOffset.UtcNow.AddDays(-Faker.RandomNumber.Next(100)))
                                         .Build();

            context.Authors.AddOrUpdate(a => a.Id, authors.ToArray());

            var tags = new[]
                       {
                           new Tag {Id = 1, Name = "culture"},
                           new Tag {Id = 2, Name = "music"},
                           new Tag {Id = 3, Name = "politics"},
                           new Tag {Id = 4, Name = "business"},
                           new Tag {Id = 5, Name = "people"},
                           new Tag {Id = 6, Name = "celebrities"},
                           new Tag {Id = 7, Name = "education"},
                           new Tag {Id = 8, Name = "technology"},
                           new Tag {Id = 9, Name = "entertainment"}
                       };

            context.Tags.AddOrUpdate(t => t.Id, tags);

            var posts = Builder<Post>.CreateListOfSize(100)
                             .All()
                             .With(p => p.Created = DateTimeOffset.UtcNow.AddDays(-Faker.RandomNumber.Next(100)))
                             .With(p => p.Title = Faker.Lorem.Sentence(8))
                             .With(p => p.Picture = "https://placeimg.com/640/480/any")
                             .With(p => p.PictureCaption = Faker.Lorem.Sentence(3))
                             .With(p => p.Snippet = Faker.Lorem.Sentence(30))
                             .With(p => p.Text = string.Join("\r\n", Faker.Lorem.Paragraphs(10).Select(paragraph => $"<p>{paragraph}</p>")))
                             .With(p => p.Likes = Faker.RandomNumber.Next(50))
                             .With(p => p.AuthorId = Pick<Author>.RandomItemFrom(authors).Id)
                             .With(p => p.Tags = Pick<Tag>.UniqueRandomList(4).From(tags))
                             .Build();

            context.Posts.AddOrUpdate(p => p.Id, posts.ToArray());
        }
    }
}
