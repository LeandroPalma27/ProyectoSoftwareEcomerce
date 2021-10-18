using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Evaluacion4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using static Evaluacion4.Data.ApplicationDbContext;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Evaluacion4.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _IWebHostEnvironment;


        public RegisterModel(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _IWebHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Display(Name = "Nombre")]
            [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "APaterno")]
            [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
            public string APaterno { get; set; }

            [Display(Name = "AMaterno")]
            [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
            public string AMaterno { get; set; }

            [Display(Name = "DNI")]
            [MaxLength(8, ErrorMessage = "El campo no debe de tener mas de 8 caracteres")]
            public string DNI { get; set; }

            [Display(Name = "Direccion")]
            [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
            public string Direccion { get; set; }

            [Display(Name = "Imagen")]
            public string Imagen { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile picture, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Usuario { UserName = Input.Email, Email = Input.Email,
                    Nombre = Input.Nombre,
                    APaterno = Input.APaterno,
                    AMaterno = Input.AMaterno,
                    DNI = Input.DNI,
                    Direccion = Input.Direccion
                };

                if (picture != null)
                {

                    string rutaImagen = Path.Combine(_IWebHostEnvironment.WebRootPath, "imagen/perfil");
                    string archivoUnico = $"{Guid.NewGuid().ToString()}-{Path.GetExtension(picture.FileName)}";
                    string rutaFinal = Path.Combine(rutaImagen, archivoUnico);
               
                    using (var file = new FileStream(rutaFinal, FileMode.Create))
                    {
                        await picture.CopyToAsync(file);
                    }

                    user.Imagen = $"imagen/perfil/{archivoUnico}";


                }
                else
                {
                    user.Imagen = null;
                }



                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
