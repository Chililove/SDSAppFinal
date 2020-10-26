using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.ApplicationService
{
    public interface ITypeService
    {

        public List<AvatarType> GetTypes();

        AvatarType CreateType(AvatarType AvatarType);

        AvatarType UpdateAvatarType(AvatarType avatarType);

        AvatarType DeleteType(int id);

        AvatarType ReadTypeById(int id);

    }
}

