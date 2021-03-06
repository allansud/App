﻿using App.Identity.Model;
using System.Data.Entity.ModelConfiguration;

namespace App.Repository.EntityConfig
{
    public class AppUserLoginConfig : EntityTypeConfiguration<AppUserLogin>
    {
        public AppUserLoginConfig()
        {
            Property(l => l.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);

            Property(l => l.ProviderKey)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
