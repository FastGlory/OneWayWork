using MauiApp1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class LocalDbService
    {
        private const string DB_NAME = "OneWayWork.db3";
        private readonly SQLiteAsyncConnection _connection;
    }
}
