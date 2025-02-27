﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication11.DAL;
using WebApplication11.ViewModels;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                Teams = await _appDbContext.Teams.Include(x => x.Profession).Take(4).ToListAsync(),
                Services = await _appDbContext.Services.Take(6).ToListAsync()
            };

            return View(vm);
        }
    }
}