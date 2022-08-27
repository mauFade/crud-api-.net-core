using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_api.Controllers
{
    [Route("api/v1/heroes")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham"
                },
                new SuperHero {                  
                    Id = 2,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Fetch()
        {
            // Retorna todos os heróis
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Register(SuperHero hero)
        {
            // Adiciona o herói novo ao fim do array
            heroes.Add(hero);

            return Ok(heroes);
        }

    }
}
