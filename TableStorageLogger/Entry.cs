﻿using System;
using System.Globalization;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace TableStorageLogger
{
    public class Entry : TableServiceEntity
    {
        public Entry() { }

        public Entry(string service, string @event, string details)
        {
            Created = DateTime.UtcNow;
            Details = details;
            Event = @event;
            Service = service;
            SetKeys();
        }

        private void SetKeys()
        {
            RowKey = string.Format("{0}-{1}", DateTime.MaxValue.Subtract(Created).TotalMilliseconds.ToString(CultureInfo.InvariantCulture),
                                   Guid.NewGuid());
            PartitionKey = Service;
        }

        public string Service { get; set; }
        public DateTime Created { get; set; }
        public string Details { get; set; }
        public string Event { get; set; }
    }
}