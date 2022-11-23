using TestProject.DAL;
using TestProject.REPO.Models;
using AutoMapper;
using TestProject.DAL.Entities;
using System.Collections.Generic;
using TestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TestProject.REPO
{
    public class RepoHelper
    {
        private readonly TProjDBContext _dbContext;
        private readonly IMapper _mapper;
        public RepoHelper(TProjDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }
        public IEnumerable<AccountDto> GetAccounts()
        {
            return _mapper.Map<List<Account>, List<AccountDto>>(_dbContext.Accounts.ToList());
        }
        public bool IsAccountExist(string accountName)
        {
            return _dbContext.Accounts.Any(i => i.Name.ToLower().Equals(accountName.ToLower()));
        }
        public void CreateAccount(AccountDto accountDto)
        {
            try
            {
                if(IsAccountExist(accountDto.Name))
                {
                    throw new Exception("Account already exist");
                }
                var account = new Account
                {
                    Name = accountDto.Name,
                    Contacts = new List<Contact>()
                    {
                        new Contact
                        {
                            FirstName = accountDto.FirstName,
                            LastName = accountDto.LastName,
                            Email = accountDto.Email
                        }
                    }
                };
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void IncidentWork(IncidentDto incidentDto)
        {
            var account = _dbContext.Accounts.Include(a => a.Contacts).Include(a => a.Incidents)
                .First(i => i.Name.ToLower().Equals(incidentDto.AccountName.ToLower()));
            var contDb = account.Contacts.FirstOrDefault(i => i.Email.ToLower()
                .Equals(incidentDto.Email.ToLower()));
          
            if (contDb == default)
            {
                contDb = new Contact();
                _dbContext.Contacts.Add(contDb);
            }
            contDb.FirstName = incidentDto.FirstName;
            contDb.LastName = incidentDto.LastName;
            contDb.Email = incidentDto.Email;
            contDb.Account = account;
            account.Incidents.Add(new Incident { Description = incidentDto.IncidentDescription });
            _dbContext.SaveChanges();
        }
    }
}