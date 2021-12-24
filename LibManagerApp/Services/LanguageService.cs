using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class LanguageService
    {
        private AppDbContext _context;
        public LanguageService(AppDbContext context)
        {
            _context = context;
        }
        public void AddLanguage(LanguageVM languageVM)
        {
            var _language = new Language()
            {
                Name = languageVM.LanguageName,
            };
            _context.Languages.Add(_language);
            _context.SaveChanges();
        }
        public List<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }
        public Language GetLanguageById(int id)
        {
            return _context.Languages.FirstOrDefault(p => p.Id == id);
        }
    }
}
