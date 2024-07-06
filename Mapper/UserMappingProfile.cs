using AutoMapper;
using ProjektOrganizerNotatek.DTO;
using ProjektOrganizerNotatek.Model;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjektOrganizerNotatek.Mapper
{
    public class NoteMappingProfile : Profile
    {
        public NoteMappingProfile()
        {
            CreateMap<NotesEntity, NotesDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
