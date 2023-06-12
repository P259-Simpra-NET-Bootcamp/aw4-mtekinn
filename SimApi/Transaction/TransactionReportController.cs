using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Operation;
using SimApi.Schema;

namespace SimApi.Service;

[EnableMiddlewareLogger]
[ResponseGuid]
[Route("simapi/v1/[controller]")]
[ApiController]
public class TransactionReportController : ControllerBase
{
    private readonly ITransactionReportService transactionService;
    public TransactionReportController(ITransactionReportService transactionService)
    {
        this.transactionService = transactionService;
    }

    [HttpGet]
    public Task<List<TransactionViewResponse>> GetAll()
    {
        var transactions = transactionService.GetAll();
        return transactions;
    }

    [HttpGet("{id}")]
    public Task<TransactionViewResponse> GetById([FromRoute] int id)
    {
        var transaction = transactionService.GetById(id);
        return transaction;
    }

    [HttpGet("ByReferenceNumber/{ReferenceNumber}")]
    public Task<List<TransactionViewResponse>> GetByReferenceNumber([FromRoute] string ReferenceNumber)
    {
        var transactions = transactionService.GetByReferenceNumber(ReferenceNumber);
        return transactions;
    }

    [HttpGet("ByAccountId/{AccountId}")]
    public Task<List<TransactionViewResponse>> GetByAccountId([FromRoute] int AccountId)
    {
        var transactions = transactionService.GetByAccountId(AccountId);
        return transactions;
    }

    [HttpGet("ByCustomerId/{CustomerId}")]
    public Task<List<TransactionViewResponse>> GetByCustomerId([FromRoute] int CustomerId)
    {
        var transactions = transactionService.GetByCustomerId(CustomerId);
        return transactions;
    }
}
