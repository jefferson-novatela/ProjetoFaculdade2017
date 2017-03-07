using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System;

namespace ProjetoLucy.Controllers
{
	public class Cookies
	{
		private const string Prefix = "423FF9D4-A252-4388-91E9-31D3BD1F37DE_";
		private static readonly TimeSpan CookieDuracao = TimeSpan.FromHours(1);

		public static void SetCookie(string key, string value)
		{
			key = Prefix + key;
			var encValue = HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes(value));
			var c = new HttpCookie(key, encValue) { Expires = DateTime.Now.Add(CookieDuracao) };
			HttpContext.Current.Response.Cookies.Add(c);
		}

		public static string GetCookie(string key)
		{
			key = Prefix + key;
			if (HttpContext.Current.Request.Cookies[key] == null ||
				HttpContext.Current.Request.Cookies[key].Value == null) return null;
			var decValue = HttpServerUtility.UrlTokenDecode(HttpContext.Current.Request.Cookies[key].Value);
			return decValue != null ? Encoding.UTF8.GetString(decValue) : "";
		}

		public static bool Exists(string key)
		{
			key = Prefix + key;
			var cookie = HttpContext.Current.Request.Cookies[key];

			return cookie?.Value != null;
		}

		public static void Remove(string cookie)
		{
			var cookieName = Prefix + cookie;
			var aCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
			HttpContext.Current.Response.Cookies.Add(aCookie);
		}

		public static void Remove(string[] cookies)
		{
			foreach (var cookie in cookies)
			{
				var cookieName = Prefix + cookie;
				var aCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
				HttpContext.Current.Response.Cookies.Add(aCookie);
			}
		}

		public static void RemoveAll()
		{
			var cookiesTotal = HttpContext.Current.Request.Cookies.Count;
			for (var i = 0; i < cookiesTotal; i++)
			{
				var requestCookie = HttpContext.Current.Request.Cookies[i];
				if (requestCookie == null) continue;
				var cookieName = requestCookie.Name;
				var aCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddDays(-1) };
				HttpContext.Current.Request.Cookies.Add(aCookie);
			}
		}
	}
}