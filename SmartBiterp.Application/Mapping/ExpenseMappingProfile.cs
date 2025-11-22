using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Application.Mapping
{
    public class ExpenseMappingProfile : Profile
    {
        public ExpenseMappingProfile()
        {
            CreateMap<ExpenseType, ExpenseTypeDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.ToString()));

            CreateMap<MoneyFund, MoneyFundDto>()
                .ForMember(d => d.FundType, opt => opt.MapFrom(s => s.FundType.ToString()));

            CreateMap<Budget, BudgetDto>()
                .ForMember(d => d.ExpenseTypeName, opt => opt.MapFrom(s => s.ExpenseType.Description))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

            CreateMap<ExpenseHeader, ExpenseHeaderDto>()
                .ForMember(d => d.MoneyFundName, opt => opt.MapFrom(s => s.MoneyFund.Name));

            CreateMap<ExpenseDetail, ExpenseDetailDto>()
                .ForMember(d => d.ExpenseTypeName, opt => opt.MapFrom(s => s.ExpenseType.Description));

            CreateMap<Deposit, DepositDto>()
                .ForMember(d => d.MoneyFundName, opt => opt.MapFrom(s => s.MoneyFund.Name));
        }
    }
}
