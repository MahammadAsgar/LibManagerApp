using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context= context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

        }
        public List<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }
        public Publisher GetPublisherById(int id)
        {
            return _context.Publishers.FirstOrDefault(p=>p.Id==id);
        }
    }
}
