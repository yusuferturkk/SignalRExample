﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.WebUI.Dtos.ContactDtos
{
    public class GetContactDtos
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FooterDescription { get; set; }
    }
}
