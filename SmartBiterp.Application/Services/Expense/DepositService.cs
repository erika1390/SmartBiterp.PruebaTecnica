using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Interfaces;
using SmartBiterp.Shared.Common.Responses;

namespace SmartBiterp.Application.Services.Expense
{
    public class DepositService : IDepositService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DepositService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ApiResponse<int>> CreateAsync(CreateDepositRequest request)
        {
            if (request.Amount <= 0)
                return ApiResponse<int>.Fail("El monto del depósito debe ser mayor a cero.");

            var entity = new Deposit
            {
                Date = request.Date,
                MoneyFundId = request.MoneyFundId,
                Amount = request.Amount
            };

            await _uow.Deposits.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return ApiResponse<int>.Ok(entity.Id, "Depósito registrado correctamente.");
        }

        public async Task<ApiResponse<IEnumerable<DepositDto>>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var deposits = await _uow.Deposits.GetByDateRangeAsync(start, end);

            var dto = deposits.Select(d => new DepositDto
            {
                Id = d.Id,
                Date = d.Date,
                MoneyFundId = d.MoneyFundId,
                MoneyFundName = d.MoneyFund?.Name ?? "",
                Amount = d.Amount
            });

            return ApiResponse<IEnumerable<DepositDto>>.Ok(dto);
        }
    }
}
