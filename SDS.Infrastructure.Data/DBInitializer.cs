using Core.Entity;
using SDS.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;


namespace SDS.Infrastructure.Data
{
    public class DBInitializer: IDBInitializer
    {
       

        public DBInitializer() 
        {

        }

        public void InitData(Context ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner1 = ctx.Owners.Add(new Owner
            {

                FirstName = "Peter",
                LastName = "Pan",
                Address = "Mælkevejen",
                PhoneNumber = "20252414",
                Email = "LostBoy@putmail.com"

            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner
            {
                FirstName = "Lotte",
                LastName = "Pedersen",
                Address = "IpCom",
                PhoneNumber = "24582414",
                Email = "Lotte@gmail.com"

            }).Entity;

            var owner3 = ctx.Owners.Add(new Owner
            {
                FirstName = "Bradley",
                LastName = "Swords",
                Address = "Sao",
                PhoneNumber = "12454525",
                Email = "LostBoy@sao.com"

            }).Entity;

            var owner4 = ctx.Owners.Add(new Owner
            {
                FirstName = "Chili",
                LastName = "Love",
                Address = "LaLaLand",
                PhoneNumber = "15865525",
                Email = "FoundBoy@sins.com"

            }).Entity;

            Random r = new Random();
            var avatar1 = ctx.Avatars.Add(new Avatar
            {
                Name = "Bradley",
                AvatarType = "Wrath",
                Birthday = DateTime.Now.Date,
                SoldDate = DateTime.Now.Date,
                Color = "black",
                PreviousOwner = "Chili",
                Price = 900,
                Owner = owner4
            }).Entity;

            var avatar2 = ctx.Avatars.Add(new Avatar
            {
                Name = "Chili",
                AvatarType = "Goddess",
                Birthday = DateTime.Now.AddYears(-1 * r.Next(1, 100)),
                SoldDate = DateTime.Now.Date.AddYears(-5),
                Color = "Pink",
                PreviousOwner = "Bradley",
                Price = 800,
                Owner = owner3
            }).Entity;

            var avatar3 = ctx.Avatars.Add(new Avatar
            {
                Name = "Bunsy",
                AvatarType = "Sloth",
                Birthday = DateTime.Now.AddYears(-1 * r.Next(1, 100)),
                SoldDate = DateTime.Now.Date.AddYears(-5),
                Color = "Blue",
                PreviousOwner = "Chili",
                Price = 600,
                Owner = owner1
            }).Entity;

            var avatar4 = ctx.Avatars.Add(new Avatar
            {
                Name = "Meliodas",
                AvatarType = "Wrath",
                Birthday = DateTime.Now.AddYears(-1 * r.Next(1, 100)),
                SoldDate = DateTime.Now.Date.AddYears(-5),
                Color = "Dark Purple",
                PreviousOwner = "Chili",
                Price = 400,
                Owner = owner2
            }).Entity;
            var avatar5 = ctx.Avatars.Add(new Avatar
            {
                Name = "Melon",
                AvatarType = "Greed",
                Birthday = DateTime.Now.AddYears(-1 * r.Next(1, 100)),
                SoldDate = DateTime.Now.Date.AddYears(-5),
                Color = "Sand",
                PreviousOwner = "Bradley",
                Price = 400,
                Owner = owner4
            }).Entity; 

            var avatar6 = ctx.Avatars.Add(new Avatar
            {
                Name = "Ban",
                AvatarType = "Greed",
                Birthday = DateTime.Now.AddYears(-1 * r.Next(1, 100)),
                SoldDate = DateTime.Now.Date.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Lotte",
                Price = 400,
                Owner = owner4
            }).Entity;
            var avatar7 = ctx.Avatars.Add(new Avatar
            {
                Name = "Diane",
                AvatarType = "Envy",
                Birthday = DateTime.Now.AddYears(-1 * r.Next(1, 100)),
                SoldDate = DateTime.Now.Date.AddYears(-5),
                Color = "Orange",
                PreviousOwner = "Peter",
                Price = 400,
                Owner = owner1
            }).Entity;

            owner4.AvatarsOwned.Add(avatar1);
            owner4.AvatarsOwned.Add(avatar5);
            owner4.AvatarsOwned.Add(avatar6);
            // Id keeps incrementing through lists. avatartypes get id's like 13 and 15..

            var typeOfAvatar1 = ctx.AvatarTypes.Add(new AvatarType
            {
                TypeOfAvatar = "Swordsman",
            }).Entity;


            var typeOfAvatar2 = ctx.AvatarTypes.Add(new AvatarType
            {
                TypeOfAvatar = "Wrath"


            }).Entity;
            var typeOfAvatar3 = ctx.AvatarTypes.Add(new AvatarType
            {
                TypeOfAvatar = "Greed"


            }).Entity;
            var typeOfAvatar4 = ctx.AvatarTypes.Add(new AvatarType
            {
                TypeOfAvatar = "Envy"


            }).Entity;
            var typeOfAvatar5 = ctx.AvatarTypes.Add(new AvatarType
            {
                TypeOfAvatar = "Sloth"


            }).Entity;
            var typeOfAvatar6 = ctx.AvatarTypes.Add(new AvatarType
            {
                TypeOfAvatar = "Goddess"

            }).Entity;

            ctx.SaveChanges();
        }
        
    }
}
