using Microsoft.EntityFrameworkCore;
using SimApi.Data;
using SimApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimApi.Data.Context;

public interface ITransactionReportService 
{ 
    Task<List<TransactionViewResponse>> GetAll(); 
    Task<TransactionViewResponse> GetById(int id); 
    Task<List<TransactionViewResponse>> GetByReferenceNumber(string ReferenceNumber); 
    Task<List<TransactionViewResponse>> GetByAccountId(int AccountId); 
    Task<List<TransactionViewResponse>> GetByCustomerId(int CustomerId); 
}

public class TransactionReportService : ITransactionReportService 
{
    private readonly AppDbContext _context; 
    public TransactionReportService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<TransactionViewResponse>> GetAll()
    {
        var transactions = await _context.Transactions.ToListAsync();
        return transactions.Select(t => new TransactionViewResponse { /* Map properties here */ }).ToList();
    }
    public async Task<TransactionViewResponse> GetById(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        return new TransactionViewResponse { /* Map properties here */ };
    }
    public async Task<List<TransactionViewResponse>> GetByReferenceNumber(string ReferenceNumber)
    {
        var transactions = await _context.Transactions
            .Where(t => t.ReferenceNumber == ReferenceNumber).ToListAsync();
        return transactions.Select(t => new TransactionViewResponse { /* Map properties here */ }).ToList();
    }
    public async Task<List<TransactionViewResponse>> GetByAccountId(int AccountId)
    {
        var transactions = await _context.Transactions
            .Where(t => t.AccountId == AccountId).ToListAsync();
        return transactions.Select(t => new TransactionViewResponse { /* Map properties here */ }).ToList();
    }
public async Task<List<TransactionViewResponse>> GetByCustomerId(int CustomerId)
    {
        var transactions = await _context.Transactions
            .Where(t => t.Account.CustomerId == CustomerId).ToListAsync();
        return transactions.Select(t => new TransactionViewResponse { /* Map properties here */ }).ToList();
    }

}
