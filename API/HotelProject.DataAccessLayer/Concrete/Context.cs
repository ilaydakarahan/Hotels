﻿using HotelProject.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BFPJH2M;initial catalog=HotelsDb;integrated security=true;");
        }

        DbSet<Room> Rooms { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Staff> Staffs { get; set;}
        DbSet<Subscribe> Subscribes { get; set; }
        DbSet<Testimonial> Testimonials { get; set;}
    }
}