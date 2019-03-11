using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Data.Repositories
{
    public interface ITrackCreateAndUpdate
    {
        DateTime? CreatedAt { get; set; }

        DateTime? LastUpdatedAt { get; set; }
    }
}
