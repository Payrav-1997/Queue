namespace Domain.ViewModels.Region
{
    public class GetRegionVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static GetRegionVm? FromEntity(Models.Entities.Region? entity)
        {
            if (entity is null) return null;

            return new GetRegionVm
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}