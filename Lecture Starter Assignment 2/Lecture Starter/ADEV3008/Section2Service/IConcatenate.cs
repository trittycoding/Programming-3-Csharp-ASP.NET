using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Section2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConcatenate" in both code and config file together.
    [ServiceContract]
    public interface IConcatenate
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// returns concatenated name and address
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="address">string address</param>
        /// <returns>concatenated name and address</returns>
        [OperationContract]
        string NameAddress(string name, string address);

    }
}
