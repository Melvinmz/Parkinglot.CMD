using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkinglot.CMD.Model
{
    internal class ParkingSpace
    {
        public int Id { get; set; }
        public string? CarNumber { get; set; }
        public string? Color { get; set; }
        public bool Occupied { get; set; }

    }
}
