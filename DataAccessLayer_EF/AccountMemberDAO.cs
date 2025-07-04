using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace DataAccessLayer_EF
{
    public class AccountMemberDAO
    {
        MyStoreContext context = new MyStoreContext();
        public AccountMember Login(string email, string pwd)
        {
            return context.AccountMembers
                .FirstOrDefault(m => m.EmailAddress == email 
                                        && m.MemberPassword == pwd);
        }
    }
}
