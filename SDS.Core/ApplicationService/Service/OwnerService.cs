using Core.Entity;
using SDS.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.ApplicationService.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        public static IEnumerable<Owner> ownerList;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }



        public Owner CreateOwner(Owner owner)
        {
            if (owner.FirstName.Length < 1 || owner.LastName.Length < 1)
            {
                throw new System.IO.InvalidDataException("You need to put in atleast 1 letter!");
            }
            return _ownerRepository.CreateOwner(owner);
        }

        public Owner Update(Owner owner)
        {
            if (owner.FirstName.Length < 1 || owner.LastName.Length < 1)
            {
                throw new System.IO.InvalidDataException("Name must be atleast 1 char");
            }

            if (owner == null)
            {
                throw new System.IO.InvalidDataException("Did not find owner with id: " + owner.Id);
            }
            return _ownerRepository.UpdateOwner(owner);


        }
        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var DBOwner = FindOwnerById(ownerUpdate.Id);
            if (DBOwner != null)
            {
                DBOwner.FirstName = ownerUpdate.FirstName;
                DBOwner.LastName = ownerUpdate.LastName;
                DBOwner.Address = ownerUpdate.Address;
                DBOwner.PhoneNumber = ownerUpdate.PhoneNumber;
                DBOwner.Email = ownerUpdate.Email;

            }

            return DBOwner;
        }

        public Owner DeleteOwner(int id)
        {
            if (id < 1)
            {

                throw new System.IO.InvalidDataException("Id must be atleast 1");
            }
            return _ownerRepository.DeleteOwner(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.GetAllOwners();
            // return (List<Owner>)_ownerRepository.ReadAllOwners();
        }

        /// I Dont get this one.

        public Owner FindOwnerByAvatar(Owner owner)
        {
            return _ownerRepository.GetOwnerByAvatar(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }



        public List<Owner> SearchOwner(string st)
        {
            List<Owner> results = GetOwners();
            // List<Owner> 
            foreach (Owner owner in _ownerRepository.ReadAllOwners())
            {
                if (owner.FirstName.Contains(st))
                {
                    results.Add(owner);
                }
            }
            return results;
        }
    }
}
