using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TestCookies.Controllers;

/// <summary>
/// Manages culture settings for the application.
/// </summary>
/// <remarks>
/// This controller allows users to set their language and culture preferences,
/// which are stored in a cookie for future requests.
/// </remarks>
[Route("[controller]/[action]")]
public class CultureController : Controller
{
    /// <summary>
    /// Sets the user's culture preference in a cookie.
    /// </summary>
    /// <param name="culture">The culture code to set (e.g., "en-US", "fr-FR").</param>
    /// <param name="returnUrl">The URL to redirect the user back to after setting the culture.</param>
    /// <returns>
    /// A <see cref="LocalRedirectResult"/> that redirects the user to the specified return URL.
    /// </returns>
    /// <remarks>
    /// This method updates the <see cref="RequestCulture"/> cookie with the specified culture,
    /// which is then used to localize the application for the user on future requests. 
    /// The cookie will expire in one year.
    /// </remarks>
    [HttpPost]
    public IActionResult SetCulture(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

        return LocalRedirect(returnUrl);
    }
}
