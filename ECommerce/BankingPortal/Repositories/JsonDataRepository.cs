﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BankingPortal.Repositories
{
    public class JsonDataRepository<T> : IDataRepository<T>
    {
        public List<T> Deserialize(string filename)
        {
            List<T> items = new List<T>();
            FileStream stream = new FileStream(filename, FileMode.Open);
            if (stream != null)
            {
                items = JsonSerializer.Deserialize<List<T>>(stream);
            }
            stream.Close();
            // retrive all products from file
            return items;
        }

        public bool Serialize(string filename, List<T> items)
        {
            bool status = false;
            FileStream createStream = File.Create(filename);
            JsonSerializer.Serialize(createStream, items);
            createStream.Close();
            return status;

        }

    }
}