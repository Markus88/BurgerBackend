﻿using User.Domain.Interface.Model;

namespace User.Domain.Implementation
{
    public class UserModel : IUserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}