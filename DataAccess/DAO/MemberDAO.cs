using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        public static List<Member> GetMember()
        {
            var listMember = new List<Member>();

            try
            {

                using (var context = new PRN231_AS1Context())
                {
                    Console.WriteLine("check");
                    listMember = context.Members.ToList();

                    Console.WriteLine("end check");
                    foreach (var mem in listMember)
                    {
                        Console.WriteLine(mem);
                    }
                    Console.WriteLine(listMember.Count());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listMember;

        }
        public static Member FindMemberById(int MemberId)
        {
            Member p = new Member();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    p = context.Members.SingleOrDefault(x => x.MemberId == MemberId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }
        public static void SaveMember(Member p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Members.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateMember(Member p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Members.Update(p);
                    // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteMember(Member p)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    var p1 = context.Members.SingleOrDefault(x => x.MemberId == p.MemberId);
                    context.Members.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
