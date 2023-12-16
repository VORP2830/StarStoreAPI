using AutoMapper;
using StarStore.Domain.Entities;

namespace StarStore.Application.DTOs.Mapping;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Client, ClientDto>().ReverseMap();
		CreateMap<Product, ProductDto>().ReverseMap();
		CreateMap<CreditCard, CreditCardDto>().ReverseMap();
		CreateMap<Transaction, TransactionDto>().ReverseMap();
	}
}