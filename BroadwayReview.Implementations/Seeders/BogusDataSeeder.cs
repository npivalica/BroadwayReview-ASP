using Bogus;
using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.Seeders;
using BroadwayReview.DataAccess;
using BroadwayReview.Domain.Entities;
using BroadwayReview.Implementations.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Seeders
{
    public class BogusDataSeeder : EFUseCaseConnection, ISeedFakeData
    {
        public BogusDataSeeder(BroadwayReviewContext context) : base(context)
        {
        }

        public void Seed()
        {
            if (Context.Plays.Any())
            {
                throw new UseCaseConflictException("Database has already been seeded.");
            }

            var authorFaker = new Faker<Author>();
            authorFaker.RuleFor(x => x.Name, x => x.Person.FullName);
            var authors = authorFaker.Generate(30);

            var playFaker = new Faker<Play>();
            playFaker.RuleFor(x => x.Title, x => x.Lorem.Word());
            playFaker.RuleFor(X => X.Year, x => x.Random.Int(1866, 2022));
            playFaker.RuleFor(X => X.Duration, x => x.Random.Int(57, 92));
            playFaker.RuleFor(x => x.Description, x => x.Lorem.Text());
            playFaker.RuleFor(x => x.Author, x => x.PickRandom(authors));
            var plays = playFaker.Generate(80);

            var actorPlayFaker = new Faker<ActorPlay>();
            actorPlayFaker.RuleFor(x => x.Play, x => x.PickRandom(plays));
            actorPlayFaker.RuleFor(x => x.CharacterName, x => x.Person.FullName);


            var actorFaker = new Faker<Actor>();
            actorFaker.RuleFor(x => x.Name, x => x.Person.FullName);
            actorFaker.RuleFor(x => x.ActorPlays, x => actorPlayFaker.Generate(3));
            var actors = actorFaker.Generate(30);

            var arr = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                arr.Add(i);
            }

            var user = new User();
            user.Email = "administrator@asp.com";
            user.Password = BCrypt.Net.BCrypt.HashPassword("ASPAdmin879&");
            user.Username = "admin";
            user.FirstName = "Admin";
            user.LastName = "Admin";
            var usecase = arr.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = 1
            });

            var genreFaker = new Faker<Genre>();
            genreFaker.RuleFor(x => x.Name, x => x.Lorem.Word());
            var genres = genreFaker.Generate(20);

            var genrePlayFaker = new Faker<PlayGenre>();
            genrePlayFaker.RuleFor(x => x.Genre, x => x.PickRandom(genres));
            genrePlayFaker.RuleFor(x => x.Play, x => x.PickRandom(plays));
            var genresPlays = genrePlayFaker.Generate(40);

            Context.Authors.AddRange(authors);
            Context.Actors.AddRange(actors);
            Context.Plays.AddRange(plays);
            Context.Users.AddRange(user);
            Context.UserUseCases.AddRange(usecase);
            Context.Genres.AddRange(genres);
            Context.PlayGenres.AddRange(genresPlays);


            Context.SaveChanges();

        }
    }
}
