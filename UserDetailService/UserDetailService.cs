using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserDetailService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserDetailService" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UserDetailService : IUserDetailService
    {
        private static readonly List<UserDetail> Data = new List<UserDetail>
        {
            new UserDetail{ UserId = "1", FirstName ="Tom", LastName="Cruise",Role="Actor",Location="New York",IsActive=true},
            new UserDetail{ UserId = "2", FirstName ="Chris", LastName="Pratt",Role="Actor",Location="Virginia",IsActive=true},
            new UserDetail{ UserId = "3", FirstName ="Jennifer ", LastName="Aniston",Role="Actress",Location="California",IsActive=true},
            new UserDetail{ UserId = "4", FirstName ="Ross", LastName="Geller",Role="Actor",Location="New York",IsActive=true},
            new UserDetail{ UserId = "5", FirstName ="Rachel", LastName="Green",Role="Actress",Location="New York",IsActive=false}
        };

        private static readonly Dictionary<Guid, IUserDetailServiceCallback> Clients =
            new Dictionary<Guid, IUserDetailServiceCallback>();

        public void Create(UserDetail model)
        {
            Data.Add(model);

            lock (Clients)
            {
                //changes to notify all subscribed clients
                foreach (var client in Clients)
                {
                    try
                    {
                        client.Value.Notify(model);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }


        public List<UserDetail> GetAllUsers()
        {
            IUserDetailServiceCallback callback =
                OperationContext.Current.GetCallbackChannel<IUserDetailServiceCallback>();
            var clientId = Guid.NewGuid();
            if (callback != null)
            {
                lock (Clients)
                {
                    //adding clients
                    Clients.Add(clientId, callback);
                }
            }
            return Data;
        }
    }
}
