using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PractSix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                Cust customer1 = new Cust { Name = "Kate", Age = 0 };
                Cust customer2 = new Cust { Name = "Muhhamed", Age = 1 };

                // Добавление
                db.Custumers.Add(customer1);
                db.Custumers.Add(customer2);
                db.SaveChanges();
            }

            // Получение
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получаем объекты из бд и выводим на консоль
                var custumers = db.Custumers.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Cust u in custumers)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Редактирование
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем первый объект
                Cust user = db.Custumers.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Dred";
                    user.Age = 5;
                    //обновляем объект
                    //db.Users.Update(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Custumers.ToList();
                foreach (Cust u in users)
                {
                    Console.WriteLine($"{u.Id}. {u.Name} - {u.Age}");
                }
            }

            // Удаление
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем первый объект
                Cust user = db.Custumers.FirstOrDefault();
                if (user != null)
                {
                    //удаляем объект
                    db.Custumers.Remove(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var users = db.Custumers.ToList();
                foreach (Cust u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            Console.Read();
        }
    }

    public class Cust
    {
        //Определяем заказчика
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ApplicationContext : DbContext
    {

        //Подключение к бд
        public DbSet<Cust> Custumers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
