using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Entities
{
    public interface IEntity
    {
    }

    public interface IEntityWithId : IEntity
    {
        int Id { get; set; }
    }

    public interface IEntityWithName : IEntity
    {
        string Name { get; set; }
    }
}
