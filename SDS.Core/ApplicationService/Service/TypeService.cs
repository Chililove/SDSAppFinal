using Core.Entity;
using SDS.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.ApplicationService.Service
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        public static IEnumerable<AvatarType> typeList;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }


        // Not sure about the naming of name, its called NameType in AvatarType entity?

        public AvatarType CreateType(AvatarType avatarType)
        {
            if (avatarType.TypeOfAvatar == null)
            {
                throw new System.IO.InvalidDataException("You need to put in atleast 1 letter!");
            }
            return _typeRepository.CreateType(avatarType);
        }

        public AvatarType DeleteType(int id)
        {
            if (id < 1)
            {

                throw new System.IO.InvalidDataException("Id must be atleast 1");
            }
            return _typeRepository.DeleteType(id);
        }

        public List<AvatarType> GetTypes()
        {
            return _typeRepository.GetAllTypes();
        }

        public AvatarType ReadTypeById(int id)
        {
            return _typeRepository.GetTypeById(id);
        }

        public AvatarType Update(AvatarType avatarType)
        {
            if (avatarType.TypeOfAvatar.Length < 1)
            {
                throw new System.IO.InvalidDataException("Name must be atleast 1 char");
            }

            if (avatarType == null)
            {
                throw new System.IO.InvalidDataException("Did not find owner with id: " + avatarType.Id);
            }
            return _typeRepository.UpdateType(avatarType);
        }

        public AvatarType UpdateAvatarType(AvatarType avatarType)
        {
            var DBType = ReadTypeById(avatarType.Id);
            if (DBType != null)
            {
                DBType.TypeOfAvatar = avatarType.TypeOfAvatar;

            }

            return DBType;
        }
        /* public AvatarType UpdateType(AvatarType typeToUpdate)
         {
             var DBType = ReadTypeById(typeToUpdate.Id);
             if (DBType != null)
             {
                 DBType.TypeOfAvatar = typeToUpdate.TypeOfAvatar;

                 if (typeToUpdate.TypeOfAvatar.Length < 1)
                 {
                     throw new InvalidDataException("Name must be atleast 1 char");
                 }

                 if (typeToUpdate == null)
                 {
                     throw new InvalidDataException("Did not find avatar with id: " + typeToUpdate.Id);
                 }
                 return _typeRepository.UpdateType(typeToUpdate);
             }
             return DBType;
         }     */

    }
}
