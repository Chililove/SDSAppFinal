using Core.Entity;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDS.Infrastructure.Data.Repositories
{
    public class AvatarRepo : IAvatarRepository

    {
        readonly Context _ctx;
        public static int AvatarId = 1;

        private static List<Avatar> _avatarList = new List<Avatar>();

        public AvatarRepo(Context ctx) {
            _ctx = ctx;
        }
        public Avatar Create(Avatar avatar)
        {
            // MAYBE THIS ONE???
            /* avatar.Id = AvatarId++;

             _avatarList.Add(avatar);
             return avatar;*/
            Avatar ava = _ctx.Avatars.Add(avatar).Entity;
            _ctx.SaveChanges();
            return ava;

        }

        public Avatar GetAvatarById(int id)
        {

            /*  var avatar = _avatarList.Find(x => x.Id == id);
              return avatar;*/
            return _ctx.Avatars.FirstOrDefault(ava => ava.Id == id);
        }

        public List<Avatar> GetAllAvatars()
        {

            
            return _ctx.Avatars.Include(o => o.Owner).ToList();
        }

        public IEnumerable<Avatar> ReadAllAvatars()
        {
            return _avatarList;
        }

        public Avatar Update(Avatar avatarUpdate)
        {
            var avatar = GetAvatarById(avatarUpdate.Id);
            if (avatar != null)
            {
                avatar.Name = avatarUpdate.Name;
                avatar.AvatarType = avatarUpdate.AvatarType;
                avatar.Birthday = avatarUpdate.Birthday;
                avatar.SoldDate = avatarUpdate.SoldDate;
                avatar.Color = avatarUpdate.Color;
                avatar.PreviousOwner = avatarUpdate.PreviousOwner;
                avatar.Price = avatarUpdate.Price;
                return avatar;
            }
            return null;
        }

        public Avatar Delete(int id)
        {
            Avatar a = GetAllAvatars().Find(x => x.Id == id);
            GetAllAvatars().Remove(a);
            if (a != null)
            {
                return a;
            }
            return null;
        }
    }
}
