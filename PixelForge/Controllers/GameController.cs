﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixelForge.Controllers.Data;
using PixelForge.Models;

namespace PixelForge.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context) {  
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            var game = await _context.Games.ToListAsync();
            return View(game);
        }
        public async Task<IActionResult> Store()
        {
            var game = await _context.Games.ToListAsync();
            return View(game);
        }

        public IActionResult Create() { 
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> Create([Bind("Id, Title, Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null) { 
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
