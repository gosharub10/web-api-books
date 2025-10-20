using AutoMapper;
using Web.BLL.DTOs.Author;
using Web.DAL.Models;

namespace Web.BLL.Mapping;

public class AuthorConfigMapper : Profile
{
    public AuthorConfigMapper()
    {
        CreateMap<Author, GetAuthor>();
        CreateMap<CreateAuthor, Author>();
        CreateMap<UpdateAuthor, Author>();
    }
}