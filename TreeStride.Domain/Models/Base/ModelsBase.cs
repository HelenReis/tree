
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.Domain.Models.Base
{
    public class ModelsBase : Notifiable<Notification>
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; private set; }
    }
}
