using System;
using System.Collections.Generic;
using System.Linq;
using Racing_team_management.Models;
using System.Threading.Tasks;

namespace Racing_team_management.Repositories.ComponentsRepository
{
    public interface IComponentRepository
    {
        List<Component> GetAll();
        Component Get(int Id);
        Component Create(Component Component);
        Component Update(Component Component);
        Component Delete(Component Component);
    }
}
