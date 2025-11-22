using AutoMapper;

using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Application.Mapping
{
    public class ExpenseMappingProfile : Profile
    {
        public ExpenseMappingProfile()
        {
            CreateMap<ExpenseType, ExpenseTypeDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.ToString()));

            CreateMap<CreateExpenseTypeRequest, ExpenseType>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => Enum.Parse<ExpenseCategoryType>(s.Category, true)));

            CreateMap<UpdateExpenseTypeRequest, ExpenseType>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => Enum.Parse<ExpenseCategoryType>(s.Category, true)));

            CreateMap<MoneyFund, MoneyFundDto>()
               .ForMember(d => d.FundType, opt => opt.MapFrom(s => s.FundType.ToString()));

            CreateMap<CreateMoneyFundRequest, MoneyFund>()
                .ForMember(d => d.FundType, opt => opt.MapFrom(s => Enum.Parse<MoneyFundType>(s.FundType, true)))
                .ForMember(d => d.CurrentBalance, opt => opt.MapFrom(s => s.InitialBalance));

            CreateMap<UpdateMoneyFundRequest, MoneyFund>()
                .ForMember(d => d.FundType, opt => opt.MapFrom(s => Enum.Parse<MoneyFundType>(s.FundType, true)));

            CreateMap<Budget, BudgetDto>()
                .ForMember(d => d.ExpenseTypeName, opt => opt.MapFrom(s => s.ExpenseType.Description))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

            CreateMap<CreateBudgetRequest, Budget>();

            CreateMap<UpdateBudgetRequest, Budget>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status));
            CreateMap<ExpenseHeader, ExpenseHeaderDto>()
                .ForMember(d => d.MoneyFundName, opt => opt.MapFrom(s => s.MoneyFund.Name));

            CreateMap<CreateExpenseHeaderRequest, ExpenseHeader>()
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Date));

            CreateMap<UpdateExpenseHeaderRequest, ExpenseHeader>();

            CreateMap<ExpenseDetail, ExpenseDetailDto>()
               .ForMember(d => d.ExpenseTypeName, opt => opt.MapFrom(s => s.ExpenseType.Description));

            CreateMap<CreateExpenseDetailRequest, ExpenseDetail>();

            CreateMap<Deposit, DepositDto>()
                .ForMember(d => d.MoneyFundName, opt => opt.MapFrom(s => s.MoneyFund.Name));

            CreateMap<CreateDepositRequest, Deposit>();
        }
    }
}
