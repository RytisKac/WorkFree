﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFree.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        public string SenderName { get; set; }
    }
}
