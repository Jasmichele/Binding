using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingLab
{
   public class Emp
    {
        string EmpId;
        string EmpName;
        string Addr;
        string City;
        string State;

        public Emp()
        {

        }
        public Emp(string id, string name, string add, string city, string state)
        {
            EmpId = id;
            EmpName = name;
            Addr = add;
            City = city;
            State = state;
        }
        public string EmpId1
        {
            get
            {
                return EmpId;
            }

            set
            {
                EmpId = value;
            }
        }

        public string EmpName1
        {
            get
            {
                return EmpName;
            }

            set
            {
                EmpName = value;
            }
        }

        public string Addr1
        {
            get
            {
                return Addr;
            }

            set
            {
                Addr = value;
            }
        }

        public string City1
        {
            get
            {
                return City;
            }

            set
            {
                City = value;
            }
        }

        public string State1
        {
            get
            {
                return State;
            }

            set
            {
                State = value;
            }
        }
    }
}
