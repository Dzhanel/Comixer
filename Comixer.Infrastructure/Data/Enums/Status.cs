using System.ComponentModel.DataAnnotations;

namespace Comixer.Infrastructure.Enums
{
    public enum Status
    {
        [Display(Name = "Not Yet Released")]
        NotYetReleased = 0,
        Releasing = 1,
        Completed = 2
    }
}
