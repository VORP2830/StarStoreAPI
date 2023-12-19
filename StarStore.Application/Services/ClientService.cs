using AutoMapper;
using StarStore.Application.DTOs;
using StarStore.Application.Interfaces;
using StarStore.Domain.Entities;
using StarStore.Domain.Exceptions;
using StarStore.Domain.Interfaces;

namespace StarStore.Application.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ClientDto> GetClientById(Guid id)
    {
        Client client = await _unitOfWork.ClientRepository.GetClientById(id);
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> Create(ClientDto model)
    {
        Client client = _mapper.Map<Client>(model);
        _unitOfWork.ClientRepository.Add(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> Update(ClientDto model)
    {
        Client client = await _unitOfWork.ClientRepository.GetClientById(model.Id);
        if(client is null) throw new StarStoreException("Cliente não encontrado");
        _mapper.Map(client, model);
        _unitOfWork.ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> Delete(Guid id)
    {
        Client client = await _unitOfWork.ClientRepository.GetClientById(id);
        if(client is null) throw new StarStoreException("Cliente não encontrado");
        client.SetActive(false);
        _unitOfWork.ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }

}
