using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Enums;
using SmartBiterp.Domain.Interfaces;

namespace SmartBiterp.Application.Services.Expense
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateExpenseTypeRequest request)
        {
            var nextCode = await _uow.ExpenseTypes.GetNextCodeAsync();

            if (!Enum.TryParse<ExpenseCategoryType>(request.Category, true, out var category))
                throw new ArgumentException($"Category '{request.Category}' is not valid.");

            var entity = new ExpenseType
            {
                Description = request.Description,
                Category = category,
                Code = nextCode
            };

            await _uow.ExpenseTypes.AddAsync(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.ExpenseTypes.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Expense type not found.");

            _uow.ExpenseTypes.Remove(entity);

            await _uow.SaveChangesAsync();
        }


        public async Task<IEnumerable<ExpenseTypeDto>> GetAllAsync()
        {
            var list = await _uow.ExpenseTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<ExpenseTypeDto>>(list);
        }

        public async Task<ExpenseTypeDto?> GetByIdAsync(int id)
        {
            var entity = await _uow.ExpenseTypes.GetByIdAsync(id);

            if (entity == null)
                return null;

            return _mapper.Map<ExpenseTypeDto>(entity);
        }

        public async Task<string> GetNextCodeAsync()
        {
            return await _uow.ExpenseTypes.GetNextCodeAsync();
        }

        public async Task UpdateAsync(UpdateExpenseTypeRequest request)
        {
            var entity = await _uow.ExpenseTypes.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Expense type not found.");

            entity.Description = request.Description;
            entity.Category = Enum.Parse<ExpenseCategoryType>(request.Category);

            await _uow.SaveChangesAsync();
        }
    }

}
