using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadAllOwners();

        public List<Owner> GetAllOwners();
        Owner CreateOwner(Owner owner);
        Owner GetOwnerById(int id);

        Owner GetOwnerByAvatar(Owner owner);
        Owner UpdateOwner(Owner ownerUpdate);

        Owner DeleteOwner(int id);
        Owner ReadByIncludingAvatars(int id);
    }
}
