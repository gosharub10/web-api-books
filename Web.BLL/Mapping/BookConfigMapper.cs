using AutoMapper;
using Web.BLL.DTOs.Books;
using Web.DAL.Models;

namespace Web.BLL.Mapping;

public class BookConfigMapper : Profile
{
    public BookConfigMapper()
    {
        CreateMap<Book, GetBook>();
        CreateMap<CreateBook, Book>();
        CreateMap<UpdateBook, Book>();
    }
}