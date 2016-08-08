using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyst.Data;
using Catalyst.Data.Service.Interface;
using System.Collections.ObjectModel;
using System.Data;
using Catalyst.Data.Service;

namespace Catalyst.Model
{
   public class CatalystMemberBusinessObject
    {

         ObservableCollection<CatalystMember> People { get; set; }
        private ICatalystMemberService catalystMemberService;

        public CatalystMemberBusinessObject()
        {
            catalystMemberService= new CatalystMemberService();
        }

        public ObservableCollection<CatalystMember> GetAll()
        {
            ObservableCollection<CatalystMember> members = new ObservableCollection<Model.CatalystMember>();
            List<Catalyst.Data.Entities.CatalystMember> people = this.catalystMemberService.GetAll().ToList();
            foreach(Catalyst.Data.Entities.CatalystMember member in people)
            {
                CatalystMember obj = new Model.CatalystMember();
                obj.FirstName = member.FirstName;
                obj.LastName = member.LastName;
                obj.Age = member.age;
                obj.Address = member.Address;
                obj.Interests  = member.interests;
                obj.Pic = member.picture;
                members.Add(obj);
            }
             

            return members;
        }

        public bool Create(CatalystMember CatalystMember)
        {
            Catalyst.Data.Entities.CatalystMember obj = new Data.Entities.CatalystMember();
            obj.FirstName = CatalystMember.FirstName;
            obj.LastName = CatalystMember.LastName;
            obj.Address = CatalystMember.Address;
            obj.age = CatalystMember.Age;
            obj.interests = CatalystMember.Interests;
            obj.picture = CatalystMember.Pic;
           
            return this.catalystMemberService.Create(obj); 
        }
        public ObservableCollection<CatalystMember> Search(string searchText)
        {
            ObservableCollection<CatalystMember> members = new ObservableCollection<Model.CatalystMember>();
            List<Catalyst.Data.Entities.CatalystMember> people = this.catalystMemberService.Search(searchText).ToList();
            foreach (Catalyst.Data.Entities.CatalystMember member in people)
            {
                CatalystMember obj = new Model.CatalystMember();
                obj.FirstName = member.FirstName;
                obj.LastName = member.LastName;
                obj.Age = member.age;
                obj.Address = member.Address;
                obj.Interests = member.interests;
                obj.Pic = member.picture;
                members.Add(obj);
            }


            return members;
        }
    }
}
