using System.Collections.Generic;

namespace Module.Training.Data
{

    public class TotalMarkUpdateRequest
    {
        public long BatchSchedule { get; set; }
        public IEnumerable<TotalMarkListViewModel> Marks { get; set; }

    }

}
