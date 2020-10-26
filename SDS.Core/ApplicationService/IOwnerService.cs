using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.ApplicationService
{
    public interface IOwnerService
    {

        public List<Owner> GetOwners();

        Owner FindOwnerByAvatar(Owner owner);
        Owner FindOwnerById(int id);
        Owner CreateOwner(Owner owner);
        Owner DeleteOwner(int id);
        Owner UpdateOwner(Owner owner);
        public List<Owner> SearchOwner(string st);

    }
}
