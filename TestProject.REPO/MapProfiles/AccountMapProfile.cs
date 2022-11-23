using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DAL.Entities;
using TestProject.REPO.Models;

namespace TestProject.REPO.MapProfiles
{
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
