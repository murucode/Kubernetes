using MyWeatherForecast.Database;
using GraphQL.Types;
using MyWeatherForecast.GraphQL;

namespace MyWeatherForecast.GraphQL
{
  public class AuthorType : ObjectGraphType<Author>
  {
    public AuthorType()
    {
      Name = "Author";

      Field(x => x.Id, type: typeof(IdGraphType)).Description("Author's ID.");
      Field(x => x.Name).Description("The name of the Author");
      Field(x => x.Books, type: typeof(ListGraphType<BookType>)).Description("Author's books");
    }
  }
}