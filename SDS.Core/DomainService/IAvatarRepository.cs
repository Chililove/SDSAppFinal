using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.DomainService
{
    public interface IAvatarRepository
    {
        IEnumerable<Avatar> ReadAllAvatars();
        public List<Avatar> GetAllAvatars();

        Avatar Create(Avatar avatar);

        Avatar GetAvatarById(int Id);

        Avatar Update(Avatar avatarUpdate);

        Avatar Delete(int Id);
    }
}
