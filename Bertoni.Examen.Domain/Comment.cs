﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bertoni.Examen.Domain
{
    public class Comment
    {
        public int postId { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string body { get; set; }
    }
}
