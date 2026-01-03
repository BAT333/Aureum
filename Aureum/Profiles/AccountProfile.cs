using Aureum.DTOs;
using Aureum.Models;
using AutoMapper;

namespace Aureum.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDTO, Account>();
            CreateMap<UpdateAccountDTO, Account>();
            CreateMap<Account, ReadAccountDTO>();
        }
    }
}
