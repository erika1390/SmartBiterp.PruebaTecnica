using AutoMapper;

using Microsoft.Extensions.Logging;

using SmartBiterp.Application.DTOs.Security;
using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Domain.Entities.Security;
using SmartBiterp.Domain.Interfaces.Security;

namespace SmartBiterp.Application.Services.Security
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        private readonly ILogger<MenuService> _logger;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository repository, ILogger<MenuService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDto>> GetAllAsync()
        {
            var menus = await _repository.GetAllAsync();

            foreach (var menu in menus)
                menu.Children = new List<Menu>();
            var lookup = menus.ToDictionary(m => m.Id);

            foreach (var menu in menus)
            {
                if (menu.ParentId.HasValue &&
                    lookup.TryGetValue(menu.ParentId.Value, out var parent))
                {
                    parent.Children.Add(menu);
                }
            }
            var rootMenus = menus
                .Where(m => m.ParentId == null)
                .ToList();

            return _mapper.Map<IEnumerable<MenuDto>>(rootMenus);
        }

        public async Task<MenuDto?> GetByIdAsync(int id)
        {
            var menu = await _repository.GetByIdAsync(id);
            return _mapper.Map<MenuDto?>(menu);
        }

        public async Task<MenuDto> CreateAsync(MenuDto dto)
        {
            var entity = _mapper.Map<Menu>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<MenuDto>(entity);
        }
    }
}