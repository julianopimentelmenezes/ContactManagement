﻿using System.Collections.Generic;

namespace ContactManagement.Common.ViewModels.Bases
{
    /// <summary>
    /// This class has the standarts response API fields.
    /// All the services use this class or its derivations to response a call.
    /// </summary>
    public class BaseResponseViewModel
    {
        ICollection<string> _messages { get; set; }

        public bool Sucess { get; set; }

        public BaseResponseViewModel()
        {
            Sucess = true;
            _messages = new HashSet<string>();
        }

        public BaseResponseViewModel(bool sucess) : this() => Sucess = sucess;

        public IEnumerable<string> Messages => _messages;

        public void AddMessage(string message) => _messages.Add(message);

        public void AddMessages(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                AddMessage(message);
            }
        }
    }
}
