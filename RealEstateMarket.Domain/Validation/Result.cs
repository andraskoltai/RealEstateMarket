using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Validation
{
    public class Result
    {
        public bool IsSuccesful => Errors.Count == 0;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
