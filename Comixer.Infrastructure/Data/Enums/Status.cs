using System.ComponentModel.DataAnnotations;

namespace Comixer.Infrastructure.Enums
{
    public enum Status
    {
        [Display(Name = "To Be Released")]
        ToBeReleased = 0,
        Releasing = 1,
        Completed = 2
    }
}
