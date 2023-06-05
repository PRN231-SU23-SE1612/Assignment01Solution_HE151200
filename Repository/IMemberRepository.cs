using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMemberRepository
    {
        void SaveMember(Member c);
        Member GetMemberById(int id);
        void DeleteMember(Member p);
        void UpdateMember(Member p);
        List<Member> GetMember();
    }
}
