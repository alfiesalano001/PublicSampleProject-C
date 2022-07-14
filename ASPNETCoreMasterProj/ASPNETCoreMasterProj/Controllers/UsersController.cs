using Repositories.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Repositories.Models;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Repositories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAuthJWToken _authJWToken;
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        const string emailAddress = "alfie.salano@gmail.com";
        const string mailPassword = "password123";

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthJWToken authJWToken, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authJWToken = authJWToken;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginBindingModel input)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid login params for: {input}");
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(input.UserName, input.Password, input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Successfull login for {input.UserName}.");
                    var token = _authJWToken.CreateJWToken(input.Email, input.Password);
                    return Ok(token);
                }
                else
                {
                    _logger.LogWarning($"Error when logging in User: {input.UserName}");
                    return BadRequest("Username/Password is invalid.");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for login: {input.UserName} Error: {ex}");
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterBindingModel users)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid register params for: {users}");
                return BadRequest(ModelState);
            }

            try
            {
                var user = new ApplicationUser { UserName = users.UserName, Email = users.Email };

                var result = await _userManager.CreateAsync(user, users.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Successfull RegisterAsync for {users.UserName}.");
                    var claim = new Claim("FullName", users.Name);
                    await _userManager.AddClaimAsync(user, claim);

                    // send an confirmation E-mail
                    // SendEmail(user);
                    return Ok(users);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogWarning($"Error when registering for  User: {users.UserName} Error: {error}");
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return BadRequest(ModelState);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for register: {users.UserName} Error: {ex}");
                throw ex;
            }
        }

        // sending email using gmail for testing
        [NonAction]        
        private async void SendEmail(ApplicationUser user)
        {
            try
            {
                _logger.LogInformation($"Sending an email for  user: {user.UserName} for email confirmation.");
                var userToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                userToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(userToken));
                string subject = $"Email confirmation - {user.UserName}";
                var callbackUrl = $"https://localhost:5002/Identity/Account/ConfirmEmail?area=Identity&userId={user.Id}&code={userToken}";
                var message = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

                using SmtpClient emailsender = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential(emailAddress, mailPassword)
                };
                emailsender.Send(emailAddress, user.Email, subject, message);
            }
            catch (SmtpException ex)
            {
                _logger.LogError($"Exception error for email sending for: {user.UserName} Error: {ex}");
                throw ex;
            }
        }
    }
}
