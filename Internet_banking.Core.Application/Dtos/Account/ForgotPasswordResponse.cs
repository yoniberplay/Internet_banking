﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Dtos.Account
{
    public class ForgotPasswordResponse
    {
        public bool HasError { get; set; }
        public string? Error { get; set; }   
    }
}
