namespace Lands.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Lands.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<Lands.Domain.UserType> UserTypes { get; set; }
    }
}