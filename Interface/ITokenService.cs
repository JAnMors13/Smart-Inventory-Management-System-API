using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser AppUser);
    }
}
