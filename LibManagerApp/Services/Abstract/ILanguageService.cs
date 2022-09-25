using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using System.Collections.Generic;
namespace LibManagerApp.Services.Abstract
{
    public interface ILanguageService
    {
        public Language AddLanguage(LanguageVM languageVM);
        public Language UpdateLanguage(int id, LanguageVM languageVM);
        public void RemoveLanguage(int id);
        public Language GetLanguageById(int id);
        public IEnumerable<Language> GetAllLanguages();
    }
}
