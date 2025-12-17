using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudCannia.Data;
using CrudCannia.Models;
using System.Security.Cryptography;
using System.Text;

namespace CrudCannia.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var hash = HashPassword(password);

            System.Diagnostics.Debug.WriteLine("=================================");
            System.Diagnostics.Debug.WriteLine("EMAIL: " + email);
            System.Diagnostics.Debug.WriteLine("PASSWORD: " + password);
            System.Diagnostics.Debug.WriteLine("HASH GENERADO: " + hash);
            System.Diagnostics.Debug.WriteLine("=================================");

            var propietario = await _context.Propietarios
                .FirstOrDefaultAsync(p => p.Email == email && p.PasswordHash == hash);

            if (propietario == null)
            {
                ViewBag.Error = "Email o contraseña incorrectos";
                return View();
            }

            HttpContext.Session.SetInt32("PropietarioId", propietario.IdPropietario);
            HttpContext.Session.SetString("PropietarioNombre", propietario.Nombre);

            return RedirectToAction("Dashboard");
        }


        // GET: /Account/Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("PropietarioId") == null)
                return RedirectToAction("Login");

            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
