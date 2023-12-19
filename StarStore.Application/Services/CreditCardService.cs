using AutoMapper;
using StarStore.Application.Interfaces;
using StarStore.Domain.Interfaces;

namespace StarStore.Application.Services;
public class CreditCardService : ICreditCardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreditCardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}
