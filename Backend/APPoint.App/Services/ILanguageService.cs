﻿using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetAll();
    }
}
