using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.Configurations
{
    class PasswordResetConfiguration : IEntityTypeConfiguration<PasswordReset>
    {
        public void Configure(EntityTypeBuilder<PasswordReset> builder)
        {
        }
    }
}
