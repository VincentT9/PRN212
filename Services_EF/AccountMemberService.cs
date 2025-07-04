using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using Repositories_EF;

namespace Services_EF
{
    public class AccountMemberService : IAccountMemberService
    {
        IAccountMemberRepository _accountMemberRepository;
        public AccountMemberService()
        {
            _accountMemberRepository = new AccountMemberRepository();
        }
        public AccountMember Login(string email, string pwd)
        {
            return _accountMemberRepository.Login(email, pwd);
        }
    }
}
