
using AuthenticationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthenticationDbContext _dbContext;

        public UserController(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(string name, string email, bool status, string userName, string password)
        {
            // Encriptamos la contraseña
            string hashedPassword = HashPassword(password);

            // Creamos el nuevo usuario
            var newUser = new User
            {
                name = name,
                email = email,
                status = status,
                userName = userName,
                password = hashedPassword
            };

            // Agregamos el usuario a la base de datos
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok(newUser);
        }

        [HttpGet]
        [Route("login")]
        public ActionResult<string> Login(string userName, string password, string email)
        {
            // Buscar usuario en la base de datos
            var user = _dbContext.Users.FirstOrDefault(u => u.userName == userName && u.email == email);

            // Validar si se encontró el usuario
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Validar la contraseña
            string hashedPassword = HashPassword(password);
            if (user.password != hashedPassword)
            {
                return Unauthorized("Contraseña incorrecta");
            }

            // Generar token para el usuario
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secret-key-123456"); // Obtener el secreto para el token JWT de la configuración
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.userName),
            new Claim(ClaimTypes.Email, user.email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Retornar el token JWT como respuesta
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        private string HashPassword(string password)
        {
            // Se crea un objeto para realizar la encriptación SHA256
            SHA256 sha256 = SHA256.Create();

            // Convertimos el password en un arreglo de bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Se realiza la encriptación del password y se almacena en un arreglo de bytes
            byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);

            // Convertimos el arreglo de bytes a string
            string hashedPassword = Encoding.UTF8.GetString(hashedPasswordBytes);

            // Devolvemos el password encriptado
            return hashedPassword;
        }
    }
}
