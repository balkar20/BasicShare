﻿using Core.Base.DataBase.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auh.Entities
{
    public class UserEntity : IdentityUser, IEntity
    {
        public int Year { get; set; }
        public long Id { get; set; }
    }
}