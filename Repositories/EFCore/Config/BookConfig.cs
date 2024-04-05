﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 74.99m },
                new Book { Id = 2, Title = "Titreyen Babalar ve Oğulları", Price = 99.99m },
                new Book { Id = 3, Title = "Sabri Sarıoğlu'ndan Seçmeler", Price = 12.99m }
                );
        }
    }
}
