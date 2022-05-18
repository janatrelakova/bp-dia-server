﻿using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.User
{
    public interface IUserService
    {
        Task<ICollection<UserBasicInfoDTO>> GetUsers();
    }
}
