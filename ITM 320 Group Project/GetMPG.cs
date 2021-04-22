using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace ITM_320_Group_Project
{
    public class GetMPG
    {
        public double AvgMPG()
        {
            int mpg = 0;
            int i;

            VehicleList V = new VehicleList();
            V.Open();
            for (i = 0; i < V.Count(); i++)
            {
                mpg += V.Get(i).mpg;
            }

            return Convert.ToDouble(mpg) / i;
        }
    }
}
