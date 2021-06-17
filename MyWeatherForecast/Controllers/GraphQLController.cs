using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MyWeatherForecast.Database;
using MyWeatherForecast.GraphQL;

namespace MyWeatherForecast.Controllers
{
  [Route("graphql")]
  [ApiController]
  public class GraphQLController : Controller
  {
    private readonly ApplicationDbContext _db;

    public GraphQLController(ApplicationDbContext db) => _db = db;

        //public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        //{
        //  //var inputs = query.Variables.ToInputs();      

        //  var schema = new Schema
        //  {
        //    Query = new AuthorQuery(_db)
        //  };

        //  var result = await new DocumentExecuter().ExecuteAsync(_ =>
        //  {
        //    _.Schema = schema;
        //    _.Query = query.Query;
        //    _.OperationName = query.OperationName;        
        //  });

        //  if(result.Errors?.Count > 0)
        //  {
        //    return BadRequest();
        //  }

        //  return Ok(result);
        //  }
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = new StarWarsQuery() };

            var json = await schema.ExecuteAsync(_ =>
            {
                _.Query = "{ hero { id name } }";
            });

            //if (result.Errors?.Count > 0)
            //{
            //    return BadRequest();
            //}

            return Ok(json);
        }
    }
}
