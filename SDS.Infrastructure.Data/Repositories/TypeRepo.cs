using Core.Entity;
using SDS.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDS.Infrastructure.Data.Repositories
{
    public class TypeRepo : ITypeRepository
    {
        readonly Context _ctx;
        public static int AvatarTypeId = 1;

        private static List<AvatarType> _typeList = new List<AvatarType>();


        public TypeRepo(Context ctx) {
            _ctx = ctx;

        }
        public AvatarType CreateType(AvatarType avatarType)
        {
            /* avatarType.Id = AvatarTypeId++;

             _typeList.Add(avatarType);
             return avatarType;*/
            AvatarType type = _ctx.AvatarTypes.Add(avatarType).Entity;
            _ctx.SaveChanges();
            return type;
        }

        public AvatarType DeleteType(int id)
        {
            AvatarType atype = GetAllTypes().Find(x => x.Id == id);
            GetAllTypes().Remove(atype);
            if (atype != null)
            {
                return atype;
            }
            return null;
        }

        public List<AvatarType> GetAllTypes()
        {
          
            return _typeList;
        }

        public AvatarType GetTypeById(int id)
        {
            /* var avatarType = _typeList.Find(x => x.Id == id);
             return avatarType;*/
            return _ctx.AvatarTypes.FirstOrDefault(atype => atype.Id == id);

        }

        public IEnumerable<AvatarType> ReadAllTypes()
        {
            return _typeList;
        }

        public AvatarType UpdateType(AvatarType typeUpdate)
        {
            var avatarType = GetTypeById(typeUpdate.Id);
            if (avatarType != null)
            {
                avatarType.TypeOfAvatar = typeUpdate.TypeOfAvatar;

                return avatarType;
            }
            return null;
        }
    }
}
