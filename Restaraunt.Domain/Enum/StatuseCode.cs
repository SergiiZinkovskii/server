﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,
        DishNotFound = 10,
        OrderNotFound = 20,
        CartNotFound = 30,
        OK = 200,
        InternalServerError = 500
    }
}
