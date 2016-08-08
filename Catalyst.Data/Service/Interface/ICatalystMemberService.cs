using Catalyst.Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Catalyst.Data.Service.Interface
{
    public interface ICatalystMemberService
    {
        

        /// <summary>
        /// Service method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        IList<CatalystMember> GetAll();

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
         IList<CatalystMember> Search(string searchCriteria);

        /// <summary>
        /// Service method to create new member
        /// </summary>
        /// <param name="CatalystMember">club member model</param>
        /// <returns>true or false</returns>
        bool Create(CatalystMember CatalystMember);

           
    }
}
