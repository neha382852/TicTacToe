﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace TicTacToe.DatabaseLayer
{
    interface IRepository
    {
    
        void InsertIntoDatabase(User obj);
    }
}
