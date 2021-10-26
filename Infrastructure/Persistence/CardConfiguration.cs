using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Registration).IsRequired();          
            builder.Property(x => x.CustomerId).IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}
