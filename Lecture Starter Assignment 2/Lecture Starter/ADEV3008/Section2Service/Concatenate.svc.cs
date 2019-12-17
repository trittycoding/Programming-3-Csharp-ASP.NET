using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Section2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Concatenate" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Concatenate.svc or Concatenate.svc.cs at the Solution Explorer and start debugging.
    public class Concatenate : IConcatenate
    {
        public void DoWork()
        {
        }

        /// <summary>
        /// return concatenated name and address
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="address">string address</param>
        /// <returns>concatenated name and address</returns>
        public string NameAddress(string name, string address)
        {
            return String.Format("{0}, {1}", name, address);
        }
    }
}
