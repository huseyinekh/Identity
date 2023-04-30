using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdentityApp_.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrorList(this ModelStateDictionary ms, List<string> errors)
        {
            errors.ForEach(x =>
            {
                ms.AddModelError("", x);
            });

        }
    }
}
