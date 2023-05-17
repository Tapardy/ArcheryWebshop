namespace DAL.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public CategoryDTO(int id, string name, string imageUrl)
        {
            ID = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public CategoryDTO()
        {
        }
    }
}