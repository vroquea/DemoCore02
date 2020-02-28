using System.ComponentModel.DataAnnotations;

namespace DemoCore02.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength =2)]
        public string Name { get; set; }
        [Required, StringLength(100, MinimumLength =2)]
        public string Location { get; set; }
        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
