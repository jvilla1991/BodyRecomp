using BodyRecomp.Entities;
using BodyRecomp.Requests.Ingredient;
using BodyRecomp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BodyRecomp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/Ingredient
        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> Get()
        {
            var ingredients = _ingredientService.GetAll();
            return Ok(ingredients);
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}")]
        public ActionResult<Ingredient> Get(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            if (ingredient == null)
                return NotFound();
            return Ok(ingredient);
        }

        // POST: api/Ingredient
        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientRequest request)
        {
            var result = await _ingredientService.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/Ingredient/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ingredient updated)
        {
            var success = _ingredientService.Update(id, updated);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Ingredient/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _ingredientService.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
