using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CarServiceApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarServiceApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        private const string fileName = $@"D:\Dropbox\CODING2022\C#\repos\CarServiceApp\CarServiceApp\Data\Employees.json";

        private const string auditFileName = $@"D:\Dropbox\CODING2022\C#\repos\CarServiceApp\CarServiceApp\Data\Audit.txt";

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
        public event EventHandler? FileOverwritten;
        public event EventHandler? FileLoaded;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList().OrderBy(a => a.Id);
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void SaveToFile()
        {
            File.Delete(fileName);
            using (var writer = File.AppendText(fileName))
            {
                foreach (var item in _dbSet)
                {
                    string employee = JsonSerializer.Serialize(item);
                    writer.WriteLine(employee);
                }
            }
            FileOverwritten?.Invoke(this, EventArgs.Empty);
            Console.WriteLine($"\n--- All data has been saved in file ---");
        }

        public void SaveToAuditFile(string description, string sendingEvent, Employee e)
        {
            DateTime actualTime = DateTime.UtcNow;
            using (var auditWriter = File.AppendText(auditFileName))
            {
                auditWriter.WriteLine($"{actualTime} - {description} - {e.FirstName} {e.LastName}");
            }
        }

        public void SaveToAuditFile(string description)
        {
            DateTime actualTime = DateTime.UtcNow;
            using (var auditWriter = File.AppendText(auditFileName))
            {
                auditWriter.WriteLine($"{actualTime} - {description}");
            }
        }

        public void LoadDataFromFile()
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("\nThe database is being populated with data from existing file");
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    if (line == "")
                    {
                        Console.WriteLine($"\n--- There is no data in the file ---");
                    }
                    else
                    {
                        while (line != null)
                        {
                            Add(JsonSerializer.Deserialize<T>(line));
                            Save();
                            line = reader.ReadLine();
                        }
                    }
                }
                Console.WriteLine($"\n--- All data has been transfered to database located in memory ---");
                FileLoaded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("There is now file with data. Please add some to database and then save it to the file");
            }
        }
    }
}

