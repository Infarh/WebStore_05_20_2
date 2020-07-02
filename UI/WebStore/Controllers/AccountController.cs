using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels.Identity;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<AccountController> _Logger;

        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager, ILogger<AccountController> Logger)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _Logger = Logger;
        }

        #region Register new user

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);


            var user = new User
            {
                UserName = Model.UserName
            };

            using (_Logger.BeginScope("Регистрация нового пользователя {0}", user.UserName))
            {
                _Logger.LogInformation("Начинается процесс регистрации нового пользователя {0}", user.UserName);
                var registration_result = await _UserManager.CreateAsync(user, Model.Password);
                if (registration_result.Succeeded)
                {
                    _Logger.LogInformation("Пользователь {0} успешно зарегистрирован", user.UserName);
                    var add_user_role_result = await _UserManager.AddToRoleAsync(user, Role.User);
                    if (add_user_role_result.Succeeded)
                        _Logger.LogInformation("Пользователю успешно добавлена роль {0}", Role.User);
                    else
                    {
                        _Logger.LogError(
                            "Ошибка при добавлении пользователю роли {0}: {1}",
                            Role.User,
                            string.Join(",", add_user_role_result.Errors.Select(error => error.Description)));

                        throw new ApplicationException("Ошибка наделения нового пользователя ролью Пользователь");
                    }

                    await _SignInManager.SignInAsync(user, false);
                    _Logger.LogInformation("Пользователь {0} успешно пошёл в систему", user.UserName);

                    return RedirectToAction("Index", "Home");
                }

                _Logger.LogError(
                    "Ошибка при добавлении нового пользователя роли {0}: {1}",
                    user.UserName, string.Join(",", registration_result.Errors.Select(error => error.Description)));

                foreach (var error in registration_result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }

            //_Logger.Log(LogLevel.Critical, new EventId(0, "Test"), "QWE", null, (s, e) => s);

            return View(Model);
        }

        #endregion

        #region Login user

        public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var login_result = await _SignInManager.PasswordSignInAsync(
                Model.UserName,
                Model.Password,
                Model.RememberMe,
                false);

            if (login_result.Succeeded)
            {
                _Logger.LogInformation("Пользователь {0} успешно вошёл в систему");

                if (Url.IsLocalUrl(Model.ReturnUrl))
                {
                    _Logger.LogDebug("Выполняю перенаправление на {0}", Model.ReturnUrl);
                    return Redirect(Model.ReturnUrl);
                }
                _Logger.LogDebug("Выполняю перенаправление на главную страницу");
                return RedirectToAction("Index", "Home");
            }

            _Logger.LogWarning("Пользователь {0} произвёл некорректную попытку входа в систему");

            ModelState.AddModelError(string.Empty, "Неверное имя пользователя, или пароль!");

            return View(Model);
        }

        #endregion

        public async Task<IActionResult> Logout()
        {
            var user_name = User.Identity.Name;
            await _SignInManager.SignOutAsync();
            _Logger.LogInformation("Пользователь {0} вышел из системы", user_name);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();
    }
}
