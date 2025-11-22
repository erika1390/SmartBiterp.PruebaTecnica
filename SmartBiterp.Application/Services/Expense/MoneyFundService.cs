using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Enums;
using SmartBiterp.Domain.Interfaces;

namespace SmartBiterp.Application.Services.Expense
{
    public class MoneyFundService : IMoneyFundService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MoneyFundService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(CreateMoneyFundRequest request)
        {
            var nextCode = await GetNextCodeAsync();

            var entity = new MoneyFund
            {
                Name = request.Name,
                FundType = Enum.Parse<MoneyFundType>(request.FundType, true),
                InitialBalance = request.InitialBalance,
                CurrentBalance = request.InitialBalance,
                Code = nextCode
            };

            await _uow.MoneyFunds.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.MoneyFunds.GetByIdAsync(id);

            if (entity == null)
                throw new Exception($"MoneyFund with ID {id} not found.");

            _uow.MoneyFunds.Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<MoneyFundDto>> GetAllAsync()
        {
            var list = await _uow.MoneyFunds.GetAllAsync();
            return _mapper.Map<IEnumerable<MoneyFundDto>>(list);
        }

        public async Task<MoneyFundDto?> GetByIdAsync(int id)
        {
            var entity = await _uow.MoneyFunds.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<MoneyFundDto>(entity);
        }

        public async Task<string> GetNextCodeAsync()
        {
            return await _uow.MoneyFunds.GetNextCodeAsync();
        }

        public async Task UpdateAsync(UpdateMoneyFundRequest request)
        {
            var entity = await _uow.MoneyFunds.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception($"MoneyFund with ID {request.Id} not found.");

            entity.Name = request.Name;
            entity.FundType = Enum.Parse<MoneyFundType>(request.FundType, true);
            entity.InitialBalance = request.InitialBalance;

            await _uow.SaveChangesAsync();
        }
    }
}
