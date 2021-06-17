using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

using MyWeatherForecast.Database;
using MyWeatherForecast.GraphQL;


namespace MyWeatherForecast.GraphQL
{
  public class AuthorQuery : ObjectGraphType
  {
    public AuthorQuery(ApplicationDbContext db)
    {
      Field<AuthorType>(
        "Author",
        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
        resolve: context =>
        {
          var id = (int)context.Arguments["id"].Value;
          //var id  = 1;
          var author = db
            .Authors
            .Include(a => a.Books)
            .FirstOrDefault(i => i.Id == id);
          return author;
        });

      Field<ListGraphType<AuthorType>>(
        "Authors",
        resolve: context =>
        {
          var authors = db.Authors.Include(a => a.Books);
          return authors;
        });
    }
  }
}