using Microsoft.EntityFrameworkCore;

using SAQ.Domain.Entities;
using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;

using System.Linq.Dynamic.Core;

namespace SAQ.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly SAQContext _context;
        public MenuRepository(SAQContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetMenuByPermissons(IEnumerable<int> lista)
        {
            try
            {
                var menuList = new List<Menu>();

                menuList = await _context
                    .Menus.Include(m => m.PermissionMenus)
                    .Where(m => m.PermissionMenus.Any<PermissonMenu>(pr => lista.Contains(pr.PermissonId)))
                    .Select(m => new Menu
                    {
                        MenuId = m.MenuId,
                        Icon = m.Icon,
                        Url = m.Url,
                        Title = m.Title,
                        Parent = m.Parent,
                        Status = m.Status,
                        Order = m.Order
                    })
                    .OrderBy(m => m.Parent)// Ordenar primero los elementos con Parent
                    .ThenBy(m => m.Order)
                    .ToListAsync();

                return menuList;
            }
            catch
            {
                throw;
            }

        }

    }
}
