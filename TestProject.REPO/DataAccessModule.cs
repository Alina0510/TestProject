using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DAL;
using TestProject.REPO.MapProfiles;

namespace TestProject.REPO
{
    public class DataAccessModule: Module
    {
        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new TProjDBContext(_connectionString)).As<TProjDBContext>();
            builder.RegisterType<RepoHelper>().As<RepoHelper>();
            builder.Register(context =>
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AccountMapProfile>();

                }).CreateMapper();
            }).As<IMapper>().SingleInstance();
            base.Load(builder);
        }
    }
}
