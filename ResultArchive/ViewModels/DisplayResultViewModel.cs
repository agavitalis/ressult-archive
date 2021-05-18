using ResultArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.ViewModels
{
    public class DisplayResultViewModel
    {
        public IEnumerable<Result> Results { get; set; }
        public IEnumerable<School> Schools { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
    }
}
