using Core.Enums;

namespace Core.DTOs
{
    public class AnimalDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public Status Status { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
