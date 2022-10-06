using System.Text.Json;
using CarServiceApp.Data;
using CarServiceApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarServiceApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly CarServiceAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
 

        private const string jsonFilePath = $@"D:\Dropbox\CODING2022\C#\repos\CarServiceApp\CarServiceApp\1_DataAccess\Data\OutputData\";

        private const string auditFileName = $@"D:\Dropbox\CODING2022\C#\repos\CarServiceApp\CarServiceApp\1_DataAccess\Data\OutputData\Audit.txt";
         
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        public SqlRepository(CarServiceAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(a => a.Id).ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
            ItemRemoved?.Invoke(this, item);
        }

        public void Save(string description)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            using (var writer = File.AppendText($"{jsonFilePath}{description} - [{date}]"+".json"))
            {
                foreach (var item in _dbSet)
                {
                    string employee = JsonSerializer.Serialize(item);
                    writer.WriteLine(employee);
                }
            }
            Console.WriteLine($"\n--- All data has been saved in json file ---");
        }

        public void SaveToAuditFile(string description, T e)
        {
            DateTime actualTime = DateTime.Now;
            using (var auditWriter = File.AppendText(auditFileName))
            {
                auditWriter.WriteLine($"{actualTime} - {description} - {e}");
            }
        }
    }
}

