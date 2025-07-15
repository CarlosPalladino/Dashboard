using System.ComponentModel.DataAnnotations;

namespace Shared.Dto.Provider
{
    public class ProviderRequest
    {
        [Required(ErrorMessage = "The name is required")]
        [StringLength(15)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "The cuit is required")
        [StringLength(10)]
        public long Cuit { get; private set; }
        [Required(ErrorMessage = "The email is required")]
        [StringLength(10)]
        public string Email { get; private set; }
    }
}
