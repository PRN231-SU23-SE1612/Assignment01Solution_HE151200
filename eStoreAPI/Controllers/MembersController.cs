﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.DTO;

using Repository;
using BusinessObject;
using Repository.Implements;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        
        private IMemberRepository repository = new MemberRepository();
        public MembersController()
        {
            
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers() 
            => repository.GetMember();

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = repository.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, MemberDTO member)
        {
            Member mem = new Member
            {

                Email = member.Email,
                CompanyName = member.CompanyName,
                City = member.City,
                Country = member.Country,
                Password = member.Password
            };
            var pTmp = repository.GetMemberById(id);
            if (pTmp == null)

                return NotFound();
            pTmp = mem;
            pTmp.MemberId = id;
            repository.UpdateMember(pTmp);
            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(MemberDTO member)
        {
            Member mem=new Member
            {
            
             Email= member.Email,
             CompanyName= member.CompanyName,
             City= member.City,
             Country= member.Country,
             Password= member.Password
            };
          
            repository.SaveMember(mem);

            return NoContent();
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
           
            var member = repository.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            repository.DeleteMember(member);

            return NoContent();
        }

        
    }
}
