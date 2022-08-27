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

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> FetchOneById(int id)
        {
            // Busca um herói pelo id
            var hero = heroes.Find(h => h.Id == id);

            // Se não achar um herói com o id, retorna erro
            if (hero == null)
            {
                return NotFound("Hero not found.");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Register(SuperHero hero)
        {
            // Adiciona o herói novo ao fim do array
            heroes.Add(hero);

            return Ok(heroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> Update(SuperHero request, int id)
        {
            // Busca um herói pelo id
            var hero = heroes.Find(h => h.Id == id);

            // Se não achar um herói com o id, retorna erro
            if (hero == null)
            {
                return NotFound("Hero not found.");
            }

            // Ataulia os campos do herói
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            // Busca um herói pelo id
            var hero = heroes.Find(h => h.Id == id);

            // Se não achar um herói com o id, retorna erro
            if (hero == null)
            {
                return NotFound("Hero not found.");
            }

            // Apaga o herói
            heroes.Remove(hero);

            return Ok("Hero deleted successfully.");
        }

    }
}
