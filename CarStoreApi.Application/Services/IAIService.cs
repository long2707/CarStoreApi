﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Services
{
    public interface IAIService
    {
        Task<string> GetAIResponse(string prompt);
    }
}
