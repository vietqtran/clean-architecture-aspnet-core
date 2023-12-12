﻿using Solution.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Contracts.Infrastructure {
    public interface IEmailSender {
        Task<bool> SendEmail (Email email);
    }
}
