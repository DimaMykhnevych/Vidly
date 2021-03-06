﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class VidlyDbContext: IdentityDbContext<AppUser>
    {
        public VidlyDbContext() { }
        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }

}