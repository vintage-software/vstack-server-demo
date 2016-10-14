﻿using Domain;
using Services.Persistence;
using Vstack.Services.Mappers;

namespace Services.Mappers
{
    public class AccountMapper : BaseEfMapper<DbContext, Account>
    {
        public AccountMapper()
            : base(new DbContext())
        {
        }
    }
}