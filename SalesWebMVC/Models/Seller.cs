﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        public Departament Departament { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        // Adiciona as vendas de um vendedor
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        // Remove as vendas de um vendedor
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // Total de vendas no periodo de um vendedor
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum (sr => sr.Amount);
        }
    }
}
