using AutoMapper;
using StarStore.Application.DTOs;
using StarStore.Application.Interfaces;
using StarStore.Domain.Entities;
using StarStore.Domain.Exceptions;
using StarStore.Domain.Interfaces;

namespace StarStore.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TransactionDto>> GetAllTransactions()
    {
        IEnumerable<Transaction> transactions = await _unitOfWork.TransactionRepository.GetAllTransactions();
        return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
    }

    public async Task<TransactionDto> GetTransactionById(Guid id)
    {
        Transaction transaction = await _unitOfWork.TransactionRepository.GetTransactionById(id);
        return _mapper.Map<TransactionDto>(transaction);
    }

    public async Task<IEnumerable<TransactionDto>> GetTransactionsByClientId(Guid clientId)
    {
        IEnumerable<Transaction> transactions = await _unitOfWork.TransactionRepository.GetTransactionsByClientId(clientId);
        return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
    }

    public async Task<TransactionDto> Create(TransactionDto model)
    {
        Transaction transaction = _mapper.Map<Transaction>(model);
        _unitOfWork.TransactionRepository.Update(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TransactionDto>(transaction);
    }

    public async Task<TransactionDto> Update(TransactionDto model)
    {
        Transaction transaction = await _unitOfWork.TransactionRepository.GetTransactionById(model.Id);
        if(transaction is null) throw new StarStoreException("Transação não encontrada");
        _mapper.Map(transaction, model);
        _unitOfWork.TransactionRepository.Update(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TransactionDto>(transaction);
    }
    public async Task<TransactionDto> Delete(Guid id)
    {
        Transaction transaction = await _unitOfWork.TransactionRepository.GetTransactionById(id);
        if(transaction is null) throw new StarStoreException("Transação não encontrada");
        transaction.SetActive(false);
        _unitOfWork.TransactionRepository.Update(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TransactionDto>(transaction);
    }


}
