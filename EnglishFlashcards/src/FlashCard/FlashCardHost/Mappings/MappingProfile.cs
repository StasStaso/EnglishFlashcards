namespace FlashCard.Host.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WordJsonModel, WordDbModel>()
            .ForMember(dest => dest.WordId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.Word))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Value.Type))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Value.Level))
            .ForMember(dest => dest.PronunciationUkMp3, opt => opt.MapFrom(src => src.Value.Uk.Mp3))
            .ForMember(dest => dest.PhoneticsUk, opt => opt.MapFrom(src => src.Value.Phonetics.Uk))
            .ForMember(dest => dest.Examples, opt => opt.MapFrom(src => src.Value.Examples));
    }
}
