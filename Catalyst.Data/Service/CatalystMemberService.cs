using Catalyst.Data.Context;
using Catalyst.Data.Entities;
using Catalyst.Data.Extension;
using Catalyst.Data.Service.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Catalyst.Data.Service
{
   

    public class CatalystMemberService : ICatalystMemberService
    {
        private CatalystDbContext _context;

        public CatalystMemberService()
        {
            _context = new Context.CatalystDbContext();
        }

        public CatalystMemberService(CatalystDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Service method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        public IList<CatalystMember> GetAll()
        {
            //using (var context = new CatalystDbContext())
            //{
                IList<CatalystMember> members = _context.DbEntities.ToList();

                return members;
           // }
        }

        /// <summary>
        /// Service method to search records by multiple parameters
        ///// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        public IList<CatalystMember> Search(string searchCriteria)
        {
            //using (var context = new CatalystDbContext())
            //{
                IList < CatalystMember > members = (from i in _context.DbEntities
                                                    where (i.FirstName.Contains(searchCriteria) || i.LastName.Contains(searchCriteria))
                                               select i).ToList();
                    


             
                return members;
            //}
        }

        /// <summary>
        /// Service method to create new member
        /// </summary>
        /// <param name="CatalystMember">club member model</param>
        /// <returns>true or false</returns>
        public bool Create(CatalystMember CatalystMember)
        {
            //using (var context = new CatalystDbContext())
            //{
            _context.DbEntities.Add(CatalystMember);
                return _context.SaveChanges() > 0;
            //}
        }

      
    }
}
