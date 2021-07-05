using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserDetailService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserDetailService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IUserDetailServiceCallback))]
    public interface IUserDetailService
    {
        [OperationContract]
        List<UserDetail> GetAllUsers();

        [OperationContract]
        void Create(UserDetail model);
    }

    public interface IUserDetailServiceCallback
    {
        [OperationContract]
        void Notify(UserDetail model);
    }
}
