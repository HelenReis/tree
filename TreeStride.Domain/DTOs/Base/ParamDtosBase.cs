﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.Domain.DTOs.Base
{
    public class ParamDtosBase : Notifiable<Notification>
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
}