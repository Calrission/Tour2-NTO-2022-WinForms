using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyCore
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Models.Region> Regions => Set<Models.Region>();
        public DbSet<Models.Role> Roles => Set<Models.Role>();
        public DbSet<Models.Contact> Contacts => Set<Models.Contact>();
        public DbSet<Models.Hotel> Hotels => Set<Models.Hotel>();

        public DbSet<Models.Food> Foods => Set<Models.Food>();

        public DbSet<Models.ClientType> TypesClient => Set<Models.ClientType>();

        public DbSet<Models.Tour> Tours => Set<Models.Tour>();

        public DbSet<Models.Client> Clients => Set<Models.Client>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TravelCompanyCoreStorage.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Инициализируем Регионы (Местонахождения в терминологии заказчика)
            modelBuilder.Entity<Models.Region>().HasData(
                new Models.Region { Id = Guid.Parse("8FF98E1D-F2BA-4D2B-A3F7-A794755734A8"), Name = "Москва", Description = "Прекрасный город с прекрасной архитектурой!" },
                new Models.Region { Id = Guid.Parse("BAB8EABB-C79D-4969-9869-89F1F048F692"), Name = "Электросталь", Description = "Родной город участников команды" },
                new Models.Region { Id = Guid.Parse("07335F3B-154B-4B5A-8323-342B5B8ABC90"), Name = "Ленинградская область", Description = "Хорошее место для необычного туризма" },
                new Models.Region { Id = Guid.Parse("C95F17D4-FF8D-4F20-8A3F-B819209EA555"), Name = "Московская область", Description = "Мама дорогая, дорого то как..." },
                new Models.Region { Id = Guid.Parse("453FFECC-1E38-43B5-A9EB-50F9F2C87CF3"), Name = "ХМАО", Description = "Места много. Людей мало. Гостиниц нет" }
                );

            // Инициализируем Роли
            modelBuilder.Entity<Models.Role>().HasData(
                new Models.Role { Id = Guid.Parse("DA03F4BA-ED97-481B-8A47-ED885E08B6B5"), Name = "Администратор", Description = "Человек, который может ВСЁ" },
                new Models.Role { Id = Guid.Parse("514F8200-EB0E-4241-9114-C7CBB6E5AC2F"), Name = "Менеджер", Description = "Управляющий делами отеля" }
                );

            // Инициализируем Контакты
            modelBuilder.Entity<Models.Contact>().HasData(
                new Models.Contact { Id = Guid.Parse("264FD9D1-0E27-4609-B7CD-344FB3FD044F"), LastName = "Лебедихин", FirstName = "Петр", PatronymicName = "Степанович", EmailAddress = "lebedichp@yandex.ru", PhoneNumber = "+79091256789" },
                new Models.Contact { Id = Guid.Parse("4B37D5EF-0A58-4EDC-9E57-953C59E46BA4"), LastName = "Порожнев", FirstName = "Степан", PatronymicName = "Аркадиевич", EmailAddress = "stepaporozhnev@gmail.com", PhoneNumber = "+75376432905" },
                new Models.Contact { Id = Guid.Parse("242B1D5F-9103-474A-AEC4-F9143E87D58B"), LastName = "Епифанов", FirstName = "Николай", PatronymicName = "Александрович", EmailAddress = "kolyaepifan@yandex.ru", PhoneNumber = "+79536789123" }
                );

            // Добавляем Контакты в Роли
            modelBuilder.Entity<Models.Contact>().HasMany(
                c => c.Roles).WithMany(c => c.Contacts).UsingEntity(
                j => j.HasData( // Делаем Петра Степановича Администратором...
                    new { ContactsId = Guid.Parse("264FD9D1-0E27-4609-B7CD-344FB3FD044F"), RolesId = Guid.Parse("DA03F4BA-ED97-481B-8A47-ED885E08B6B5") },
                    // ...и управляющим,
                    new { ContactsId = Guid.Parse("264FD9D1-0E27-4609-B7CD-344FB3FD044F"), RolesId = Guid.Parse("514F8200-EB0E-4241-9114-C7CBB6E5AC2F") },
                    // А Степана Порожнева и Епифанова Николая - Управляющими отеля
                    new { ContactsId = Guid.Parse("4B37D5EF-0A58-4EDC-9E57-953C59E46BA4"), RolesId = Guid.Parse("514F8200-EB0E-4241-9114-C7CBB6E5AC2F") },
                    new { ContactsId = Guid.Parse("242B1D5F-9103-474A-AEC4-F9143E87D58B"), RolesId = Guid.Parse("514F8200-EB0E-4241-9114-C7CBB6E5AC2F") }
                    
                    )
                );

            // Инициализируем Питание
            modelBuilder.Entity<Models.Food>().HasData(
                new Models.Food { Id = Guid.Parse("f3ab28b7-b8a7-4c82-8584-335c58f2d000"), Name = "без питания" },
                new Models.Food { Id = Guid.Parse("a1e10f82-c118-483f-adde-6d9f1162f03d"), Name = "с завтраком" },
                new Models.Food { Id = Guid.Parse("5bfbcef2-0acb-4d1c-b718-35745f46bc07"), Name = "3-х разовое" }
                );

            // Инициализируем Типы клиентов
            modelBuilder.Entity<Models.ClientType>().HasData(
                new Models.ClientType { Id = Guid.Parse("cd3b7458-6f73-49c3-a56b-af81101cc3cd"), Name = "физическое лицо" },
                new Models.ClientType { Id = Guid.Parse("65bc9547-acd5-420e-8d60-0f037bfc4e79"), Name = "юридическое лицо" }
                );

            // Инициализируем Клиентов
            modelBuilder.Entity<Models.Client>().HasData(
                new Models.Client { Id = Guid.Parse("6d97731c-8408-4430-9c71-072842173fd4"), Name = "Турагенство «Ромашка»", ContactId = Guid.Parse("264FD9D1-0E27-4609-B7CD-344FB3FD044F"), ClientTypeId = Guid.Parse("65bc9547-acd5-420e-8d60-0f037bfc4e79") },
                new Models.Client { Id = Guid.Parse("87f50d79-1c38-47ce-acf6-0a7aa6de3fbd"), Name = "Агенство «Васильки»", ContactId = Guid.Parse("4B37D5EF-0A58-4EDC-9E57-953C59E46BA4"), ClientTypeId = Guid.Parse("65bc9547-acd5-420e-8d60-0f037bfc4e79") }
                );

            // Инициализируем Отели
            modelBuilder.Entity<Models.Hotel>().HasData(
                new Models.Hotel
                {
                    Id = Guid.Parse("4F9BF633-0841-434D-BAB5-3593F7D01D68"),
                    Name = "Прибрежные волны",
                    Description = "Качеством своих услуг Прибрежные волны бьют любой отель в России, как камни об берег, и по весьма сходной цене",
                    PhoneNumber = "+79091256789",
                    RegionId = Guid.Parse("8FF98E1D-F2BA-4D2B-A3F7-A794755734A8"), // Москва, то бишь. Отношение один ко многим
                    ManagerId = Guid.Parse("264FD9D1-0E27-4609-B7CD-344FB3FD044F")
                }, // Петр Степанович, естественно. Также один ко многим
                new Models.Hotel
                {
                    Id = Guid.Parse("952856FA-1655-425B-9635-6FE13A8E35FF"),
                    Name = "Гостиница «Чистый лист»",
                    Description = "Перезагрузись и начни все с нового листа, прекрасные апартаменты, обслуживание на высоте, приемлемые цены ",
                    PhoneNumber = "+79536789123",
                    RegionId = Guid.Parse("BAB8EABB-C79D-4969-9869-89F1F048F692"), // Электросталь
                    ManagerId = Guid.Parse("242B1D5F-9103-474A-AEC4-F9143E87D58B")
                }, // Николай Епифанов
                new Models.Hotel
                {
                    Id = Guid.Parse("1143FCDF-3C64-4D0F-8110-B788F906D03F"),
                    Name = "Гостиница «Космос»",
                    Description = "Дотянись до звезды, почувствуй себя свободным, космические цены, необычный интерьер, после посещения нашей гостиницы у Вас останутся неземные впечатления ",
                    PhoneNumber = "+75376432905",
                    RegionId = Guid.Parse("8FF98E1D-F2BA-4D2B-A3F7-A794755734A8"), // Москва
                    ManagerId = Guid.Parse("4B37D5EF-0A58-4EDC-9E57-953C59E46BA4") // Степан Порожнев 
                }
                );

        }
    }
}
