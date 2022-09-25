using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using LibManagerApp.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class LanguageService:ILanguageService
    {
        private AppDbContext _context;
        public LanguageService(AppDbContext context)
        {
            _context = context;
        }
        public Language AddLanguage(LanguageVM languageVM)
        {
            var _language = new Language()
            {
                Name = languageVM.LanguageName,
            };
            _context.Languages.Add(_language);
            _context.SaveChanges();
            return _language;
        }
        public Language UpdateLanguage(int id, LanguageVM languageVM)
        {
            var language=_context.Languages.FirstOrDefault(x=>x.Id==id);
            language.Name=languageVM.LanguageName;
            _context.Languages.Update(language);
            return language;
        }
        public Language GetLanguageById(int id)
        {
            return _context.Languages.FirstOrDefault(p => p.Id == id);
        }

        public void RemoveLanguage(int id)
        {
            var language = _context.Languages.FirstOrDefault(x => x.Id == id);
            _context.Languages.Remove(language);
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return _context.Languages;
        }
    }
}
