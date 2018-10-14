using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRunes.Contracts;
using IRunes.Models;
using IRunes.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Results;

namespace IRunes.Controlers
{
    public class UserController : BaseController
    {
        IHashService hashService;

        public UserController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            var username = this.GetUsername(request);

            if (username != null)
            {
                this.ViewBag["username"] = username;
                return this.View("Home/Index");
            }

            return this.View();
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            string username = request.FormData["username"].ToString();
            string password = request.FormData["password"].ToString();

            string hashedPassword = this.hashService.Hash(password);

            var user = runesDbContext.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestError("Invalid username or password!", "User/Login");
            }

            request.Session.AddParameter("username", username);

            var userCookieValue = this.userCookieService.GetUserCookie(username);

            this.ViewBag["username"] = username;

            this.IsUserAuthenticated = true;

            var response = this.View("Home/Index");

            response.Cookies.Add(new HttpCookie("IRunes_auth", userCookieValue));

            return response;
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            var username = this.GetUsername(request);

            if (username == null)
            {
                return this.View("Home/Index");
            }

            var response = new RedirectResult("/");

            var cookie = request.Cookies.GetCookie("IRunes_auth");

            cookie.Delete();

            response.Cookies.Add(cookie);

            return response;
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View();
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            string username = request.FormData["username"].ToString();
            string password = request.FormData["password"].ToString();
            string confirmedPassword = request.FormData["confirmPassword"].ToString();
            string email = request.FormData["email"].ToString();

            if (string.IsNullOrWhiteSpace(username) || username.Length < 8)
            {
                return this.BadRequestError("The username has to be at least 8 characters.", "user/register");
            }

            if (this.runesDbContext.Users.Any(x => x.Username == username))
            {
                return this.BadRequestError("This username already exists.", "user/register");
            }

            if (password != confirmedPassword)
            {
                return this.BadRequestError("The passwords don't match.", "user/register");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 10)
            {
                return this.BadRequestError("The password needs to be at least 10 characters.", "user/register");
            }

            string hashedPassword = this.hashService.Hash(password);

            User user = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            runesDbContext.Users.Add(user);
            runesDbContext.SaveChanges();

            return this.View("User/Login");
        }
    }
}