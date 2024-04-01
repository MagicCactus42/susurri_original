using Susurri.Client.DAL;
using Susurri.Client.Entities;
using Susurri.Client.Models;
using Susurri.Client.ValueObjects;

namespace Susurri.Client.Services;

internal sealed class UserService
{
    private readonly SusurriDbContext _context;
    
    public UserService(SusurriDbContext context)
    {
        _context = context;
    }
    
    public bool UserExists(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }
        
    public void SaveUser(SignUpViewModel model)
    {
       
    }
}