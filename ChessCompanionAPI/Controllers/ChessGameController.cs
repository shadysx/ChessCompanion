using ChessCompanionAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChessCompanionAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChessGameController : ControllerBase
    {
        private readonly DataContext _context;
        public ChessGameController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<ChessGame>>> ListGames()
        {

            return Ok(await _context.ChessGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChessGame>> GetGame(int id)
        {
            var game = await _context.ChessGames.FindAsync(id);
            if (game is null)
                return BadRequest("Game not found");
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<ChessGame>> AddGame(ChessGame game)
        {
            _context.ChessGames.Add(game);
            await _context.SaveChangesAsync();

            return Ok(await _context.ChessGames.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<ChessGame>> UpdateGame(ChessGame updatedGame)
        {
            var game = await _context.ChessGames.FindAsync(updatedGame.Id);
            if (game is null)
                return BadRequest("Game not found");

            game.Date = updatedGame.Date;
            game.Moves = updatedGame.Moves;

            await _context.SaveChangesAsync();
            return Ok(await _context.ChessGames.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<ChessGame>> DeleteGame(int id)
        {
            var game = await _context.ChessGames.FindAsync(id);
            if (game is null)
                return BadRequest("Game not found");
            
            _context.ChessGames.Remove(game);
            await _context.SaveChangesAsync();

            return Ok(await _context.ChessGames.ToListAsync());
        }
    }
}
