using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkinglot.CMD.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ParkingTestPriorityAttribute : Attribute
    {
           public int Priority { get; private set; }

            public ParkingTestPriorityAttribute(int priority) => Priority = priority;
       
    }
}
