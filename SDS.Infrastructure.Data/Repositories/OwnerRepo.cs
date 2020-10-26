using Core.Entity;
using Microsoft.EntityFrameworkCore;
using SDS.Core.ApplicationService.Service;
using SDS.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDS.Infrastructure.Data.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {
        readonly Context _ctx;
        public static int OwnerId = 1;
        private static List<Owner> _ownerList = new List<Owner>();

        public OwnerRepo(Context ctx){
            _ctx = ctx;
        }
        public Owner CreateOwner(Owner owner)
        {
            /*  PreviousOwner.Id = OwnerId++;
              _ownerList.Add(PreviousOwner);
              return PreviousOwner;*/
            Owner own = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return own;
        }


        public Owner DeleteOwner(int id)
        {
            Owner o = GetAllOwners().Find(x => x.Id == id);
            GetAllOwners().Remove(o);
            if (o != null)
            {
                return o;
            }
            return null;
        }



        public Owner GetOwnerById(int id)
        {
            /*
             var Owner = _ownerList.Find(x => x.Id == id);
             return PreviousOwner;*/
            return _ctx.Owners.FirstOrDefault(own => own.Id == id); 
        }

        Owner IOwnerRepository.ReadByIncludingAvatars(int id) {
                return _ctx.Owners.Include(o => o.AvatarsOwned).FirstOrDefault(own => own.Id == id);
        }

        public List<Owner> GetAllOwners()
        {
           
            return _ctx.Owners.Include(o => o.AvatarsOwned).ToList();
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ctx.Owners;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var avatarDB = GetOwnerById(ownerUpdate.Id);
            if (avatarDB != null)
            {

                avatarDB.FirstName = ownerUpdate.FirstName;
                avatarDB.LastName = ownerUpdate.LastName;
                avatarDB.Address = ownerUpdate.Address;
                avatarDB.PhoneNumber = ownerUpdate.PhoneNumber;
                avatarDB.Email = ownerUpdate.Email;
                return avatarDB;
            }
            return null;
        }
        // How to connect the two lists by names?
        public Owner GetOwnerByAvatar(Owner Owner)
        {
            var names = new HashSet<string>(AvatarService.avatarList.Select(p => p.Name));
            var products = _ownerList.Where(p => names.Contains(p.FirstName))
                                       .ToList();
            return Owner;
        }

    }
}
