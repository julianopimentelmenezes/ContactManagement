using AutoMapper;

namespace ContactManagement.Business.Mappings
{
    /// <summary>
    /// This class configure the mappings profiles
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// This function add the mappings profiles
        /// </summary>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
