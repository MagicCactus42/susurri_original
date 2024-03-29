using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Susurri.Client.Models;

public class SignUpModel : PageModel
{
    // For simplicity HttpClient is used. In a real world application, you'd use IHttpClientFactory
    private static readonly HttpClient client = new HttpClient();
    
    [BindProperty]
    public SignUpViewModel SignUp { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Use appropriate address where your API lives
        var response = await client.PostAsJsonAsync("https://localhost:7083/account", SignUp);
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("/chat");
        }
        return Page();
    }
}